


















// Generated on 07/24/2016 18:36:00
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class ExchangeObjectMessage : NetworkMessage
{

public const uint Id = 5515;
public uint MessageId
{
    get { return Id; }
}

public bool remote;
        

public ExchangeObjectMessage()
{
}

public ExchangeObjectMessage(bool remote)
        {
            this.remote = remote;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteBoolean(remote);
            

}

public void Deserialize(IDataReader reader)
{

remote = reader.ReadBoolean();
            

}


}


}