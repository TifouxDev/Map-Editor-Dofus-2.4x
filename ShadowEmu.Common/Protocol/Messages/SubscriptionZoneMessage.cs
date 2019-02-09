


















// Generated on 01/12/2017 03:53:05
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class SubscriptionZoneMessage : NetworkMessage
{

public const uint Id = 5573;
public uint MessageId
{
    get { return Id; }
}

public bool active;
        

public SubscriptionZoneMessage()
{
}

public SubscriptionZoneMessage(bool active)
        {
            this.active = active;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteBoolean(active);
            

}

public void Deserialize(IDataReader reader)
{

active = reader.ReadBoolean();
            

}


}


}