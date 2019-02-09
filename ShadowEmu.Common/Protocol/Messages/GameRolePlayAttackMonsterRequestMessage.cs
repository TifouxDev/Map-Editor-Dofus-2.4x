


















// Generated on 01/12/2017 03:52:57
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class GameRolePlayAttackMonsterRequestMessage : NetworkMessage
{

public const uint Id = 6191;
public uint MessageId
{
    get { return Id; }
}

public double monsterGroupId;
        

public GameRolePlayAttackMonsterRequestMessage()
{
}

public GameRolePlayAttackMonsterRequestMessage(double monsterGroupId)
        {
            this.monsterGroupId = monsterGroupId;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteDouble(monsterGroupId);
            

}

public void Deserialize(IDataReader reader)
{

monsterGroupId = reader.ReadDouble();
            if (monsterGroupId < -9.007199254740992E15 || monsterGroupId > 9.007199254740992E15)
                throw new System.Exception("Forbidden value on monsterGroupId = " + monsterGroupId + ", it doesn't respect the following condition : monsterGroupId < -9.007199254740992E15 || monsterGroupId > 9.007199254740992E15");
            

}


}


}