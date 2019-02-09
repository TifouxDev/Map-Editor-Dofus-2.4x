


















// Generated on 01/12/2017 03:53:06
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Types
{

public class AchievementStartedObjective : AchievementObjective
{

public const short Id = 402;
public override short TypeId
{
    get { return Id; }
}

public uint value;
        

public AchievementStartedObjective()
{
}

public AchievementStartedObjective(uint id, uint maxValue, uint value)
         : base(id, maxValue)
        {
            this.value = value;
        }
        

public override void Serialize(IDataWriter writer)
{

base.Serialize(writer);
            writer.WriteVarShort((int)value);
            

}

public override void Deserialize(IDataReader reader)
{

base.Deserialize(reader);
            value = reader.ReadVarUhShort();
            if (value < 0)
                throw new System.Exception("Forbidden value on value = " + value + ", it doesn't respect the following condition : value < 0");
            

}


}


}