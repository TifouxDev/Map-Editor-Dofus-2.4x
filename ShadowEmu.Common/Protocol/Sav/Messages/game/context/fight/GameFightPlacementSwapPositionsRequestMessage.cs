


















// Generated on 07/24/2016 18:35:49
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class GameFightPlacementSwapPositionsRequestMessage : GameFightPlacementPositionRequestMessage
{

public const uint Id = 6541;
public uint MessageId
{
    get { return Id; }
}

public double requestedId;
        

public GameFightPlacementSwapPositionsRequestMessage()
{
}

public GameFightPlacementSwapPositionsRequestMessage(uint cellId, double requestedId)
         : base(cellId)
        {
            this.requestedId = requestedId;
        }
        

public void Serialize(IDataWriter writer)
{

base.Serialize(writer);
            writer.WriteDouble(requestedId);
            

}

public void Deserialize(IDataReader reader)
{

base.Deserialize(reader);
            requestedId = reader.ReadDouble();
            if (requestedId < -9.007199254740992E15 || requestedId > 9.007199254740992E15)
                throw new System.Exception("Forbidden value on requestedId = " + requestedId + ", it doesn't respect the following condition : requestedId < -9.007199254740992E15 || requestedId > 9.007199254740992E15");
            

}


}


}