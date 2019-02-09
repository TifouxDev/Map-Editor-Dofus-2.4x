


















// Generated on 07/24/2016 18:35:56
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class DareVersatileListMessage : NetworkMessage
{

public const uint Id = 6657;
public uint MessageId
{
    get { return Id; }
}

public Types.DareVersatileInformations[] dares;
        

public DareVersatileListMessage()
{
}

public DareVersatileListMessage(Types.DareVersatileInformations[] dares)
        {
            this.dares = dares;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteUShort((ushort)dares.Length);
            foreach (var entry in dares)
            {
                 entry.Serialize(writer);
            }
            

}

public void Deserialize(IDataReader reader)
{

var limit = reader.ReadUShort();
            dares = new Types.DareVersatileInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                 dares[i] = new Types.DareVersatileInformations();
                 dares[i].Deserialize(reader);
            }
            

}


}


}