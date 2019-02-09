


















// Generated on 07/24/2016 18:35:51
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class GameRolePlayArenaRegisterMessage : NetworkMessage
{

public const uint Id = 6280;
public uint MessageId
{
    get { return Id; }
}

public int battleMode;
        

public GameRolePlayArenaRegisterMessage()
{
}

public GameRolePlayArenaRegisterMessage(int battleMode)
        {
            this.battleMode = battleMode;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteInt(battleMode);
            

}

public void Deserialize(IDataReader reader)
{

battleMode = reader.ReadInt();
            if (battleMode < 0)
                throw new System.Exception("Forbidden value on battleMode = " + battleMode + ", it doesn't respect the following condition : battleMode < 0");
            

}


}


}