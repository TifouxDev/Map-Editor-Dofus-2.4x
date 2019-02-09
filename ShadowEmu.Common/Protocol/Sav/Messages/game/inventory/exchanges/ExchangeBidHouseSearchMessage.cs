


















// Generated on 07/24/2016 18:35:59
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class ExchangeBidHouseSearchMessage : NetworkMessage
{

public const uint Id = 5806;
public uint MessageId
{
    get { return Id; }
}

public uint type;
        public uint genId;
        

public ExchangeBidHouseSearchMessage()
{
}

public ExchangeBidHouseSearchMessage(uint type, uint genId)
        {
            this.type = type;
            this.genId = genId;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteVarInt((int)type);
            writer.WriteVarShort((int)genId);
            

}

public void Deserialize(IDataReader reader)
{

type = reader.ReadVarUhInt();
            if (type < 0)
                throw new System.Exception("Forbidden value on type = " + type + ", it doesn't respect the following condition : type < 0");
            genId = reader.ReadVarUhShort();
            if (genId < 0)
                throw new System.Exception("Forbidden value on genId = " + genId + ", it doesn't respect the following condition : genId < 0");
            

}


}


}