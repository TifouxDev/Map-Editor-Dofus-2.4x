


















// Generated on 01/12/2017 03:53:00
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class DareRewardWonMessage : NetworkMessage
{

public const uint Id = 6678;
public uint MessageId
{
    get { return Id; }
}

public Types.DareReward reward;
        

public DareRewardWonMessage()
{
}

public DareRewardWonMessage(Types.DareReward reward)
        {
            this.reward = reward;
        }
        

public void Serialize(IDataWriter writer)
{

reward.Serialize(writer);
            

}

public void Deserialize(IDataReader reader)
{

reward = new Types.DareReward();
            reward.Deserialize(reader);
            

}


}


}