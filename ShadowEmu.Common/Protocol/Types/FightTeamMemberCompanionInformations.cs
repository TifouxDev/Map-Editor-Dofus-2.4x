


















// Generated on 01/12/2017 03:53:07
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Types
{

public class FightTeamMemberCompanionInformations : FightTeamMemberInformations
{

public const short Id = 451;
public override short TypeId
{
    get { return Id; }
}

public sbyte companionId;
        public byte level;
        public double masterId;
        

public FightTeamMemberCompanionInformations()
{
}

public FightTeamMemberCompanionInformations(double id, sbyte companionId, byte level, double masterId)
         : base(id)
        {
            this.companionId = companionId;
            this.level = level;
            this.masterId = masterId;
        }
        

public override void Serialize(IDataWriter writer)
{

base.Serialize(writer);
            writer.WriteSByte(companionId);
            writer.WriteByte(level);
            writer.WriteDouble(masterId);
            

}

public override void Deserialize(IDataReader reader)
{

base.Deserialize(reader);
            companionId = reader.ReadSByte();
            if (companionId < 0)
                throw new System.Exception("Forbidden value on companionId = " + companionId + ", it doesn't respect the following condition : companionId < 0");
            level = reader.ReadByte();
            if (level < 1 || level > 200)
                throw new System.Exception("Forbidden value on level = " + level + ", it doesn't respect the following condition : level < 1 || level > 200");
            masterId = reader.ReadDouble();
            if (masterId < -9.007199254740992E15 || masterId > 9.007199254740992E15)
                throw new System.Exception("Forbidden value on masterId = " + masterId + ", it doesn't respect the following condition : masterId < -9.007199254740992E15 || masterId > 9.007199254740992E15");
            

}


}


}