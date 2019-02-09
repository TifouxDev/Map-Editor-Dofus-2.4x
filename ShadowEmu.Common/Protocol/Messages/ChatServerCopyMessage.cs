


















// Generated on 01/12/2017 03:52:54
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class ChatServerCopyMessage : ChatAbstractServerMessage
{

public const uint Id = 882;
public uint MessageId
{
    get { return Id; }
}

public double receiverId;
        public string receiverName;
        

public ChatServerCopyMessage()
{
}

public ChatServerCopyMessage(sbyte channel, string content, int timestamp, string fingerprint, double receiverId, string receiverName)
         : base(channel, content, timestamp, fingerprint)
        {
            this.receiverId = receiverId;
            this.receiverName = receiverName;
        }
        

public void Serialize(IDataWriter writer)
{

base.Serialize(writer);
            writer.WriteVarLong(receiverId);
            writer.WriteUTF(receiverName);
            

}

public void Deserialize(IDataReader reader)
{

base.Deserialize(reader);
            receiverId = reader.ReadVarUhLong();
            if (receiverId < 0 || receiverId > 9.007199254740992E15)
                throw new System.Exception("Forbidden value on receiverId = " + receiverId + ", it doesn't respect the following condition : receiverId < 0 || receiverId > 9.007199254740992E15");
            receiverName = reader.ReadUTF();
            

}


}


}