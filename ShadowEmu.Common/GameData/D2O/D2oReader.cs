#region License GNU GPL
// D2oReader.cs
// 
// Copyright (C) 2012 - BehaviorIsManaged
// 
// This program is free software; you can redistribute it and/or modify it 
// under the terms of the GNU General Public License as published by the Free Software Foundation;
// either version 2 of the License, or (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; 
// without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. 
// See the GNU General Public License for more details. 
// You should have received a copy of the GNU General Public License along with this program; 
// if not, write to the Free Software Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA 02111-1307 USA
#endregion
using ShadowEmu.Common.Extensions;
using ShadowEmu.Common.IO;
using ShadowEmu.Common.Protocol.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Emit;

namespace ShadowEmu.Common.GameData.D2O
{
    public class D2oReader
    {
        private const int NullIdentifier = unchecked((int) 0xAAAAAAAA);

        /// <summary>
        /// Contains all assembly where the reader search d2o class
        /// </summary>
        public static List<Assembly> ClassesContainers = new List<Assembly>
            {
            typeof (Breed).Assembly
            };

        private static readonly Dictionary<Type, Func<object[], object>> objectCreators =
            new Dictionary<Type, Func<object[], object>>();

        private readonly string filePath;


        private int classcount;
        private Dictionary<int, D2oClassDefinition> classes;
        private int headeroffset;
        private Dictionary<int, int> indextable = new Dictionary<int, int>();
        private int indextablelen;
        private IDataReader reader;

        /// <summary>
        ///   Create and initialise a new D2o file
        /// </summary>
        /// <param name = "filePath">Path of the file</param>
        public D2oReader(string filePath)
            : this(new FastBigEndianReader(File.ReadAllBytes(filePath)))
        {
            this.filePath = filePath;
        }

        public D2oReader(Stream stream)
        {
            reader = new BigEndianReader(stream);
            Initialize();
        }

        public D2oReader(IDataReader reader)
        {
            this.reader = reader;
            Initialize();
        }

        public string FilePath
        {
            get
            {
                return filePath;
            }
        }

        public string FileName
        {
            get
            {
                return Path.GetFileNameWithoutExtension(FilePath);
            }
        }

        public int IndexCount
        {
            get
            {
                return indextable.Count;
            }
        }

        public Dictionary<int, D2oClassDefinition> Classes
        {
            get
            {
                return classes;
            }
        }

        public Dictionary<int, int> Indexes
        {
            get
            {
                return indextable;
            }
        }

        private void Initialize()
        {
            lock (reader)
            {
                string header = reader.ReadUTFBytes(3);

                if (header != "D2O")
                {
                    throw new System.Exception("Header doesn't equal the string \'D2o\' : Corrupted file");
                }

                ReadIndexTable();
                ReadClassesTable();
            }
        }

        private void ReadIndexTable()
        {
            headeroffset = reader.ReadInt();
            reader.Seek(headeroffset, SeekOrigin.Begin); // place the reader at the beginning of the indextable
            indextablelen = reader.ReadInt();

            // init table index
            indextable = new Dictionary<int, int>(indextablelen/8);
            for (int i = 0; i < indextablelen; i += 8)
            {
                indextable.Add(reader.ReadInt(), reader.ReadInt());
            }
        }

        private void ReadClassesTable()
        {
            classcount = reader.ReadInt();
            classes = new Dictionary<int, D2oClassDefinition>(classcount);
            for (int i = 0; i < classcount; i++)
            {
                int classId = reader.ReadInt();

                string classMembername = reader.ReadUTF();
                string classPackagename = reader.ReadUTF();
                Type classType = null;

                try
                {
                    classType = FindType(classMembername);
                }
                catch(Exception)
                {
                    Console.WriteLine("Can't find type for D2O class " + classMembername);
                    continue;
                }

                int fieldscount = reader.ReadInt();
                var fields = new List<D2oFieldDefinition>(fieldscount);
                for (int l = 0; l < fieldscount; l++)
                {
                    string fieldname = reader.ReadUTF();
                    var fieldtype = (D2oFieldType) reader.ReadInt();

                    var vectorTypes = new List<Tuple<D2oFieldType, string>>();
                    if (fieldtype == D2oFieldType.List)
                    {
                        addVectorType:

                        string name = reader.ReadUTF();
                        var id = (D2oFieldType) reader.ReadInt();
                        vectorTypes.Add(Tuple.Create(id, name));

                        if (id == D2oFieldType.List)
                            goto addVectorType;
                    }

                    FieldInfo field = classType.GetField(fieldname);

                    if (field == null)
                        Console.WriteLine(string.Format("Missing field '{0}' ({1}) in class '{2}'", fieldname, fieldtype, classType.Name));

                    fields.Add(new D2oFieldDefinition(fieldname, fieldtype, field, reader.Position,
                                                      vectorTypes.ToArray()));
                }

                classes.Add(classId,
                              new D2oClassDefinition(classId, classMembername, classPackagename, classType, fields,
                                                     reader.Position));
            }
        }

