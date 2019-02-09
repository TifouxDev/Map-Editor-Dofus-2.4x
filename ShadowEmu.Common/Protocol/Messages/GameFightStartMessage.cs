


















// Generated on 01/12/2017 03:52:56
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class GameFightStartMessage : NetworkMessage
{

public const uint Id = 712;
public uint MessageId
{
    get { return Id; }
}

public Types.Idol[] idols;
        

public GameFightStartMessage()
{
}

public GameFightStartMessage(Types.Idol[] idols)
        {
            this.idols = idols;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteUShort((ushort)idols.Length);
            foreach (var entry in idols)
            {
                 entry.Serialize(writer);
            }
            

}

public void Deserialize(IDataReader reader)
{

var limit = reader.ReadUShort();
            idols = new Types.Idol[limit];
            for (int i = 0; i < limit; i++)
            {
                 idols[i] = new Types.Idol();
                 idols[i].Deserialize(reader);
            }
            

}


}


}