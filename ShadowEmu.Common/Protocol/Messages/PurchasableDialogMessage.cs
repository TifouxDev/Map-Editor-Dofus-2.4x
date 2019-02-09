


















// Generated on 01/12/2017 03:52:59
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class PurchasableDialogMessage : NetworkMessage
{

public const uint Id = 5739;
public uint MessageId
{
    get { return Id; }
}

public bool buyOrSell;
        public uint purchasableId;
        public uint price;
        

public PurchasableDialogMessage()
{
}

public PurchasableDialogMessage(bool buyOrSell, uint purchasableId, uint price)
        {
            this.buyOrSell = buyOrSell;
            this.purchasableId = purchasableId;
            this.price = price;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteBoolean(buyOrSell);
            writer.WriteVarInt((int)purchasableId);
            writer.WriteVarInt((int)price);
            

}

public void Deserialize(IDataReader reader)
{

buyOrSell = reader.ReadBoolean();
            purchasableId = reader.ReadVarUhInt();
            if (purchasableId < 0)
                throw new System.Exception("Forbidden value on purchasableId = " + purchasableId + ", it doesn't respect the following condition : purchasableId < 0");
            price = reader.ReadVarUhInt();
            if (price < 0)
                throw new System.Exception("Forbidden value on price = " + price + ", it doesn't respect the following condition : price < 0");
            

}


}


}