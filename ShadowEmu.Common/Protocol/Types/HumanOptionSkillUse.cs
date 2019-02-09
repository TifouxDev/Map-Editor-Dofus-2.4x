


















// Generated on 01/12/2017 03:53:08
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Types
{

public class HumanOptionSkillUse : HumanOption
{

public const short Id = 495;
public override short TypeId
{
    get { return Id; }
}

public uint elementId;
        public uint skillId;
        public double skillEndTime;
        

public HumanOptionSkillUse()
{
}

public HumanOptionSkillUse(uint elementId, uint skillId, double skillEndTime)
        {
            this.elementId = elementId;
            this.skillId = skillId;
            this.skillEndTime = skillEndTime;
        }
        

public override void Serialize(IDataWriter writer)
{

base.Serialize(writer);
            writer.WriteVarInt((int)elementId);
            writer.WriteVarShort((int)skillId);
            writer.WriteDouble(skillEndTime);
            

}

public override void Deserialize(IDataReader reader)
{

base.Deserialize(reader);
            elementId = reader.ReadVarUhInt();
            if (elementId < 0)
                throw new System.Exception("Forbidden value on elementId = " + elementId + ", it doesn't respect the following condition : elementId < 0");
            skillId = reader.ReadVarUhShort();
            if (skillId < 0)
                throw new System.Exception("Forbidden value on skillId = " + skillId + ", it doesn't respect the following condition : skillId < 0");
            skillEndTime = reader.ReadDouble();
            if (skillEndTime < -9.007199254740992E15 || skillEndTime > 9.007199254740992E15)
                throw new System.Exception("Forbidden value on skillEndTime = " + skillEndTime + ", it doesn't respect the following condition : skillEndTime < -9.007199254740992E15 || skillEndTime > 9.007199254740992E15");
            

}


}


}