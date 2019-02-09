using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadowEmu.Common.GameData.D2O
{
    public static class ObjectDataManager
    {
        public static readonly Dictionary<Type, D2oReader> readers = new Dictionary<Type, D2oReader>();

        private static string Directory;

        public static void Initialize(string directory)
        {
            Directory = directory;
            foreach (var d2iFile in System.IO.Directory.EnumerateFiles(directory).Where(entry => entry.EndsWith(".d2o")))
                    AddReader(new D2oReader(d2iFile));
        }

        public static void AddReader(D2oReader d2oFile)
        {
            var classes = d2oFile.Classes;
            
            foreach (var @class in classes)
            {
                if (readers.ContainsKey(@class.Value.ClassType))
                {
                    // this classes are not bound to a single file, so we ignore them
                    readers.Remove(@class.Value.ClassType);
                }
                else
                {
                    readers.Add(@class.Value.ClassType, d2oFile);
                }
            }
        }

        public static List<object> AddSingleReader(string file)
        {
            var d2oFile = new D2oReader(file);
            readers.Clear();

            return d2oFile.ReadObjects<object>(true).Values.ToList();
        }

        public static T Get<T>(uint key)
            where T : class
        {
            return Get<T>((int)key);
        }

        public static T Get<T>(int key, bool noExceptionThrown = false)
            where T : class
        {
            if (!readers.ContainsKey(typeof(T)))
            {
                //AddReader(new D2oReader(Directory + @"\" + typeof(T).ToString().Replace("AmaknaProxy.API.Protocol.Data.", "") + "s.d2o"));
                throw new Exception("Missing D2O " + typeof(T).ToString().Replace("AmaknaProxy.API.Protocol.Data.", ""));
            }

            var reader = readers[typeof(T)];

            return reader.ReadObject<T>(key, true, noExceptionThrown);
        }

        public static List<T> GetAll<T>()
            where T : class
        {
            if (!readers.ContainsKey(typeof(T))) // This exception should be called in all cases (serious)
                throw new ArgumentException("Cannot find data corresponding to type : " + typeof(T));

            var reader = readers[typeof(T)];

            return reader.ReadObjects<T>(true).Values.ToList();
        }

        public static IEnumerable<Type> GetAllTypes()
        {
            return readers.Keys;
        }

        private static IEnumerable<object> EnumerateObjects(Type type)
        {
            if (!readers.ContainsKey(type))
                throw new ArgumentException("Cannot find data corresponding to type : " + type);

            var reader = readers[type];

            return reader.Indexes.Select(index => reader.ReadObject(index.Key, true)).Where(obj => obj.GetType().Name == type.Name);
        }

        public static IEnumerable<T> EnumerateObjects<T>() where T : class
        {
            if (!readers.ContainsKey(typeof(T)))
                throw new ArgumentException("Cannot find data corresponding to type : " + typeof(T));

            var reader = readers[typeof(T)];

            return reader.Indexes.Select(index => reader.ReadObject(index.Key, true)).OfType<T>().Select(obj => obj);
        }

        public static void Dispose()
        {
            readers.Clear();
        }
    }
}
