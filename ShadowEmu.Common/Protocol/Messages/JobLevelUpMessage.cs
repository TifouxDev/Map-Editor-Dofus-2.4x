


















// Generated on 01/12/2017 03:52:58
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class JobLevelUpMessage : NetworkMessage
{

public const uint Id = 5656;
public uint MessageId
{
    get { return Id; }
}

public byte newLevel;
        public Types.JobDescription jobsDescription;
        

public JobLevelUpMessage()
{
}

public JobLevelUpMessage(byte newLevel, Types.JobDescription jobsDescription)
        {
            this.newLevel = newLevel;
            this.jobsDescription = jobsDescription;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteByte(newLevel);
            jobsDescription.Serialize(writer);
            

}

public void Deserialize(IDataReader reader)
{

newLevel = reader.ReadByte();
            if (newLevel < 0 || newLevel > 255)
                throw new System.Exception("Forbidden value on newLevel = " + newLevel + ", it doesn't respect the following condition : newLevel < 0 || newLevel > 255");
            jobsDescription = new Types.JobDescription();
            jobsDescription.Deserialize(reader);
            

}


}


}