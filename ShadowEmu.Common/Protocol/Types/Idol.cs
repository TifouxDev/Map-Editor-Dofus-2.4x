


















// Generated on 01/12/2017 03:53:09
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Types
{

public class Idol : NetworkType
{

public const short Id = 489;
public virtual short TypeId
{
    get { return Id; }
}

public uint id;
        public uint xpBonusPercent;
        public uint dropBonusPercent;
        

public Idol()
{
}

public Idol(uint id, uint xpBonusPercent, uint dropBonusPercent)
        {
            this.id = id;
            this.xpBonusPercent = xpBonusPercent;
            this.dropBonusPercent = dropBonusPercent;
        }
        

public virtual void Serialize(IDataWriter writer)
{

writer.WriteVarShort((int)id);
            writer.WriteVarShort((int)xpBonusPercent);
            writer.WriteVarShort((int)dropBonusPercent);
            

}

public virtual void Deserialize(IDataReader reader)
{

id = reader.ReadVarUhShort();
            if (id < 0)
                throw new System.Exception("Forbidden value on id = " + id + ", it doesn't respect the following condition : id < 0");
            xpBonusPercent = reader.ReadVarUhShort();
            if (xpBonusPercent < 0)
                throw new System.Exception("Forbidden value on xpBonusPercent = " + xpBonusPercent + ", it doesn't respect the following condition : xpBonusPercent < 0");
            dropBonusPercent = reader.ReadVarUhShort();
            if (dropBonusPercent < 0)
                throw new System.Exception("Forbidden value on dropBonusPercent = " + dropBonusPercent + ", it doesn't respect the following condition : dropBonusPercent < 0");
            

}


}


}