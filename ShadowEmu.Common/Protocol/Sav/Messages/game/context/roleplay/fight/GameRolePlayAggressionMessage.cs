


















// Generated on 07/24/2016 18:35:51
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class GameRolePlayAggressionMessage : NetworkMessage
{

public const uint Id = 6073;
public uint MessageId
{
    get { return Id; }
}

public double attackerId;
        public double defenderId;
        

public GameRolePlayAggressionMessage()
{
}

public GameRolePlayAggressionMessage(double attackerId, double defenderId)
        {
            this.attackerId = attackerId;
            this.defenderId = defenderId;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteVarLong(attackerId);
            writer.WriteVarLong(defenderId);
            

}

public void Deserialize(IDataReader reader)
{

attackerId = reader.ReadVarUhLong();
            if (attackerId < 0 || attackerId > 9.007199254740992E15)
                throw new System.Exception("Forbidden value on attackerId = " + attackerId + ", it doesn't respect the following condition : attackerId < 0 || attackerId > 9.007199254740992E15");
            defenderId = reader.ReadVarUhLong();
            if (defenderId < 0 || defenderId > 9.007199254740992E15)
                throw new System.Exception("Forbidden value on defenderId = " + defenderId + ", it doesn't respect the following condition : defenderId < 0 || defenderId > 9.007199254740992E15");
            

}


}


}