


















// Generated on 01/12/2017 03:53:08
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Types
{

public class ArenaRankInfos : NetworkType
{

public const short Id = 499;
public virtual short TypeId
{
    get { return Id; }
}

public uint rank;
        public uint bestRank;
        public uint victoryCount;
        public uint fightcount;
        

public ArenaRankInfos()
{
}

public ArenaRankInfos(uint rank, uint bestRank, uint victoryCount, uint fightcount)
        {
            this.rank = rank;
            this.bestRank = bestRank;
            this.victoryCount = victoryCount;
            this.fightcount = fightcount;
        }
        

public virtual void Serialize(IDataWriter writer)
{

writer.WriteVarShort((int)rank);
            writer.WriteVarShort((int)bestRank);
            writer.WriteVarShort((int)victoryCount);
            writer.WriteVarShort((int)fightcount);
            

}

public virtual void Deserialize(IDataReader reader)
{

rank = reader.ReadVarUhShort();
            if (rank < 0 || rank > 20000)
                throw new System.Exception("Forbidden value on rank = " + rank + ", it doesn't respect the following condition : rank < 0 || rank > 20000");
            bestRank = reader.ReadVarUhShort();
            if (bestRank < 0 || bestRank > 20000)
                throw new System.Exception("Forbidden value on bestRank = " + bestRank + ", it doesn't respect the following condition : bestRank < 0 || bestRank > 20000");
            victoryCount = reader.ReadVarUhShort();
            if (victoryCount < 0)
                throw new System.Exception("Forbidden value on victoryCount = " + victoryCount + ", it doesn't respect the following condition : victoryCount < 0");
            fightcount = reader.ReadVarUhShort();
            if (fightcount < 0)
                throw new System.Exception("Forbidden value on fightcount = " + fightcount + ", it doesn't respect the following condition : fightcount < 0");
            

}


}


}