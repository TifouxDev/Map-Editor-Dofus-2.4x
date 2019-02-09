


















// Generated on 01/12/2017 03:52:57
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class EmoteListMessage : NetworkMessage
{

public const uint Id = 5689;
public uint MessageId
{
    get { return Id; }
}

public byte[] emoteIds;
        

public EmoteListMessage()
{
}

public EmoteListMessage(byte[] emoteIds)
        {
            this.emoteIds = emoteIds;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteUShort((ushort)emoteIds.Length);
            foreach (var entry in emoteIds)
            {
                 writer.WriteByte(entry);
            }
            

}

public void Deserialize(IDataReader reader)
{

var limit = reader.ReadUShort();
            emoteIds = new byte[limit];
            for (int i = 0; i < limit; i++)
            {
                 emoteIds[i] = reader.ReadByte();
            }
            

}


}


}