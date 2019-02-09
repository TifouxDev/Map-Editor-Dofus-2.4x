


















// Generated on 01/12/2017 03:53:02
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class ExchangeCraftPaymentModifiedMessage : NetworkMessage
{

public const uint Id = 6578;
public uint MessageId
{
    get { return Id; }
}

public uint goldSum;
        

public ExchangeCraftPaymentModifiedMessage()
{
}

public ExchangeCraftPaymentModifiedMessage(uint goldSum)
        {
            this.goldSum = goldSum;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteVarInt((int)goldSum);
            

}

public void Deserialize(IDataReader reader)
{

goldSum = reader.ReadVarUhInt();
            if (goldSum < 0)
                throw new System.Exception("Forbidden value on goldSum = " + goldSum + ", it doesn't respect the following condition : goldSum < 0");
            

}


}


}