


















// Generated on 07/24/2016 18:35:59
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class ExchangeBidHouseGenericItemRemovedMessage : NetworkMessage
{

public const uint Id = 5948;
public uint MessageId
{
    get { return Id; }
}

public uint objGenericId;
        

public ExchangeBidHouseGenericItemRemovedMessage()
{
}

public ExchangeBidHouseGenericItemRemovedMessage(uint objGenericId)
        {
            this.objGenericId = objGenericId;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteVarShort((int)objGenericId);
            

}

public void Deserialize(IDataReader reader)
{

objGenericId = reader.ReadVarUhShort();
            if (objGenericId < 0)
                throw new System.Exception("Forbidden value on objGenericId = " + objGenericId + ", it doesn't respect the following condition : objGenericId < 0");
            

}


}


}