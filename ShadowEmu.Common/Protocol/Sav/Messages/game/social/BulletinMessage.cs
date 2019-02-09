


















// Generated on 07/24/2016 18:36:04
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class BulletinMessage : SocialNoticeMessage
{

public const uint Id = 6695;
public uint MessageId
{
    get { return Id; }
}

public int lastNotifiedTimestamp;
        

public BulletinMessage()
{
}

public BulletinMessage(string content, int timestamp, double memberId, string memberName, int lastNotifiedTimestamp)
         : base(content, timestamp, memberId, memberName)
        {
            this.lastNotifiedTimestamp = lastNotifiedTimestamp;
        }
        

public void Serialize(IDataWriter writer)
{

base.Serialize(writer);
            writer.WriteInt(lastNotifiedTimestamp);
            

}

public void Deserialize(IDataReader reader)
{

base.Deserialize(reader);
            lastNotifiedTimestamp = reader.ReadInt();
            if (lastNotifiedTimestamp < 0)
                throw new System.Exception("Forbidden value on lastNotifiedTimestamp = " + lastNotifiedTimestamp + ", it doesn't respect the following condition : lastNotifiedTimestamp < 0");
            

}


}


}