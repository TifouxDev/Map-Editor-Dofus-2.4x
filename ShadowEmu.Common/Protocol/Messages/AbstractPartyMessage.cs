


















// Generated on 01/12/2017 03:52:58
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class AbstractPartyMessage : NetworkMessage
{

public const uint Id = 6274;
public uint MessageId
{
    get { return Id; }
}

public uint partyId;
        

public AbstractPartyMessage()
{
}

public AbstractPartyMessage(uint partyId)
        {
            this.partyId = partyId;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteVarInt((int)partyId);
            

}

public void Deserialize(IDataReader reader)
{

partyId = reader.ReadVarUhInt();
            if (partyId < 0)
                throw new System.Exception("Forbidden value on partyId = " + partyId + ", it doesn't respect the following condition : partyId < 0");
            

}


}


}