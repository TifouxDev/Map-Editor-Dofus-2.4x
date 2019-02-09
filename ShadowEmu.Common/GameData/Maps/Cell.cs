using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShadowEmu.Common.IO;
using ShadowEmu.Common.GameData.Maps.Elements;

namespace ShadowEmu.Common.GameData.Maps
{
    [Serializable()]
    public class Cell
    {
        // Methods
        internal void Init(BigEndianReader Reader, int MapVersion)
        {
            this.CellId = Reader.ReadShort();
            this.ElementsCount = Reader.ReadShort();
            int elementsCount = this.ElementsCount;
            for (int i = 0; i < elementsCount; i++)
            {
                BasicElement elementFromType = BasicElement.GetElementFromType(Reader.ReadByte());
                elementFromType.Init(Reader, MapVersion);
                this.Elements.Add(elementFromType);
            }
        }

        public void Write(BigEndianWriter writer, int mapVersion)
        {
            writer.WriteShort((short)CellId);
            writer.WriteShort((short)Elements.Count);
            foreach (var item in Elements)
            {
                if (item is GraphicalElement)
                {
                    var test = item as GraphicalElement;
                    test.Hue = new ColorMultiplicator(0, 0, 0);
                    test.Shadow = new ColorMultiplicator(0, 0, 0);

                }
                item.Write(writer, mapVersion);
            }
        }

        // Fields
        public int CellId;
        public List<BasicElement> Elements = new List<BasicElement>();
        public int ElementsCount;
    }
}
