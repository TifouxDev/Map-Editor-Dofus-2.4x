


















// Generated on 01/12/2017 03:53:00
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class FriendSetWarnOnLevelGainMessage : NetworkMessage
{

public const uint Id = 6077;
public uint MessageId
{
    get { return Id; }
}

public bool enable;
        

public FriendSetWarnOnLevelGainMessage()
{
}

public FriendSetWarnOnLevelGainMessage(bool enable)
        {
            this.enable = enable;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteBoolean(enable);
            

}

public void Deserialize(IDataReader reader)
{

enable = reader.ReadBoolean();
            

}


}


}