        private static Type FindType(string className)
        {
            IEnumerable<Type> correspondantTypes = from asm in ClassesContainers
                                                   let types = asm.GetTypes()
                                                   from type in types
                                                   where type.Name.Equals(className, StringComparison.InvariantCulture) && type.HasInterface(typeof(IDataObject))
                                                   select type;

            return correspondantTypes.Single();
        }

        private bool IsTypeDefined(Type type)
        {
            return classes.Count(entry => entry.Value.ClassType == type) > 0;
        }

        /// <summary>
        ///   Get all objects that corresponding to T associated to his index
        /// </summary>
        /// <typeparam name = "T">Corresponding class</typeparam>
        /// <param name = "allownulled">True to adding null instead of throwing an exception</param>
        /// <returns></returns>
        public Dictionary<int, T> ReadObjects<T>(bool allownulled = false)
            where T : class
        {
            //if (!IsTypeDefined(typeof (T)))
            //   Console.WriteLine("The file doesn't contain this class");

            var result = new Dictionary<int, T>(indextable.Count);

            using (var reader = CloneReader())
            {
                foreach (var index in indextable)
                {
                    reader.Seek(index.Value, SeekOrigin.Begin);

                    int classid = reader.ReadInt();

                    if (classes[classid].ClassType == typeof (T) ||
                        classes[classid].ClassType.IsSubclassOf(typeof (T)))
                    {
                        try
                        {
                            result.Add(index.Key, BuildObject(classes[classid], reader)as T);
                        }
                        catch
                        {
                            if (allownulled)
                                result.Add(index.Key, default(T));
                            else
                                throw;
                        }
                    }
                }
            }
            return result;
        }

        /// <summary>
        ///   Get all objects associated to his index
        /// </summary>
        /// <param name = "allownulled">True to adding null instead of throwing an exception</param>
        /// <returns></returns>
        public Dictionary<int, object> ReadObjects(bool allownulled = false, bool cloneReader = false)
        {
            var result = new Dictionary<int, object>(indextable.Count);

            IDataReader reader = cloneReader ? CloneReader() : this.reader;

            foreach (var index in indextable)
            {
                reader.Seek(index.Value, SeekOrigin.Begin);

                try
                {
                    result.Add(index.Key, ReadObject(index.Key, reader));
                }
                catch
                {
                    if (allownulled)
                        result.Add(index.Key, null);
                    else
                        return null;
                }
            }

            if (cloneReader)
                reader.Dispose();

            return result;
        }

        /// <summary>
        ///   Get an object from his index
        /// </summary>
        /// <param name="cloneReader">When sets to true it copies the reader to have a thread safe method</param>
        /// <returns></returns>
        public object ReadObject(int index, bool cloneReader = false)
        {
            if (cloneReader)
            {
                using (var reader = CloneReader())
                {
                    return ReadObject(index, reader);
                }
            }

            lock (this.reader)
            {
                return ReadObject(index, this.reader);
            }
        }

        private object ReadObject(int index, IDataReader reader)
        {
            int offset = indextable[index];
            reader.Seek(offset, SeekOrigin.Begin);

            int classid = reader.ReadInt();

            object result = BuildObject(classes[classid], reader);

            return result;
        }

        private object BuildObject(D2oClassDefinition classDefinition, IDataReader reader)
        {
            if (!objectCreators.ContainsKey(classDefinition.ClassType))
            {
                Func<object[], object> creator = CreateObjectBuilder(classDefinition.ClassType,
                                                                     classDefinition.Fields.Select(
                                                                         entry => entry.Value.FieldInfo).ToArray());

                objectCreators.Add(classDefinition.ClassType, creator);
            }

