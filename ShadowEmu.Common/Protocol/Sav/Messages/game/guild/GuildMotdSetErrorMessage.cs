


















// Generated on 07/24/2016 18:35:57
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class GuildMotdSetErrorMessage : SocialNoticeSetErrorMessage
{

public const uint Id = 6591;
public uint MessageId
{
    get { return Id; }
}



public GuildMotdSetErrorMessage()
{
}

public GuildMotdSetErrorMessage(sbyte reason)
         : base(reason)
        {
        }
        

public void Serialize(IDataWriter writer)
{

base.Serialize(writer);
            

}

public void Deserialize(IDataReader reader)
{

base.Deserialize(reader);
            

}


}


}