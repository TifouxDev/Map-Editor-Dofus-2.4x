


















// Generated on 01/12/2017 03:53:03
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class ExchangeRequestMessage : NetworkMessage
{

public const uint Id = 5505;
public uint MessageId
{
    get { return Id; }
}

public sbyte exchangeType;
        

public ExchangeRequestMessage()
{
}

public ExchangeRequestMessage(sbyte exchangeType)
        {
            this.exchangeType = exchangeType;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteSByte(exchangeType);
            

}

public void Deserialize(IDataReader reader)
{

exchangeType = reader.ReadSByte();
            

}


}


}