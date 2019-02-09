


















// Generated on 01/12/2017 03:53:03
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class ExchangeReplyTaxVendorMessage : NetworkMessage
{

public const uint Id = 5787;
public uint MessageId
{
    get { return Id; }
}

public uint objectValue;
        public uint totalTaxValue;
        

public ExchangeReplyTaxVendorMessage()
{
}

public ExchangeReplyTaxVendorMessage(uint objectValue, uint totalTaxValue)
        {
            this.objectValue = objectValue;
            this.totalTaxValue = totalTaxValue;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteVarInt((int)objectValue);
            writer.WriteVarInt((int)totalTaxValue);
            

}

public void Deserialize(IDataReader reader)
{

objectValue = reader.ReadVarUhInt();
            if (objectValue < 0)
                throw new System.Exception("Forbidden value on objectValue = " + objectValue + ", it doesn't respect the following condition : objectValue < 0");
            totalTaxValue = reader.ReadVarUhInt();
            if (totalTaxValue < 0)
                throw new System.Exception("Forbidden value on totalTaxValue = " + totalTaxValue + ", it doesn't respect the following condition : totalTaxValue < 0");
            

}


}


}