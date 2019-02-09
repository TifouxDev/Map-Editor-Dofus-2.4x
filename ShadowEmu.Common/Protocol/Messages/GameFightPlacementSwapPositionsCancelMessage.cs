


















// Generated on 01/12/2017 03:52:55
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class GameFightPlacementSwapPositionsCancelMessage : NetworkMessage
{

public const uint Id = 6543;
public uint MessageId
{
    get { return Id; }
}

public int requestId;
        

public GameFightPlacementSwapPositionsCancelMessage()
{
}

public GameFightPlacementSwapPositionsCancelMessage(int requestId)
        {
            this.requestId = requestId;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteInt(requestId);
            

}

public void Deserialize(IDataReader reader)
{

requestId = reader.ReadInt();
            if (requestId < 0)
                throw new System.Exception("Forbidden value on requestId = " + requestId + ", it doesn't respect the following condition : requestId < 0");
            

}


}


}