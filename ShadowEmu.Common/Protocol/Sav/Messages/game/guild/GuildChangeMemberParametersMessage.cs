


















// Generated on 07/24/2016 18:35:56
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class GuildChangeMemberParametersMessage : NetworkMessage
{

public const uint Id = 5549;
public uint MessageId
{
    get { return Id; }
}

public double memberId;
        public uint rank;
        public sbyte experienceGivenPercent;
        public uint rights;
        

public GuildChangeMemberParametersMessage()
{
}

public GuildChangeMemberParametersMessage(double memberId, uint rank, sbyte experienceGivenPercent, uint rights)
        {
            this.memberId = memberId;
            this.rank = rank;
            this.experienceGivenPercent = experienceGivenPercent;
            this.rights = rights;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteVarLong(memberId);
            writer.WriteVarShort((int)rank);
            writer.WriteSByte(experienceGivenPercent);
            writer.WriteVarInt((int)rights);
            

}

public void Deserialize(IDataReader reader)
{

memberId = reader.ReadVarUhLong();
            if (memberId < 0 || memberId > 9.007199254740992E15)
                throw new System.Exception("Forbidden value on memberId = " + memberId + ", it doesn't respect the following condition : memberId < 0 || memberId > 9.007199254740992E15");
            rank = reader.ReadVarUhShort();
            if (rank < 0)
                throw new System.Exception("Forbidden value on rank = " + rank + ", it doesn't respect the following condition : rank < 0");
            experienceGivenPercent = reader.ReadSByte();
            if (experienceGivenPercent < 0 || experienceGivenPercent > 100)
                throw new System.Exception("Forbidden value on experienceGivenPercent = " + experienceGivenPercent + ", it doesn't respect the following condition : experienceGivenPercent < 0 || experienceGivenPercent > 100");
            rights = reader.ReadVarUhInt();
            if (rights < 0)
                throw new System.Exception("Forbidden value on rights = " + rights + ", it doesn't respect the following condition : rights < 0");
            

}


}


}