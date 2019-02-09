


















// Generated on 07/24/2016 18:36:08
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Types
{

public class ObjectItemGenericQuantityPrice : ObjectItemGenericQuantity
{

public const short Id = 494;
public override short TypeId
{
    get { return Id; }
}

public uint price;
        

public ObjectItemGenericQuantityPrice()
{
}

public ObjectItemGenericQuantityPrice(uint objectGID, uint quantity, uint price)
         : base(objectGID, quantity)
        {
            this.price = price;
        }
        

public override void Serialize(IDataWriter writer)
{

base.Serialize(writer);
            writer.WriteVarInt((int)price);
            

}

public override void Deserialize(IDataReader reader)
{

base.Deserialize(reader);
            price = reader.ReadVarUhInt();
            if (price < 0)
                throw new System.Exception("Forbidden value on price = " + price + ", it doesn't respect the following condition : price < 0");
            

}


}


}