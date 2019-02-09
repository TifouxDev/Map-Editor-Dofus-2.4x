


















// Generated on 07/24/2016 18:36:04
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class ContactLookRequestMessage : NetworkMessage
{

public const uint Id = 5932;
public uint MessageId
{
    get { return Id; }
}

public byte requestId;
        public sbyte contactType;
        

public ContactLookRequestMessage()
{
}

public ContactLookRequestMessage(byte requestId, sbyte contactType)
        {
            this.requestId = requestId;
            this.contactType = contactType;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteByte(requestId);
            writer.WriteSByte(contactType);
            

}

public void Deserialize(IDataReader reader)
{

requestId = reader.ReadByte();
            if (requestId < 0 || requestId > 255)
                throw new System.Exception("Forbidden value on requestId = " + requestId + ", it doesn't respect the following condition : requestId < 0 || requestId > 255");
            contactType = reader.ReadSByte();
            if (contactType < 0)
                throw new System.Exception("Forbidden value on contactType = " + contactType + ", it doesn't respect the following condition : contactType < 0");
            

}


}


}