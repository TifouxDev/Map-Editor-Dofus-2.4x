


















// Generated on 01/12/2017 03:52:55
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class ChatServerMessage : ChatAbstractServerMessage
{

public const uint Id = 881;
public uint MessageId
{
    get { return Id; }
}

public double senderId;
        public string senderName;
        public int senderAccountId;
        

public ChatServerMessage()
{
}

public ChatServerMessage(sbyte channel, string content, int timestamp, string fingerprint, double senderId, string senderName, int senderAccountId)
         : base(channel, content, timestamp, fingerprint)
        {
            this.senderId = senderId;
            this.senderName = senderName;
            this.senderAccountId = senderAccountId;
        }
        

public void Serialize(IDataWriter writer)
{

base.Serialize(writer);
            writer.WriteDouble(senderId);
            writer.WriteUTF(senderName);
            writer.WriteInt(senderAccountId);
            

}

public void Deserialize(IDataReader reader)
{

base.Deserialize(reader);
            senderId = reader.ReadDouble();
            if (senderId < -9.007199254740992E15 || senderId > 9.007199254740992E15)
                throw new System.Exception("Forbidden value on senderId = " + senderId + ", it doesn't respect the following condition : senderId < -9.007199254740992E15 || senderId > 9.007199254740992E15");
            senderName = reader.ReadUTF();
            senderAccountId = reader.ReadInt();
            if (senderAccountId < 0)
                throw new System.Exception("Forbidden value on senderAccountId = " + senderAccountId + ", it doesn't respect the following condition : senderAccountId < 0");
            

}


}


}