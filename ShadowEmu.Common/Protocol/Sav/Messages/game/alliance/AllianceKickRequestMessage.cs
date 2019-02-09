


















// Generated on 07/24/2016 18:35:45
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class AllianceKickRequestMessage : NetworkMessage
{

public const uint Id = 6400;
public uint MessageId
{
    get { return Id; }
}

public uint kickedId;
        

public AllianceKickRequestMessage()
{
}

public AllianceKickRequestMessage(uint kickedId)
        {
            this.kickedId = kickedId;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteVarInt((int)kickedId);
            

}

public void Deserialize(IDataReader reader)
{

kickedId = reader.ReadVarUhInt();
            if (kickedId < 0)
                throw new System.Exception("Forbidden value on kickedId = " + kickedId + ", it doesn't respect the following condition : kickedId < 0");
            

}


}


}