


















// Generated on 01/12/2017 03:52:56
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class RefreshCharacterStatsMessage : NetworkMessage
{

public const uint Id = 6699;
public uint MessageId
{
    get { return Id; }
}

public double fighterId;
        public Types.GameFightMinimalStats stats;
        

public RefreshCharacterStatsMessage()
{
}

public RefreshCharacterStatsMessage(double fighterId, Types.GameFightMinimalStats stats)
        {
            this.fighterId = fighterId;
            this.stats = stats;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteDouble(fighterId);
            stats.Serialize(writer);
            

}

public void Deserialize(IDataReader reader)
{

fighterId = reader.ReadDouble();
            if (fighterId < -9.007199254740992E15 || fighterId > 9.007199254740992E15)
                throw new System.Exception("Forbidden value on fighterId = " + fighterId + ", it doesn't respect the following condition : fighterId < -9.007199254740992E15 || fighterId > 9.007199254740992E15");
            stats = new Types.GameFightMinimalStats();
            stats.Deserialize(reader);
            

}


}


}