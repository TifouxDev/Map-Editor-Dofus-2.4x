


















// Generated on 01/12/2017 03:52:55
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class GameFightPlacementSwapPositionsOfferMessage : NetworkMessage
{

public const uint Id = 6542;
public uint MessageId
{
    get { return Id; }
}

public int requestId;
        public double requesterId;
        public uint requesterCellId;
        public double requestedId;
        public uint requestedCellId;
        

public GameFightPlacementSwapPositionsOfferMessage()
{
}

public GameFightPlacementSwapPositionsOfferMessage(int requestId, double requesterId, uint requesterCellId, double requestedId, uint requestedCellId)
        {
            this.requestId = requestId;
            this.requesterId = requesterId;
            this.requesterCellId = requesterCellId;
            this.requestedId = requestedId;
            this.requestedCellId = requestedCellId;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteInt(requestId);
            writer.WriteDouble(requesterId);
            writer.WriteVarShort((int)requesterCellId);
            writer.WriteDouble(requestedId);
            writer.WriteVarShort((int)requestedCellId);
            

}

public void Deserialize(IDataReader reader)
{

requestId = reader.ReadInt();
            if (requestId < 0)
                throw new System.Exception("Forbidden value on requestId = " + requestId + ", it doesn't respect the following condition : requestId < 0");
            requesterId = reader.ReadDouble();
            if (requesterId < -9.007199254740992E15 || requesterId > 9.007199254740992E15)
                throw new System.Exception("Forbidden value on requesterId = " + requesterId + ", it doesn't respect the following condition : requesterId < -9.007199254740992E15 || requesterId > 9.007199254740992E15");
            requesterCellId = reader.ReadVarUhShort();
            if (requesterCellId < 0 || requesterCellId > 559)
                throw new System.Exception("Forbidden value on requesterCellId = " + requesterCellId + ", it doesn't respect the following condition : requesterCellId < 0 || requesterCellId > 559");
            requestedId = reader.ReadDouble();
            if (requestedId < -9.007199254740992E15 || requestedId > 9.007199254740992E15)
                throw new System.Exception("Forbidden value on requestedId = " + requestedId + ", it doesn't respect the following condition : requestedId < -9.007199254740992E15 || requestedId > 9.007199254740992E15");
            requestedCellId = reader.ReadVarUhShort();
            if (requestedCellId < 0 || requestedCellId > 559)
                throw new System.Exception("Forbidden value on requestedCellId = " + requestedCellId + ", it doesn't respect the following condition : requestedCellId < 0 || requestedCellId > 559");
            

}


}


}