


















// Generated on 07/24/2016 18:35:59
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class ExchangeBidHouseListMessage : NetworkMessage
{

public const uint Id = 5807;
public uint MessageId
{
    get { return Id; }
}

public uint id;
        

public ExchangeBidHouseListMessage()
{
}

public ExchangeBidHouseListMessage(uint id)
        {
            this.id = id;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteVarShort((int)id);
            

}

public void Deserialize(IDataReader reader)
{

id = reader.ReadVarUhShort();
            if (id < 0)
                throw new System.Exception("Forbidden value on id = " + id + ", it doesn't respect the following condition : id < 0");
            

}


}


}