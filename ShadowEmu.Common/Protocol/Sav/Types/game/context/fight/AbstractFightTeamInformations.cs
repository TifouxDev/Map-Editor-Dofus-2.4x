


















// Generated on 07/24/2016 18:36:06
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Types
{

public class AbstractFightTeamInformations : NetworkType
{

public const short Id = 116;
public virtual short TypeId
{
    get { return Id; }
}

public sbyte teamId;
        public double leaderId;
        public sbyte teamSide;
        public sbyte teamTypeId;
        public sbyte nbWaves;
        

public AbstractFightTeamInformations()
{
}

public AbstractFightTeamInformations(sbyte teamId, double leaderId, sbyte teamSide, sbyte teamTypeId, sbyte nbWaves)
        {
            this.teamId = teamId;
            this.leaderId = leaderId;
            this.teamSide = teamSide;
            this.teamTypeId = teamTypeId;
            this.nbWaves = nbWaves;
        }
        

public virtual void Serialize(IDataWriter writer)
{

writer.WriteSByte(teamId);
            writer.WriteDouble(leaderId);
            writer.WriteSByte(teamSide);
            writer.WriteSByte(teamTypeId);
            writer.WriteSByte(nbWaves);
            

}

public virtual void Deserialize(IDataReader reader)
{

teamId = reader.ReadSByte();
            if (teamId < 0)
                throw new System.Exception("Forbidden value on teamId = " + teamId + ", it doesn't respect the following condition : teamId < 0");
            leaderId = reader.ReadDouble();
            if (leaderId < -9.007199254740992E15 || leaderId > 9.007199254740992E15)
                throw new System.Exception("Forbidden value on leaderId = " + leaderId + ", it doesn't respect the following condition : leaderId < -9.007199254740992E15 || leaderId > 9.007199254740992E15");
            teamSide = reader.ReadSByte();
            teamTypeId = reader.ReadSByte();
            if (teamTypeId < 0)
                throw new System.Exception("Forbidden value on teamTypeId = " + teamTypeId + ", it doesn't respect the following condition : teamTypeId < 0");
            nbWaves = reader.ReadSByte();
            if (nbWaves < 0)
                throw new System.Exception("Forbidden value on nbWaves = " + nbWaves + ", it doesn't respect the following condition : nbWaves < 0");
            

}


}


}