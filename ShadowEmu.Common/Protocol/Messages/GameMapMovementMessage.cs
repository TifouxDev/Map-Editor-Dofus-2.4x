


















// Generated on 01/12/2017 03:52:55
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class GameMapMovementMessage : NetworkMessage
{

public const uint Id = 951;
public uint MessageId
{
    get { return Id; }
}

public short[] keyMovements;
        public int forcedDirection;
        public double actorId;
        

public GameMapMovementMessage()
{
}

public GameMapMovementMessage(short[] keyMovements, double actorId, int forcedDirection = 0)
        {
            this.keyMovements = keyMovements;
            this.actorId = actorId;
            this.forcedDirection = forcedDirection;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteUShort((ushort)keyMovements.Length);
            foreach (var entry in keyMovements)
            {
                 writer.WriteShort(entry);
            }
            writer.WriteShort((short)forcedDirection);
            writer.WriteDouble(actorId);
            

}

public void Deserialize(IDataReader reader)
{

var limit = reader.ReadUShort();
            keyMovements = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                 keyMovements[i] = reader.ReadShort();
            }
            forcedDirection = reader.ReadShort();
            actorId = reader.ReadDouble();
            if (actorId < -9.007199254740992E15 || actorId > 9.007199254740992E15)
                throw new System.Exception("Forbidden value on actorId = " + actorId + ", it doesn't respect the following condition : actorId < -9.007199254740992E15 || actorId > 9.007199254740992E15");
            

}


}


}