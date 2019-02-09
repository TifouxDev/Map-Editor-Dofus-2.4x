


















// Generated on 01/12/2017 03:52:56
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class PaddockSellRequestMessage : NetworkMessage
{

public const uint Id = 5953;
public uint MessageId
{
    get { return Id; }
}

public uint price;
        public bool forSale;
        

public PaddockSellRequestMessage()
{
}

public PaddockSellRequestMessage(uint price, bool forSale)
        {
            this.price = price;
            this.forSale = forSale;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteVarInt((int)price);
            writer.WriteBoolean(forSale);
            

}

public void Deserialize(IDataReader reader)
{

price = reader.ReadVarUhInt();
            if (price < 0)
                throw new System.Exception("Forbidden value on price = " + price + ", it doesn't respect the following condition : price < 0");
            forSale = reader.ReadBoolean();
            

}


}


}