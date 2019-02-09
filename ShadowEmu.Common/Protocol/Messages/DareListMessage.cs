


















// Generated on 01/12/2017 03:53:00
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class DareListMessage : NetworkMessage
{

public const uint Id = 6661;
public uint MessageId
{
    get { return Id; }
}

public Types.DareInformations[] dares;
        

public DareListMessage()
{
}

public DareListMessage(Types.DareInformations[] dares)
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
            dares = new Types.DareInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                 dares[i] = new Types.DareInformations();
                 dares[i].Deserialize(reader);
            }
            

}


}


}