


















// Generated on 01/12/2017 03:52:54
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class CharacterExperienceGainMessage : NetworkMessage
{

public const uint Id = 6321;
public uint MessageId
{
    get { return Id; }
}

public double experienceCharacter;
        public double experienceMount;
        public double experienceGuild;
        public double experienceIncarnation;
        

public CharacterExperienceGainMessage()
{
}

public CharacterExperienceGainMessage(double experienceCharacter, double experienceMount, double experienceGuild, double experienceIncarnation)
        {
            this.experienceCharacter = experienceCharacter;
            this.experienceMount = experienceMount;
            this.experienceGuild = experienceGuild;
            this.experienceIncarnation = experienceIncarnation;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteVarLong(experienceCharacter);
            writer.WriteVarLong(experienceMount);
            writer.WriteVarLong(experienceGuild);
            writer.WriteVarLong(experienceIncarnation);
            

}

public void Deserialize(IDataReader reader)
{

experienceCharacter = reader.ReadVarUhLong();
            if (experienceCharacter < 0 || experienceCharacter > 9.007199254740992E15)
                throw new System.Exception("Forbidden value on experienceCharacter = " + experienceCharacter + ", it doesn't respect the following condition : experienceCharacter < 0 || experienceCharacter > 9.007199254740992E15");
            experienceMount = reader.ReadVarUhLong();
            if (experienceMount < 0 || experienceMount > 9.007199254740992E15)
                throw new System.Exception("Forbidden value on experienceMount = " + experienceMount + ", it doesn't respect the following condition : experienceMount < 0 || experienceMount > 9.007199254740992E15");
            experienceGuild = reader.ReadVarUhLong();
            if (experienceGuild < 0 || experienceGuild > 9.007199254740992E15)
                throw new System.Exception("Forbidden value on experienceGuild = " + experienceGuild + ", it doesn't respect the following condition : experienceGuild < 0 || experienceGuild > 9.007199254740992E15");
            experienceIncarnation = reader.ReadVarUhLong();
            if (experienceIncarnation < 0 || experienceIncarnation > 9.007199254740992E15)
                throw new System.Exception("Forbidden value on experienceIncarnation = " + experienceIncarnation + ", it doesn't respect the following condition : experienceIncarnation < 0 || experienceIncarnation > 9.007199254740992E15");
            

}


}


}