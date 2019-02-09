


















// Generated on 01/12/2017 03:53:08
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Types
{

public class GoldItem : Item
{

public const short Id = 123;
public override short TypeId
{
    get { return Id; }
}

public uint sum;
        

public GoldItem()
{
}

public GoldItem(uint sum)
        {
            this.sum = sum;
        }
        

public override void Serialize(IDataWriter writer)
{

base.Serialize(writer);
            writer.WriteVarInt((int)sum);
            

}

public override void Deserialize(IDataReader reader)
{

base.Deserialize(reader);
            sum = reader.ReadVarUhInt();
            if (sum < 0)
                throw new System.Exception("Forbidden value on sum = " + sum + ", it doesn't respect the following condition : sum < 0");
            

}


}


}