            var values = new List<object>();
            foreach (D2oFieldDefinition field in classDefinition.Fields.Values)
            {
                object fieldValue = fieldValue = ReadField(reader, field, field.TypeId);

                if (field.FieldType.IsAssignableFrom(fieldValue.GetType()))
                    values.Add(fieldValue);
                else if (fieldValue is IConvertible &&
                         field.FieldType.GetInterface("IConvertible") != null)
                {
                    try
                    {
                        if (fieldValue is int && ((int)fieldValue) < 0 && field.FieldType == typeof(uint))
                            values.Add(unchecked ((uint)((int)fieldValue)));
                        else
                            values.Add(Convert.ChangeType(fieldValue, field.FieldType));
                    }
                    catch
                    {
                        Console.WriteLine(string.Format("Field '{0}.{1}' with value {2} is not of type '{3}'", classDefinition.Name,
                                                          field.Name, fieldValue, fieldValue.GetType()));
                    }
                }
                else
                {
                    Console.WriteLine(string.Format("Field '{0}.{1}' with value {2} is not of type '{3}'", classDefinition.Name,
                                                      field.Name, fieldValue, fieldValue.GetType()));
                }
            }

            return objectCreators[classDefinition.ClassType](values.ToArray());
        }

        public T ReadObject<T>(int index, bool cloneReader = false, bool noExceptionThrown = false)
            where T : class
        {
            if (cloneReader)
            {
                using (var reader = CloneReader())
                {
                    return ReadObject<T>(index, reader, noExceptionThrown);
                }
            }

            return ReadObject<T>(index, this.reader, noExceptionThrown);
        }

        private T ReadObject<T>(int index, IDataReader reader, bool noExceptionThrown = false)
            where T : class
        {
            if (!IsTypeDefined(typeof (T)))
                Console.WriteLine("The file doesn't contain this class"); // Serious error, exception always thrown

            int offset = 0;
            if (!indextable.TryGetValue(index, out offset))
            {
                if (noExceptionThrown) return null;
            }

            reader.Seek(offset, SeekOrigin.Begin);

            int classid = reader.ReadInt();

            if (classes[classid].ClassType != typeof(T) && !classes[classid].ClassType.IsSubclassOf(typeof(T)))
                Console.WriteLine(string.Format("Wrong type, try to read object with {1} instead of {0}",
                                                    typeof(T).Name, classes[classid].ClassType.Name));

            return BuildObject(classes[classid], reader) as T;
        }

        public Dictionary<int, D2oClassDefinition> GetObjectsClasses()
        {
            return indextable.ToDictionary(index => index.Key, index => GetObjectClass(index.Key));
        }


        /// <summary>
        /// Get the class corresponding to the object at the given index
        /// </summary>
        public D2oClassDefinition GetObjectClass(int index)
        {
            lock (reader)
            {
                int offset = indextable[index];
                reader.Seek(offset, SeekOrigin.Begin);

                int classid = reader.ReadInt();

                return classes[classid];
            }
        }

