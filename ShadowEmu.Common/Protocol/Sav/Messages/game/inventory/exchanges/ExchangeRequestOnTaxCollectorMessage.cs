


















// Generated on 07/24/2016 18:36:00
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class ExchangeRequestOnTaxCollectorMessage : NetworkMessage
{

public const uint Id = 5779;
public uint MessageId
{
    get { return Id; }
}

public int taxCollectorId;
        

public ExchangeRequestOnTaxCollectorMessage()
{
}

public ExchangeRequestOnTaxCollectorMessage(int taxCollectorId)
        {
            this.taxCollectorId = taxCollectorId;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteInt(taxCollectorId);
            

}

public void Deserialize(IDataReader reader)
{

taxCollectorId = reader.ReadInt();
            

}


}


}