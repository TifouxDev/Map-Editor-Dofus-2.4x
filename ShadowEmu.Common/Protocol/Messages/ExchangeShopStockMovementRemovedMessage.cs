


















// Generated on 01/12/2017 03:53:03
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class ExchangeShopStockMovementRemovedMessage : NetworkMessage
{

public const uint Id = 5907;
public uint MessageId
{
    get { return Id; }
}

public uint objectId;
        

public ExchangeShopStockMovementRemovedMessage()
{
}

public ExchangeShopStockMovementRemovedMessage(uint objectId)
        {
            this.objectId = objectId;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteVarInt((int)objectId);
            

}

public void Deserialize(IDataReader reader)
{

objectId = reader.ReadVarUhInt();
            if (objectId < 0)
                throw new System.Exception("Forbidden value on objectId = " + objectId + ", it doesn't respect the following condition : objectId < 0");
            

}


}


}