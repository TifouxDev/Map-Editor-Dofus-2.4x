


















// Generated on 01/12/2017 03:53:05
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class PartsListMessage : NetworkMessage
{

public const uint Id = 1502;
public uint MessageId
{
    get { return Id; }
}

public Types.ContentPart[] parts;
        

public PartsListMessage()
{
}

public PartsListMessage(Types.ContentPart[] parts)
        {
            this.parts = parts;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteUShort((ushort)parts.Length);
            foreach (var entry in parts)
            {
                 entry.Serialize(writer);
            }
            

}

public void Deserialize(IDataReader reader)
{

var limit = reader.ReadUShort();
            parts = new Types.ContentPart[limit];
            for (int i = 0; i < limit; i++)
            {
                 parts[i] = new Types.ContentPart();
                 parts[i].Deserialize(reader);
            }
            

}


}


}