


















// Generated on 01/12/2017 03:53:05
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class ClientKeyMessage : NetworkMessage
{

public const uint Id = 5607;
public uint MessageId
{
    get { return Id; }
}

public string key;
        

public ClientKeyMessage()
{
}

public ClientKeyMessage(string key)
        {
            this.key = key;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteUTF(key);
            

}

public void Deserialize(IDataReader reader)
{

key = reader.ReadUTF();
            

}


}


}