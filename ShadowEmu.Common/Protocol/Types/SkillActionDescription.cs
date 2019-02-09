


















// Generated on 01/12/2017 03:53:09
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Types
{

public class SkillActionDescription : NetworkType
{

public const short Id = 102;
public virtual short TypeId
{
    get { return Id; }
}

public uint skillId;
        

public SkillActionDescription()
{
}

public SkillActionDescription(uint skillId)
        {
            this.skillId = skillId;
        }
        

public virtual void Serialize(IDataWriter writer)
{

writer.WriteVarShort((int)skillId);
            

}

public virtual void Deserialize(IDataReader reader)
{

skillId = reader.ReadVarUhShort();
            if (skillId < 0)
                throw new System.Exception("Forbidden value on skillId = " + skillId + ", it doesn't respect the following condition : skillId < 0");
            

}


}


}