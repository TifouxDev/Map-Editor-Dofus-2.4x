


















// Generated on 01/12/2017 03:52:56
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class GameFightStartingMessage : NetworkMessage
{

public const uint Id = 700;
public uint MessageId
{
    get { return Id; }
}

public sbyte fightType;
        public double attackerId;
        public double defenderId;
        

public GameFightStartingMessage()
{
}

public GameFightStartingMessage(sbyte fightType, double attackerId, double defenderId)
        {
            this.fightType = fightType;
            this.attackerId = attackerId;
            this.defenderId = defenderId;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteSByte(fightType);
            writer.WriteDouble(attackerId);
            writer.WriteDouble(defenderId);
            

}

public void Deserialize(IDataReader reader)
{

fightType = reader.ReadSByte();
            if (fightType < 0)
                throw new System.Exception("Forbidden value on fightType = " + fightType + ", it doesn't respect the following condition : fightType < 0");
            attackerId = reader.ReadDouble();
            if (attackerId < -9.007199254740992E15 || attackerId > 9.007199254740992E15)
                throw new System.Exception("Forbidden value on attackerId = " + attackerId + ", it doesn't respect the following condition : attackerId < -9.007199254740992E15 || attackerId > 9.007199254740992E15");
            defenderId = reader.ReadDouble();
            if (defenderId < -9.007199254740992E15 || defenderId > 9.007199254740992E15)
                throw new System.Exception("Forbidden value on defenderId = " + defenderId + ", it doesn't respect the following condition : defenderId < -9.007199254740992E15 || defenderId > 9.007199254740992E15");
            

}


}


}