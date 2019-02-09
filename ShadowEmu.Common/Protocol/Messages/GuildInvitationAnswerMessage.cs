


















// Generated on 01/12/2017 03:53:00
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class GuildInvitationAnswerMessage : NetworkMessage
{

public const uint Id = 5556;
public uint MessageId
{
    get { return Id; }
}

public bool accept;
        

public GuildInvitationAnswerMessage()
{
}

public GuildInvitationAnswerMessage(bool accept)
        {
            this.accept = accept;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteBoolean(accept);
            

}

public void Deserialize(IDataReader reader)
{

accept = reader.ReadBoolean();
            

}


}


}