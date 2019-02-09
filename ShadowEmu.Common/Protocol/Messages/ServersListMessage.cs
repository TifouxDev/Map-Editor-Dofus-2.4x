


















// Generated on 01/12/2017 03:52:52
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class ServersListMessage : NetworkMessage
{

public const uint Id = 30;
public uint MessageId
{
    get { return Id; }
}

public Types.GameServerInformations[] servers;
        public uint alreadyConnectedToServerId;
        public bool canCreateNewCharacter;
        

public ServersListMessage()
{
}

public ServersListMessage(Types.GameServerInformations[] servers, uint alreadyConnectedToServerId, bool canCreateNewCharacter)
        {
            this.servers = servers;
            this.alreadyConnectedToServerId = alreadyConnectedToServerId;
            this.canCreateNewCharacter = canCreateNewCharacter;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteUShort((ushort)servers.Length);
            foreach (var entry in servers)
            {
                 entry.Serialize(writer);
            }
            writer.WriteVarShort((int)alreadyConnectedToServerId);
            writer.WriteBoolean(canCreateNewCharacter);
            

}

public void Deserialize(IDataReader reader)
{

var limit = reader.ReadUShort();
            servers = new Types.GameServerInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                 servers[i] = new Types.GameServerInformations();
                 servers[i].Deserialize(reader);
            }
            alreadyConnectedToServerId = reader.ReadVarUhShort();
            if (alreadyConnectedToServerId < 0)
                throw new System.Exception("Forbidden value on alreadyConnectedToServerId = " + alreadyConnectedToServerId + ", it doesn't respect the following condition : alreadyConnectedToServerId < 0");
            canCreateNewCharacter = reader.ReadBoolean();
            

}


}


}