


















// Generated on 07/24/2016 18:36:00
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class ExchangeOnHumanVendorRequestMessage : NetworkMessage
{

public const uint Id = 5772;
public uint MessageId
{
    get { return Id; }
}

public double humanVendorId;
        public uint humanVendorCell;
        

public ExchangeOnHumanVendorRequestMessage()
{
}

public ExchangeOnHumanVendorRequestMessage(double humanVendorId, uint humanVendorCell)
        {
            this.humanVendorId = humanVendorId;
            this.humanVendorCell = humanVendorCell;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteVarLong(humanVendorId);
            writer.WriteVarShort((int)humanVendorCell);
            

}

public void Deserialize(IDataReader reader)
{

humanVendorId = reader.ReadVarUhLong();
            if (humanVendorId < 0 || humanVendorId > 9.007199254740992E15)
                throw new System.Exception("Forbidden value on humanVendorId = " + humanVendorId + ", it doesn't respect the following condition : humanVendorId < 0 || humanVendorId > 9.007199254740992E15");
            humanVendorCell = reader.ReadVarUhShort();
            if (humanVendorCell < 0 || humanVendorCell > 559)
                throw new System.Exception("Forbidden value on humanVendorCell = " + humanVendorCell + ", it doesn't respect the following condition : humanVendorCell < 0 || humanVendorCell > 559");
            

}


}


}