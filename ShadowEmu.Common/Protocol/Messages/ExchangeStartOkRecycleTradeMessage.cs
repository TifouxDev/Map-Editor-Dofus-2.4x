


















// Generated on 01/12/2017 03:53:03
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class ExchangeStartOkRecycleTradeMessage : NetworkMessage
{

public const uint Id = 6600;
public uint MessageId
{
    get { return Id; }
}

public short percentToPrism;
        public short percentToPlayer;
        

public ExchangeStartOkRecycleTradeMessage()
{
}

public ExchangeStartOkRecycleTradeMessage(short percentToPrism, short percentToPlayer)
        {
            this.percentToPrism = percentToPrism;
            this.percentToPlayer = percentToPlayer;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteShort(percentToPrism);
            writer.WriteShort(percentToPlayer);
            

}

public void Deserialize(IDataReader reader)
{

percentToPrism = reader.ReadShort();
            if (percentToPrism < 0)
                throw new System.Exception("Forbidden value on percentToPrism = " + percentToPrism + ", it doesn't respect the following condition : percentToPrism < 0");
            percentToPlayer = reader.ReadShort();
            if (percentToPlayer < 0)
                throw new System.Exception("Forbidden value on percentToPlayer = " + percentToPlayer + ", it doesn't respect the following condition : percentToPlayer < 0");
            

}


}


}