


















// Generated on 07/24/2016 18:35:43
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class DebugHighlightCellsMessage : NetworkMessage
{

public const uint Id = 2001;
public uint MessageId
{
    get { return Id; }
}

public int color;
        public uint[] cells;
        

public DebugHighlightCellsMessage()
{
}

public DebugHighlightCellsMessage(int color, uint[] cells)
        {
            this.color = color;
            this.cells = cells;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteInt(color);
            writer.WriteUShort((ushort)cells.Length);
            foreach (var entry in cells)
            {
                 writer.WriteVarShort((int)entry);
            }
            

}

public void Deserialize(IDataReader reader)
{

color = reader.ReadInt();
            var limit = reader.ReadUShort();
            cells = new uint[limit];
            for (int i = 0; i < limit; i++)
            {
                 cells[i] = reader.ReadVarUhShort();
            }
            

}


}


}