


















// Generated on 01/12/2017 03:53:01
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class InteractiveUsedMessage : NetworkMessage
{

public const uint Id = 5745;
public uint MessageId
{
    get { return Id; }
}

public double entityId;
        public uint elemId;
        public uint skillId;
        public uint duration;
        public bool canMove;
        

public InteractiveUsedMessage()
{
}

public InteractiveUsedMessage(double entityId, uint elemId, uint skillId, uint duration, bool canMove)
        {
            this.entityId = entityId;
            this.elemId = elemId;
            this.skillId = skillId;
            this.duration = duration;
            this.canMove = canMove;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteVarLong(entityId);
            writer.WriteVarInt((int)elemId);
            writer.WriteVarShort((int)skillId);
            writer.WriteVarShort((int)duration);
            writer.WriteBoolean(canMove);
            

}

public void Deserialize(IDataReader reader)
{

entityId = reader.ReadVarUhLong();
            if (entityId < 0 || entityId > 9.007199254740992E15)
                throw new System.Exception("Forbidden value on entityId = " + entityId + ", it doesn't respect the following condition : entityId < 0 || entityId > 9.007199254740992E15");
            elemId = reader.ReadVarUhInt();
            if (elemId < 0)
                throw new System.Exception("Forbidden value on elemId = " + elemId + ", it doesn't respect the following condition : elemId < 0");
            skillId = reader.ReadVarUhShort();
            if (skillId < 0)
                throw new System.Exception("Forbidden value on skillId = " + skillId + ", it doesn't respect the following condition : skillId < 0");
            duration = reader.ReadVarUhShort();
            if (duration < 0)
                throw new System.Exception("Forbidden value on duration = " + duration + ", it doesn't respect the following condition : duration < 0");
            canMove = reader.ReadBoolean();
            

}


}


}