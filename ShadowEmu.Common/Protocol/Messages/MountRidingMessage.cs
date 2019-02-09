


















// Generated on 01/12/2017 03:52:56
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class MountRidingMessage : NetworkMessage
{

public const uint Id = 5967;
public uint MessageId
{
    get { return Id; }
}

public bool isRiding;
        

public MountRidingMessage()
{
}

public MountRidingMessage(bool isRiding)
        {
            this.isRiding = isRiding;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteBoolean(isRiding);
            

}

public void Deserialize(IDataReader reader)
{

isRiding = reader.ReadBoolean();
            

}


}


}