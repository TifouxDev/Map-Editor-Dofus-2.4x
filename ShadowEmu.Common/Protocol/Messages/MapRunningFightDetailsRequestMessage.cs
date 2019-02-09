


















// Generated on 01/12/2017 03:52:56
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class MapRunningFightDetailsRequestMessage : NetworkMessage
{

public const uint Id = 5750;
public uint MessageId
{
    get { return Id; }
}

public int fightId;
        

public MapRunningFightDetailsRequestMessage()
{
}

public MapRunningFightDetailsRequestMessage(int fightId)
        {
            this.fightId = fightId;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteInt(fightId);
            

}

public void Deserialize(IDataReader reader)
{

fightId = reader.ReadInt();
            if (fightId < 0)
                throw new System.Exception("Forbidden value on fightId = " + fightId + ", it doesn't respect the following condition : fightId < 0");
            

}


}


}