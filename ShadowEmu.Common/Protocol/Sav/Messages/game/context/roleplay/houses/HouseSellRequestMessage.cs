


















// Generated on 07/24/2016 18:35:52
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class HouseSellRequestMessage : NetworkMessage
{

public const uint Id = 5697;
public uint MessageId
{
    get { return Id; }
}

public uint amount;
        public bool forSale;
        

public HouseSellRequestMessage()
{
}

public HouseSellRequestMessage(uint amount, bool forSale)
        {
            this.amount = amount;
            this.forSale = forSale;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteVarInt((int)amount);
            writer.WriteBoolean(forSale);
            

}

public void Deserialize(IDataReader reader)
{

amount = reader.ReadVarUhInt();
            if (amount < 0)
                throw new System.Exception("Forbidden value on amount = " + amount + ", it doesn't respect the following condition : amount < 0");
            forSale = reader.ReadBoolean();
            

}


}


}