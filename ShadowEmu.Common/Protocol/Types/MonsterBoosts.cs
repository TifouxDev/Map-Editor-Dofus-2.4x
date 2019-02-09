


















// Generated on 01/12/2017 03:53:08
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Types
{

public class MonsterBoosts : NetworkType
{

public const short Id = 497;
public virtual short TypeId
{
    get { return Id; }
}

public uint id;
        public uint xpBoost;
        public uint dropBoost;
        

public MonsterBoosts()
{
}

public MonsterBoosts(uint id, uint xpBoost, uint dropBoost)
        {
            this.id = id;
            this.xpBoost = xpBoost;
            this.dropBoost = dropBoost;
        }
        

public virtual void Serialize(IDataWriter writer)
{

writer.WriteVarInt((int)id);
            writer.WriteVarShort((int)xpBoost);
            writer.WriteVarShort((int)dropBoost);
            

}

public virtual void Deserialize(IDataReader reader)
{

id = reader.ReadVarUhInt();
            if (id < 0)
                throw new System.Exception("Forbidden value on id = " + id + ", it doesn't respect the following condition : id < 0");
            xpBoost = reader.ReadVarUhShort();
            if (xpBoost < 0)
                throw new System.Exception("Forbidden value on xpBoost = " + xpBoost + ", it doesn't respect the following condition : xpBoost < 0");
            dropBoost = reader.ReadVarUhShort();
            if (dropBoost < 0)
                throw new System.Exception("Forbidden value on dropBoost = " + dropBoost + ", it doesn't respect the following condition : dropBoost < 0");
            

}


}


}