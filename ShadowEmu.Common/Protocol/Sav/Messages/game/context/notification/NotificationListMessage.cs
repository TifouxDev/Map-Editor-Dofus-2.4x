


















// Generated on 07/24/2016 18:35:50
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class NotificationListMessage : NetworkMessage
{

public const uint Id = 6087;
public uint MessageId
{
    get { return Id; }
}

public int[] flags;
        

public NotificationListMessage()
{
}

public NotificationListMessage(int[] flags)
        {
            this.flags = flags;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteUShort((ushort)flags.Length);
            foreach (var entry in flags)
            {
                 writer.WriteVarInt((int)entry);
            }
            

}

public void Deserialize(IDataReader reader)
{

var limit = reader.ReadUShort();
            flags = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                 flags[i] = reader.ReadVarInt();
            }
            

}


}


}