        private object ReadField(IDataReader reader, D2oFieldDefinition field, D2oFieldType typeId,
                                 int vectorDimension = 0)
        {
            try
            {
                switch (typeId)
                {
                    case D2oFieldType.Int:
                        return ReadFieldInt(reader);
                    case D2oFieldType.Bool:
                        return ReadFieldBool(reader);
                    case D2oFieldType.String:
                        return ReadFieldUTF(reader);
                    case D2oFieldType.Double:
                        return ReadFieldDouble(reader);
                    case D2oFieldType.I18N:
                        return ReadFieldI18n(reader);
                    case D2oFieldType.UInt:
                        return ReadFieldUInt(reader);
                    case D2oFieldType.List:
                        return ReadFieldVector(reader, field, vectorDimension);
                    default:
                        return ReadFieldObject(reader);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(string.Format("[D2O] Can't read field {0} for exception {1}.", field.Name, ex.Message));
                return null;
            }
        }


        private object ReadFieldVector(IDataReader reader, D2oFieldDefinition field, int vectorDimension)
        {
            int count = reader.ReadInt();

            Type vectorType = field.FieldType;
            for (int i = 0; i < vectorDimension; i++)
            {
                vectorType = vectorType.GetGenericArguments()[0];
            }

            lock (objectCreators) // We sometimes have error on objectCreators.Add(vectorType, creator) : mainlock allready in the dictionary
                if (!objectCreators.ContainsKey(vectorType))
                {
                    Func<object[], object> creator = CreateObjectBuilder(vectorType, new FieldInfo[0]);

                    objectCreators.Add(vectorType, creator);
                }

            var result = objectCreators[vectorType](new object[0]) as IList;

            for (int i = 0; i < count; i++)
            {
                vectorDimension++;
                // i didn't found a way to have thez correct dimension so i just add "- 1"
                result.Add(ReadField(reader, field, field.VectorTypes[vectorDimension - 1].Item1, vectorDimension));
                vectorDimension--;
            }

            return result;
        }

        private object ReadFieldObject(IDataReader reader)
        {
            int classid = reader.ReadInt();

            if (classid == NullIdentifier)
                return null;

            if (Classes.Keys.Contains(classid))
                return BuildObject(Classes[classid], reader);

            return null;
        }

        private static int ReadFieldInt(IDataReader reader)
        {
            return reader.ReadInt();
        }

        private static uint ReadFieldUInt(IDataReader reader)
        {
            return reader.ReadUInt();
        }

        private static bool ReadFieldBool(IDataReader reader)
        {
            return reader.ReadByte() != 0;
        }

        private static string ReadFieldUTF(IDataReader reader)
        {
            return reader.ReadUTF();
        }

        private static double ReadFieldDouble(IDataReader reader)
        {
            return reader.ReadDouble();
        }

        private static int ReadFieldI18n(IDataReader reader)
        {
            return reader.ReadInt();
        }

        internal IDataReader CloneReader()
        {
            lock (reader)
            {
                if (reader.Position > 0)
                    reader.Seek(0, SeekOrigin.Begin);

                Stream streamClone;

                if (reader is FastBigEndianReader)
                    return new FastBigEndianReader(( reader as FastBigEndianReader ).Buffer);
                else
                {
                    streamClone = new MemoryStream();
                    ((BigEndianReader)reader).BaseStream.CopyTo(streamClone);
                }

                return new BigEndianReader(streamClone);
            }
        }

        public void Close()
        {
            lock (reader)
            {
                reader.Dispose();
            }
        }

        private static Func<object[], object> CreateObjectBuilder(Type classType, params FieldInfo[] fields)
        {
            IEnumerable<Type> fieldsType = from entry in fields
                                           select entry.FieldType;

            var method = new DynamicMethod(Guid.NewGuid().ToString("N"), typeof (object),
                                           new[] {typeof (object[])}.ToArray());

            ILGenerator ilGenerator = method.GetILGenerator();

            ilGenerator.DeclareLocal(classType);
            ilGenerator.DeclareLocal(classType);

            ilGenerator.Emit(OpCodes.Newobj, classType.GetConstructor(Type.EmptyTypes));
            ilGenerator.Emit(OpCodes.Stloc_0);
            for (int i = 0; i < fields.Length; i++)
            {
                ilGenerator.Emit(OpCodes.Ldloc_0);
                ilGenerator.Emit(OpCodes.Ldarg_0);
                ilGenerator.Emit(OpCodes.Ldc_I4, i);
                ilGenerator.Emit(OpCodes.Ldelem_Ref);

                if (fields[i].FieldType.IsClass)
                    ilGenerator.Emit(OpCodes.Castclass, fields[i].FieldType);
                else
                {
                    ilGenerator.Emit(OpCodes.Unbox_Any, fields[i].FieldType);
                }

                ilGenerator.Emit(OpCodes.Stfld, fields[i]);
            }

            ilGenerator.Emit(OpCodes.Ldloc_0);
            ilGenerator.Emit(OpCodes.Stloc_1);
            ilGenerator.Emit(OpCodes.Ldloc_1);
            ilGenerator.Emit(OpCodes.Ret);

            return
                (Func<object[], object>)
                method.CreateDelegate(Expression.GetFuncType(new[] {typeof (object[]), typeof (object)}.ToArray()));
        }
    }
}