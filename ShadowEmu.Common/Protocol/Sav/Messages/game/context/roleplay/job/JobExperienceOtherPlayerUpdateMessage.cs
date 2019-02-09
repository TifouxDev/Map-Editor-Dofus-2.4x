


















// Generated on 07/24/2016 18:35:52
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class JobExperienceOtherPlayerUpdateMessage : JobExperienceUpdateMessage
{

public const uint Id = 6599;
public uint MessageId
{
    get { return Id; }
}

public double playerId;
        

public JobExperienceOtherPlayerUpdateMessage()
{
}

public JobExperienceOtherPlayerUpdateMessage(Types.JobExperience experiencesUpdate, double playerId)
         : base(experiencesUpdate)
        {
            this.playerId = playerId;
        }
        

public void Serialize(IDataWriter writer)
{

base.Serialize(writer);
            writer.WriteVarLong(playerId);
            

}

public void Deserialize(IDataReader reader)
{

base.Deserialize(reader);
            playerId = reader.ReadVarUhLong();
            if (playerId < 0 || playerId > 9.007199254740992E15)
                throw new System.Exception("Forbidden value on playerId = " + playerId + ", it doesn't respect the following condition : playerId < 0 || playerId > 9.007199254740992E15");
            

}


}


}