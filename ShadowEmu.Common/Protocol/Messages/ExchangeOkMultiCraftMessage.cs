


















// Generated on 01/12/2017 03:53:02
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class ExchangeOkMultiCraftMessage : NetworkMessage
{

public const uint Id = 5768;
public uint MessageId
{
    get { return Id; }
}

public double initiatorId;
        public double otherId;
        public sbyte role;
        

public ExchangeOkMultiCraftMessage()
{
}

public ExchangeOkMultiCraftMessage(double initiatorId, double otherId, sbyte role)
        {
            this.initiatorId = initiatorId;
            this.otherId = otherId;
            this.role = role;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteVarLong(initiatorId);
            writer.WriteVarLong(otherId);
            writer.WriteSByte(role);
            

}

public void Deserialize(IDataReader reader)
{

initiatorId = reader.ReadVarUhLong();
            if (initiatorId < 0 || initiatorId > 9.007199254740992E15)
                throw new System.Exception("Forbidden value on initiatorId = " + initiatorId + ", it doesn't respect the following condition : initiatorId < 0 || initiatorId > 9.007199254740992E15");
            otherId = reader.ReadVarUhLong();
            if (otherId < 0 || otherId > 9.007199254740992E15)
                throw new System.Exception("Forbidden value on otherId = " + otherId + ", it doesn't respect the following condition : otherId < 0 || otherId > 9.007199254740992E15");
            role = reader.ReadSByte();
            

}


}


}