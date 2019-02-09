


















// Generated on 01/12/2017 03:53:04
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class ObtainedItemMessage : NetworkMessage
{

public const uint Id = 6519;
public uint MessageId
{
    get { return Id; }
}

public uint genericId;
        public uint baseQuantity;
        

public ObtainedItemMessage()
{
}

public ObtainedItemMessage(uint genericId, uint baseQuantity)
        {
            this.genericId = genericId;
            this.baseQuantity = baseQuantity;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteVarShort((int)genericId);
            writer.WriteVarInt((int)baseQuantity);
            

}

public void Deserialize(IDataReader reader)
{

genericId = reader.ReadVarUhShort();
            if (genericId < 0)
                throw new System.Exception("Forbidden value on genericId = " + genericId + ", it doesn't respect the following condition : genericId < 0");
            baseQuantity = reader.ReadVarUhInt();
            if (baseQuantity < 0)
                throw new System.Exception("Forbidden value on baseQuantity = " + baseQuantity + ", it doesn't respect the following condition : baseQuantity < 0");
            

}


}


}