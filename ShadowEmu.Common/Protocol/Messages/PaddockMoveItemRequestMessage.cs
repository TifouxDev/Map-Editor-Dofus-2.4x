


















// Generated on 01/12/2017 03:52:56
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class PaddockMoveItemRequestMessage : NetworkMessage
{

public const uint Id = 6052;
public uint MessageId
{
    get { return Id; }
}

public uint oldCellId;
        public uint newCellId;
        

public PaddockMoveItemRequestMessage()
{
}

public PaddockMoveItemRequestMessage(uint oldCellId, uint newCellId)
        {
            this.oldCellId = oldCellId;
            this.newCellId = newCellId;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteVarShort((int)oldCellId);
            writer.WriteVarShort((int)newCellId);
            

}

public void Deserialize(IDataReader reader)
{

oldCellId = reader.ReadVarUhShort();
            if (oldCellId < 0 || oldCellId > 559)
                throw new System.Exception("Forbidden value on oldCellId = " + oldCellId + ", it doesn't respect the following condition : oldCellId < 0 || oldCellId > 559");
            newCellId = reader.ReadVarUhShort();
            if (newCellId < 0 || newCellId > 559)
                throw new System.Exception("Forbidden value on newCellId = " + newCellId + ", it doesn't respect the following condition : newCellId < 0 || newCellId > 559");
            

}


}


}