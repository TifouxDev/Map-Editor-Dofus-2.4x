


















// Generated on 01/12/2017 03:53:00
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class FinishMoveSetRequestMessage : NetworkMessage
{

public const uint Id = 6703;
public uint MessageId
{
    get { return Id; }
}

public int finishMoveId;
        public bool finishMoveState;
        

public FinishMoveSetRequestMessage()
{
}

public FinishMoveSetRequestMessage(int finishMoveId, bool finishMoveState)
        {
            this.finishMoveId = finishMoveId;
            this.finishMoveState = finishMoveState;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteInt(finishMoveId);
            writer.WriteBoolean(finishMoveState);
            

}

public void Deserialize(IDataReader reader)
{

finishMoveId = reader.ReadInt();
            if (finishMoveId < 0)
                throw new System.Exception("Forbidden value on finishMoveId = " + finishMoveId + ", it doesn't respect the following condition : finishMoveId < 0");
            finishMoveState = reader.ReadBoolean();
            

}


}


}