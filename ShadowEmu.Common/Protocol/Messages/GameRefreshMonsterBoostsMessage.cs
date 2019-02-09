


















// Generated on 01/12/2017 03:52:55
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class GameRefreshMonsterBoostsMessage : NetworkMessage
{

public const uint Id = 6618;
public uint MessageId
{
    get { return Id; }
}

public Types.MonsterBoosts[] monsterBoosts;
        public Types.MonsterBoosts[] familyBoosts;
        

public GameRefreshMonsterBoostsMessage()
{
}

public GameRefreshMonsterBoostsMessage(Types.MonsterBoosts[] monsterBoosts, Types.MonsterBoosts[] familyBoosts)
        {
            this.monsterBoosts = monsterBoosts;
            this.familyBoosts = familyBoosts;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteUShort((ushort)monsterBoosts.Length);
            foreach (var entry in monsterBoosts)
            {
                 entry.Serialize(writer);
            }
            writer.WriteUShort((ushort)familyBoosts.Length);
            foreach (var entry in familyBoosts)
            {
                 entry.Serialize(writer);
            }
            

}

public void Deserialize(IDataReader reader)
{

var limit = reader.ReadUShort();
            monsterBoosts = new Types.MonsterBoosts[limit];
            for (int i = 0; i < limit; i++)
            {
                 monsterBoosts[i] = new Types.MonsterBoosts();
                 monsterBoosts[i].Deserialize(reader);
            }
            limit = reader.ReadUShort();
            familyBoosts = new Types.MonsterBoosts[limit];
            for (int i = 0; i < limit; i++)
            {
                 familyBoosts[i] = new Types.MonsterBoosts();
                 familyBoosts[i].Deserialize(reader);
            }
            

}


}


}