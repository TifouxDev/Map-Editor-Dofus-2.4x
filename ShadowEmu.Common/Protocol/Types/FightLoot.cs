


















// Generated on 01/12/2017 03:53:07
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Types
{

public class FightLoot : NetworkType
{

public const short Id = 41;
public virtual short TypeId
{
    get { return Id; }
}

public uint[] objects;
        public uint kamas;
        

public FightLoot()
{
}

public FightLoot(uint[] objects, uint kamas)
        {
            this.objects = objects;
            this.kamas = kamas;
        }
        

public virtual void Serialize(IDataWriter writer)
{

writer.WriteUShort((ushort)objects.Length);
            foreach (var entry in objects)
            {
                 writer.WriteVarShort((int)entry);
            }
            writer.WriteVarInt((int)kamas);
            

}

public virtual void Deserialize(IDataReader reader)
{

var limit = reader.ReadUShort();
            objects = new uint[limit];
            for (int i = 0; i < limit; i++)
            {
                 objects[i] = reader.ReadVarUhShort();
            }
            kamas = reader.ReadVarUhInt();
            if (kamas < 0)
                throw new System.Exception("Forbidden value on kamas = " + kamas + ", it doesn't respect the following condition : kamas < 0");
            

}


}


}