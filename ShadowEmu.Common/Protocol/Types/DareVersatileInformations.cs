


















// Generated on 01/12/2017 03:53:08
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Types
{

public class DareVersatileInformations : NetworkType
{

public const short Id = 504;
public virtual short TypeId
{
    get { return Id; }
}

public double dareId;
        public int countEntrants;
        public int countWinners;
        

public DareVersatileInformations()
{
}

public DareVersatileInformations(double dareId, int countEntrants, int countWinners)
        {
            this.dareId = dareId;
            this.countEntrants = countEntrants;
            this.countWinners = countWinners;
        }
        

public virtual void Serialize(IDataWriter writer)
{

writer.WriteDouble(dareId);
            writer.WriteInt(countEntrants);
            writer.WriteInt(countWinners);
            

}

public virtual void Deserialize(IDataReader reader)
{

dareId = reader.ReadDouble();
            if (dareId < 0 || dareId > 9.007199254740992E15)
                throw new System.Exception("Forbidden value on dareId = " + dareId + ", it doesn't respect the following condition : dareId < 0 || dareId > 9.007199254740992E15");
            countEntrants = reader.ReadInt();
            if (countEntrants < 0)
                throw new System.Exception("Forbidden value on countEntrants = " + countEntrants + ", it doesn't respect the following condition : countEntrants < 0");
            countWinners = reader.ReadInt();
            if (countWinners < 0)
                throw new System.Exception("Forbidden value on countWinners = " + countWinners + ", it doesn't respect the following condition : countWinners < 0");
            

}


}


}