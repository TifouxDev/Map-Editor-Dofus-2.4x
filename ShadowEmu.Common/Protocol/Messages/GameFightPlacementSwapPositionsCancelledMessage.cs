


















// Generated on 01/12/2017 03:52:55
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class GameFightPlacementSwapPositionsCancelledMessage : NetworkMessage
{

public const uint Id = 6546;
public uint MessageId
{
    get { return Id; }
}

public int requestId;
        public double cancellerId;
        

public GameFightPlacementSwapPositionsCancelledMessage()
{
}

public GameFightPlacementSwapPositionsCancelledMessage(int requestId, double cancellerId)
        {
            this.requestId = requestId;
            this.cancellerId = cancellerId;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteInt(requestId);
            writer.WriteDouble(cancellerId);
            

}

public void Deserialize(IDataReader reader)
{

requestId = reader.ReadInt();
            if (requestId < 0)
                throw new System.Exception("Forbidden value on requestId = " + requestId + ", it doesn't respect the following condition : requestId < 0");
            cancellerId = reader.ReadDouble();
            if (cancellerId < -9.007199254740992E15 || cancellerId > 9.007199254740992E15)
                throw new System.Exception("Forbidden value on cancellerId = " + cancellerId + ", it doesn't respect the following condition : cancellerId < -9.007199254740992E15 || cancellerId > 9.007199254740992E15");
            

}


}


}