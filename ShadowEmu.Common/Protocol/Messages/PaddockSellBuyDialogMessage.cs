


















// Generated on 01/12/2017 03:52:58
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class PaddockSellBuyDialogMessage : NetworkMessage
{

public const uint Id = 6018;
public uint MessageId
{
    get { return Id; }
}

public bool bsell;
        public uint ownerId;
        public uint price;
        

public PaddockSellBuyDialogMessage()
{
}

public PaddockSellBuyDialogMessage(bool bsell, uint ownerId, uint price)
        {
            this.bsell = bsell;
            this.ownerId = ownerId;
            this.price = price;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteBoolean(bsell);
            writer.WriteVarInt((int)ownerId);
            writer.WriteVarInt((int)price);
            

}

public void Deserialize(IDataReader reader)
{

bsell = reader.ReadBoolean();
            ownerId = reader.ReadVarUhInt();
            if (ownerId < 0)
                throw new System.Exception("Forbidden value on ownerId = " + ownerId + ", it doesn't respect the following condition : ownerId < 0");
            price = reader.ReadVarUhInt();
            if (price < 0)
                throw new System.Exception("Forbidden value on price = " + price + ", it doesn't respect the following condition : price < 0");
            

}


}


}