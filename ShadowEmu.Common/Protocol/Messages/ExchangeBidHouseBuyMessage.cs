


















// Generated on 01/12/2017 03:53:02
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class ExchangeBidHouseBuyMessage : NetworkMessage
{

public const uint Id = 5804;
public uint MessageId
{
    get { return Id; }
}

public uint uid;
        public uint qty;
        public uint price;
        

public ExchangeBidHouseBuyMessage()
{
}

public ExchangeBidHouseBuyMessage(uint uid, uint qty, uint price)
        {
            this.uid = uid;
            this.qty = qty;
            this.price = price;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteVarInt((int)uid);
            writer.WriteVarInt((int)qty);
            writer.WriteVarInt((int)price);
            

}

public void Deserialize(IDataReader reader)
{

uid = reader.ReadVarUhInt();
            if (uid < 0)
                throw new System.Exception("Forbidden value on uid = " + uid + ", it doesn't respect the following condition : uid < 0");
            qty = reader.ReadVarUhInt();
            if (qty < 0)
                throw new System.Exception("Forbidden value on qty = " + qty + ", it doesn't respect the following condition : qty < 0");
            price = reader.ReadVarUhInt();
            if (price < 0)
                throw new System.Exception("Forbidden value on price = " + price + ", it doesn't respect the following condition : price < 0");
            

}


}


}