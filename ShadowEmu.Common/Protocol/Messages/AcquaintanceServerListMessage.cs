


















// Generated on 01/12/2017 03:52:52
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class AcquaintanceServerListMessage : NetworkMessage
{

public const uint Id = 6142;
public uint MessageId
{
    get { return Id; }
}

public uint[] servers;
        

public AcquaintanceServerListMessage()
{
}

public AcquaintanceServerListMessage(uint[] servers)
        {
            this.servers = servers;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteUShort((ushort)servers.Length);
            foreach (var entry in servers)
            {
                 writer.WriteVarShort((int)entry);
            }
            

}

public void Deserialize(IDataReader reader)
{

var limit = reader.ReadUShort();
            servers = new uint[limit];
            for (int i = 0; i < limit; i++)
            {
                 servers[i] = reader.ReadVarUhShort();
            }
            

}


}


}