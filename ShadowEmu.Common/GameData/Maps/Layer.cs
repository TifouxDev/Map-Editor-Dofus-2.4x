using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShadowEmu.Common.IO;
using System.IO;

namespace ShadowEmu.Common.GameData.Maps
{
    [Serializable()]
    public class Layer
    {
        // Methods
        internal void Init(BigEndianReader Reader, int MapVersion)
        {
            if (MapVersion >= 9)
            {
                this.LayerId = Reader.ReadByte();
            }
            else
            {
                this.LayerId = Reader.ReadInt();
            }
            this.CellsCount = Reader.ReadShort();
            int cellsCount = this.CellsCount;
            for (int i = 0; i < cellsCount; i++)
            {
                Cell item = new Cell();
                item.Init(Reader, MapVersion);
                this.Cells.Add(item);
            }
        }

        public void Write(BigEndianWriter writer, int mapVersion)
        {
            if (mapVersion >= 9)
            {
                writer.WriteByte((byte)LayerId);
            }
            else
            {
                writer.WriteInt((byte)LayerId);
   
            }
            writer.WriteShort((short)Cells.Count);
            int error = 0;
            foreach (var item in Cells)
            {

                    item.Write(writer, mapVersion);
                
            }
        }

        // Fields
        public List<Cell> Cells = new List<Cell>();
        public int CellsCount;
        public int LayerId;
    }
}
