using ShadowEmu.Common.IO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadowEmu.Common.GameData.Elements.Test
{
    public class EleInstance
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public EleInstance()
        {
            GraphicalDatas = new Dictionary<int, EleGraphicalData>();
            GfxJpgMap = new Dictionary<int, bool>();
        }

        public byte Version
        {
            get;
            set;
        }

        public Dictionary<int, EleGraphicalData> GraphicalDatas
        {
            get;
            set;
        }

        public Dictionary<int, bool> GfxJpgMap
        {
            get;
            set;
        }

        public static EleInstance ReadFromStream(BigEndianReader reader)
        {
            var instance = new EleInstance();

            reader.ReadByte();
            instance.Version = reader.ReadByte();

            var count = reader.ReadUInt();
            for (int i = 0; i < count; i++)
            {
                if (instance.Version >= 9)
                {
                    reader.ReadUShort();
                }

                var elem = EleGraphicalData.ReadFromStream(instance, reader);
                instance.GraphicalDatas.Add(elem.Id, elem);
            }

            if (instance.Version >= 8)
            {
                var gfxCount = reader.ReadInt();
                for (int i = 0; i < gfxCount; i++)
                {
                    instance.GfxJpgMap.Add(reader.ReadInt(), true);
                }
            }

            return instance;
        }
    }
}
