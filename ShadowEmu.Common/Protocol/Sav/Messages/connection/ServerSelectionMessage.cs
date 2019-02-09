


















// Generated on 07/24/2016 18:35:43
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class ServerSelectionMessage : NetworkMessage
{

public const uint Id = 40;
public uint MessageId
{
    get { return Id; }
}

public uint serverId;
        

public ServerSelectionMessage()
{
}

public ServerSelectionMessage(uint serverId)
        {
            this.serverId = serverId;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteVarShort((int)serverId);
            

}

public void Deserialize(IDataReader reader)
{

serverId = reader.ReadVarUhShort();
            if (serverId < 0)
                throw new System.Exception("Forbidden value on serverId = " + serverId + ", it doesn't respect the following condition : serverId < 0");
            

}


}


}