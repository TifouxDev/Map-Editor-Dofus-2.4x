


















// Generated on 01/12/2017 03:52:57
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class InviteInHavenBagMessage : NetworkMessage
{

public const uint Id = 6642;
public uint MessageId
{
    get { return Id; }
}

public Types.CharacterMinimalInformations guestInformations;
        public bool accept;
        

public InviteInHavenBagMessage()
{
}

public InviteInHavenBagMessage(Types.CharacterMinimalInformations guestInformations, bool accept)
        {
            this.guestInformations = guestInformations;
            this.accept = accept;
        }
        

public void Serialize(IDataWriter writer)
{

guestInformations.Serialize(writer);
            writer.WriteBoolean(accept);
            

}

public void Deserialize(IDataReader reader)
{

guestInformations = new Types.CharacterMinimalInformations();
            guestInformations.Deserialize(reader);
            accept = reader.ReadBoolean();
            

}


}


}