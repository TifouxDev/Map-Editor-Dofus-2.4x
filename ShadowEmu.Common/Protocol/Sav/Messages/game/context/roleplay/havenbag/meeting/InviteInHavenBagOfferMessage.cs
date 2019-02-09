


















// Generated on 07/24/2016 18:35:52
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class InviteInHavenBagOfferMessage : NetworkMessage
{

public const uint Id = 6643;
public uint MessageId
{
    get { return Id; }
}

public Types.CharacterMinimalInformations hostInformations;
        public int timeLeftBeforeCancel;
        

public InviteInHavenBagOfferMessage()
{
}

public InviteInHavenBagOfferMessage(Types.CharacterMinimalInformations hostInformations, int timeLeftBeforeCancel)
        {
            this.hostInformations = hostInformations;
            this.timeLeftBeforeCancel = timeLeftBeforeCancel;
        }
        

public void Serialize(IDataWriter writer)
{

hostInformations.Serialize(writer);
            writer.WriteVarInt((int)timeLeftBeforeCancel);
            

}

public void Deserialize(IDataReader reader)
{

hostInformations = new Types.CharacterMinimalInformations();
            hostInformations.Deserialize(reader);
            timeLeftBeforeCancel = reader.ReadVarInt();
            

}


}


}