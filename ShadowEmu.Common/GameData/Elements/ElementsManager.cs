using ShadowEmu.Common.Extensions;
using ShadowEmu.Common.GameData.Maps.Elements;
using ShadowEmu.Common.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadowEmu.Common.GameData.Elements
{
    public class ElementsManager : DataManager<ElementsManager>
    {
        public uint fileVersion;

        public uint elementsCount;

        public Dictionary<int, GraphicalElement> _elementsMap;

        private Dictionary<int, bool> _jpgMap;

        private Dictionary<int, int> _elementsIndex;

        public Dictionary<int, int> types;

        private IDataReader _rawData;

        public void FromRaw(string path)
        {
            BigEndianReader raw = new BigEndianReader(Uncompress(File.ReadAllBytes(path)));
            _rawData = raw;

            types = new Dictionary<int, int>();

            int header = raw.ReadByte();
            if (header != 69)
            {
                throw new Exception("Unknown file format");
            }

            int Version = raw.ReadByte();
            int skypLen = 0;

            var count = raw.ReadUInt();
            for (int i = 0; i < count; i++)
            {
                if (Version >= 9)
                {
                    skypLen = raw.ReadUShort();
                }

                var id = raw.ReadInt();

                //if(Version > 8)
                //    raw.Seek(skypLen - 4, SeekOrigin.Current);

                var type = raw.ReadByte();
                types[id] = type;

                switch (type)
                {
                    case 2: //ANIMATED
                        raw.ReadInt();
                        raw.ReadByte();
                        raw.ReadBoolean();
                        raw.ReadShort();
                        raw.ReadShort();
                        raw.ReadShort();
                        raw.ReadShort();
                        if (Version == 4)
                        {
                            raw.ReadInt();
                            raw.ReadInt();
                        }
                        break;
                    case 5: //BLENDED
                        raw.ReadInt();
                        raw.ReadByte();
                        raw.ReadBoolean();
                        raw.ReadShort();
                        raw.ReadShort();
                        raw.ReadShort();
                        raw.ReadShort();
                        raw.ReadUTFBytes(raw.ReadInt());
                        break;
                    case 1: //BOUNDING_BOX
                        raw.ReadInt();
                        raw.ReadByte();
                        raw.ReadBoolean();
                        raw.ReadShort();
                        raw.ReadShort();
                        raw.ReadShort();
                        raw.ReadShort();
                        break;
                    case 3: //ENTITY
                        string test = raw.ReadUTF7BitLength();
                        raw.ReadBoolean();
                        if (Version >= 7)
                            raw.ReadBoolean();
                        if(Version >= 6)
                            raw.ReadBoolean();
                        if(Version >= 5)
                        {
                            raw.ReadInt();
                            raw.ReadInt();
                        }
                        break;
                    case 0: //NORMAL
                        raw.ReadInt();
                        raw.ReadByte();
                        raw.ReadBoolean();
                        raw.ReadShort();
                        raw.ReadShort();
                        raw.ReadShort();
                        raw.ReadShort();
                        break;
                    case 4: //PARTICLES
                        raw.ReadShort();
                        break;
                    default:
                        Console.WriteLine("Unknown graphical data of type " + type);
                        break;
                }
            }

            if (Version >= 8)
            {
                var gfxCount = raw.ReadInt();
                for (int i = 0; i < gfxCount; i++)
                {
                    raw.ReadInt();
                }
            }
        }

        public int readElement(int edId)
        {
            return types[edId];
        }

        public byte[] Uncompress(byte[] data)
        {
            using (var stream = new MemoryStream(data, 2, data.Length - 2))
            using (var inflater = new DeflateStream(stream, CompressionMode.Decompress))
            using (var streamReader = new StreamReader(inflater))
            {
                return Encoding.ASCII.GetBytes(streamReader.ReadToEnd());
            }
        }

    }
}
