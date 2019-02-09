


















// Generated on 07/24/2016 18:36:01
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class ExchangeWaitingResultMessage : NetworkMessage
{

public const uint Id = 5786;
public uint MessageId
{
    get { return Id; }
}

public bool bwait;
        

public ExchangeWaitingResultMessage()
{
}

public ExchangeWaitingResultMessage(bool bwait)
        {
            this.bwait = bwait;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteBoolean(bwait);
            

}

public void Deserialize(IDataReader reader)
{

bwait = reader.ReadBoolean();
            

}


}


}