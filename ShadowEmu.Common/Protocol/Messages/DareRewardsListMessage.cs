


















// Generated on 01/12/2017 03:53:00
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class DareRewardsListMessage : NetworkMessage
{

public const uint Id = 6677;
public uint MessageId
{
    get { return Id; }
}

public Types.DareReward[] rewards;
        

public DareRewardsListMessage()
{
}

public DareRewardsListMessage(Types.DareReward[] rewards)
        {
            this.rewards = rewards;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteUShort((ushort)rewards.Length);
            foreach (var entry in rewards)
            {
                 entry.Serialize(writer);
            }
            

}

public void Deserialize(IDataReader reader)
{

var limit = reader.ReadUShort();
            rewards = new Types.DareReward[limit];
            for (int i = 0; i < limit; i++)
            {
                 rewards[i] = new Types.DareReward();
                 rewards[i].Deserialize(reader);
            }
            

}


}


}