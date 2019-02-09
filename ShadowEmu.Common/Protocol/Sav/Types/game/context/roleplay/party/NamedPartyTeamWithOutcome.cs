


















// Generated on 07/24/2016 18:36:07
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Types
{

public class NamedPartyTeamWithOutcome : NetworkType
{

public const short Id = 470;
public virtual short TypeId
{
    get { return Id; }
}

public Types.NamedPartyTeam team;
        public uint outcome;
        

public NamedPartyTeamWithOutcome()
{
}

public NamedPartyTeamWithOutcome(Types.NamedPartyTeam team, uint outcome)
        {
            this.team = team;
            this.outcome = outcome;
        }
        

public virtual void Serialize(IDataWriter writer)
{

team.Serialize(writer);
            writer.WriteVarShort((int)outcome);
            

}

public virtual void Deserialize(IDataReader reader)
{

team = new Types.NamedPartyTeam();
            team.Deserialize(reader);
            outcome = reader.ReadVarUhShort();
            if (outcome < 0)
                throw new System.Exception("Forbidden value on outcome = " + outcome + ", it doesn't respect the following condition : outcome < 0");
            

}


}


}