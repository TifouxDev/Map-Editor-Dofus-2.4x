using ShadowEmu.Common.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadowEmu.Common.GameData.D2I
{
    public class D2iFile
    {
        private readonly string uri;

        private readonly Dictionary<string, int> textIndexesSeek = new Dictionary<string, int>();
        private readonly Dictionary<string, string> textIndexes = new Dictionary<string, string>();

        private readonly Dictionary<int, int> indexesSeek = new Dictionary<int, int>();
        private readonly Dictionary<int, string> indexes = new Dictionary<int, string>();

        private readonly Dictionary<int, int> unDiacriticalIndex = new Dictionary<int, int>();
        private Dictionary<int, string> testUndial = new Dictionary<int, string>();

        private readonly Dictionary<int, int> _textSortIndex = new Dictionary<int, int>();
        FastBigEndianReader reader;

        public D2iFile(string uri)
        {
            this.uri = uri;
            reader = new FastBigEndianReader(File.ReadAllBytes(uri));
            Initialize();
        }

        public string FilePath
        {
            get { return uri; }
        }

        private void Initialize()
        {
            var key = 0;
            var pointer = 0;
            var diacriticalText = false;
            uint position = 0;
            string textKey = null;

            int indexesPointer = this.reader.ReadInt();
            uint keyCount = 0;
            this.reader.Seek(indexesPointer, SeekOrigin.Begin);
            int indexesLength = this.reader.ReadInt();
            for (uint i = 0; i < indexesLength; i = i + 9)
            {
                key = this.reader.ReadInt();
                diacriticalText = this.reader.ReadBoolean();
                pointer = this.reader.ReadInt();
                this.indexesSeek[key] = pointer;
                keyCount++;
                if (diacriticalText)
                {
                    keyCount++;
                    i = i + 4;
                    this.unDiacriticalIndex[key] = this.reader.ReadInt();
                }
                else
                {
                    this.unDiacriticalIndex[key] = pointer;
                }
            }
            for (indexesLength = this.reader.ReadInt(); indexesLength > 0;)
            {
                position = (uint)this.reader.Position;
                textKey = this.reader.ReadUTF();
                pointer = this.reader.ReadInt();
                this.textIndexesSeek[textKey] = pointer;
                indexesLength = (int)(indexesLength - (this.reader.Position - position));
            }
            indexesLength = this.reader.ReadInt();
            for (int z = 0; indexesLength > 0;)
            {
                position = (uint)this.reader.Position;
                this._textSortIndex[this.reader.ReadInt()] = z + 1;
                indexesLength = (int)(indexesLength - (this.reader.Position - position));
            }

            foreach (var pos in indexesSeek)
            {
                reader.Seek(pos.Value, SeekOrigin.Begin);
                indexes[pos.Key] = reader.ReadUTF();
            }

            foreach (var pos in unDiacriticalIndex)
            {
                reader.Seek(pos.Value, SeekOrigin.Begin);
                testUndial[pos.Key] = reader.ReadUTF();
            }

            foreach (var pos in textIndexesSeek)
            {
                reader.Seek(pos.Value, SeekOrigin.Begin);
                textIndexes[pos.Key] = reader.ReadUTF();
            }
        }

        public string GetText(int id)
        {
            if (indexes.ContainsKey(id))
            {
                return indexes[id];
            }
            return "{null}";
        }
        public string GetText(string id)
        {
            if (textIndexes.ContainsKey(id))
            {
                return textIndexes[id];
            }
            return "{null}";
        }
        public void SetText(int id, string value)
        {
            if (indexes.ContainsKey(id))
                indexes[id] = value;
            else
                indexes.Add(id, value);
        }
        public void SetText(string id, string value)
        {
            if (textIndexes.ContainsKey(id))
                textIndexes[id] = value;
            else
                textIndexes.Add(id, value);
        }
        public Dictionary<int, string> GetAllText()
        {
            return indexes;
        }
        public Dictionary<string, string> GetAllUiText()
        {
            return textIndexes;
        }
        public void RemoveText(int id)
        {
            if (indexes.ContainsKey(id))
                indexes.Remove(id);
        }
        public void Save()
        {
            Save(uri);
        }

        public void Save(string uri)
        {
            using (var writer = new BigEndianWriter(new StreamWriter(uri).BaseStream))
            {
                var indexTable = new BigEndianWriter();
                writer.Seek(4, SeekOrigin.Begin);
                int i = 0;
                foreach (var index in indexes)
                {
                    indexTable.WriteInt(index.Key);
                    indexTable.WriteBoolean(unDiacriticalIndex.ContainsKey(index.Key));
                    indexTable.WriteInt((int)writer.Position);
                    writer.WriteUTF(index.Value);
                    if (unDiacriticalIndex.ContainsKey(index.Key))
                    {                     
                        indexTable.WriteInt((int)writer.Position);
                        writer.WriteUTF(testUndial[index.Key]);
                    }                    
                    i++;
                }

                var indexLen = (int)indexTable.Data.Length;

                var indexTextTable = new BigEndianWriter();
                foreach (var index in textIndexes)
                {
                    indexTextTable.WriteUTF(index.Key);
                    indexTextTable.WriteInt((int)writer.Position);
                    writer.WriteUTF(index.Value);
                    i++;
                }

                var indexTextSortTable = new BigEndianWriter();
                foreach (var index in _textSortIndex)
                {
                    indexTextSortTable.WriteInt((int)index.Key);
                    i++;
                }

                var indexPos = (int)writer.Position;

                /* write index at end */
                var indexData = indexTable.Data;
                writer.WriteInt(indexLen);
                writer.WriteBytes(indexData);
                writer.WriteInt((int)indexTextTable.Data.Length);
                writer.WriteBytes(indexTextTable.Data);
                writer.WriteInt((int)indexTextSortTable.Data.Length);
                writer.WriteBytes(indexTextSortTable.Data);

                /* write index pos at begin */
                writer.Seek(0, SeekOrigin.Begin);
                writer.WriteInt(indexPos);
            }
        }
    }
}
