


















// Generated on 07/24/2016 18:36:04
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class ContactLookErrorMessage : NetworkMessage
{

public const uint Id = 6045;
public uint MessageId
{
    get { return Id; }
}

public uint requestId;
        

public ContactLookErrorMessage()
{
}

public ContactLookErrorMessage(uint requestId)
        {
            this.requestId = requestId;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteVarInt((int)requestId);
            

}

public void Deserialize(IDataReader reader)
{

requestId = reader.ReadVarUhInt();
            if (requestId < 0)
                throw new System.Exception("Forbidden value on requestId = " + requestId + ", it doesn't respect the following condition : requestId < 0");
            

}


}


}