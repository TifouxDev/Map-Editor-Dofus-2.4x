


















// Generated on 01/12/2017 03:53:06
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class KrosmasterAuthTokenMessage : NetworkMessage
{

public const uint Id = 6351;
public uint MessageId
{
    get { return Id; }
}

public string token;
        

public KrosmasterAuthTokenMessage()
{
}

public KrosmasterAuthTokenMessage(string token)
        {
            this.token = token;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteUTF(token);
            

}

public void Deserialize(IDataReader reader)
{

token = reader.ReadUTF();
            

}


}


}