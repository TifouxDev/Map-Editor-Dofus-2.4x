


















// Generated on 01/12/2017 03:52:55
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class GameFightLeaveMessage : NetworkMessage
{

public const uint Id = 721;
public uint MessageId
{
    get { return Id; }
}

public double charId;
        

public GameFightLeaveMessage()
{
}

public GameFightLeaveMessage(double charId)
        {
            this.charId = charId;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteDouble(charId);
            

}

public void Deserialize(IDataReader reader)
{

charId = reader.ReadDouble();
            if (charId < -9.007199254740992E15 || charId > 9.007199254740992E15)
                throw new System.Exception("Forbidden value on charId = " + charId + ", it doesn't respect the following condition : charId < -9.007199254740992E15 || charId > 9.007199254740992E15");
            

}


}


}