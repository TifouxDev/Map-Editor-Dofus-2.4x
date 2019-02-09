


















// Generated on 01/12/2017 03:53:08
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Types
{

public class PartyMemberArenaInformations : PartyMemberInformations
{

public const short Id = 391;
public override short TypeId
{
    get { return Id; }
}

public uint rank;
        

public PartyMemberArenaInformations()
{
}

public PartyMemberArenaInformations(double id, string name, byte level, Types.EntityLook entityLook, byte breed, bool sex, uint lifePoints, uint maxLifePoints, uint prospecting, byte regenRate, uint initiative, sbyte alignmentSide, short worldX, short worldY, int mapId, uint subAreaId, Types.PlayerStatus status, Types.PartyCompanionMemberInformations[] companions, uint rank)
         : base(id, name, level, entityLook, breed, sex, lifePoints, maxLifePoints, prospecting, regenRate, initiative, alignmentSide, worldX, worldY, mapId, subAreaId, status, companions)
        {
            this.rank = rank;
        }
        

public override void Serialize(IDataWriter writer)
{

base.Serialize(writer);
            writer.WriteVarShort((int)rank);
            

}

public override void Deserialize(IDataReader reader)
{

base.Deserialize(reader);
            rank = reader.ReadVarUhShort();
            if (rank < 0 || rank > 20000)
                throw new System.Exception("Forbidden value on rank = " + rank + ", it doesn't respect the following condition : rank < 0 || rank > 20000");
            

}


}


}