


















// Generated on 01/12/2017 03:53:01
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class GuildKickRequestMessage : NetworkMessage
{

public const uint Id = 5887;
public uint MessageId
{
    get { return Id; }
}

public double kickedId;
        

public GuildKickRequestMessage()
{
}

public GuildKickRequestMessage(double kickedId)
        {
            this.kickedId = kickedId;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteVarLong(kickedId);
            

}

public void Deserialize(IDataReader reader)
{

kickedId = reader.ReadVarUhLong();
            if (kickedId < 0 || kickedId > 9.007199254740992E15)
                throw new System.Exception("Forbidden value on kickedId = " + kickedId + ", it doesn't respect the following condition : kickedId < 0 || kickedId > 9.007199254740992E15");
            

}


}


}