


















// Generated on 07/24/2016 18:35:57
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class GuildInvitationByNameMessage : NetworkMessage
{

public const uint Id = 6115;
public uint MessageId
{
    get { return Id; }
}

public string name;
        

public GuildInvitationByNameMessage()
{
}

public GuildInvitationByNameMessage(string name)
        {
            this.name = name;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteUTF(name);
            

}

public void Deserialize(IDataReader reader)
{

name = reader.ReadUTF();
            

}


}


}