


















// Generated on 07/24/2016 18:35:50
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class NotificationUpdateFlagMessage : NetworkMessage
{

public const uint Id = 6090;
public uint MessageId
{
    get { return Id; }
}

public uint index;
        

public NotificationUpdateFlagMessage()
{
}

public NotificationUpdateFlagMessage(uint index)
        {
            this.index = index;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteVarShort((int)index);
            

}

public void Deserialize(IDataReader reader)
{

index = reader.ReadVarUhShort();
            if (index < 0)
                throw new System.Exception("Forbidden value on index = " + index + ", it doesn't respect the following condition : index < 0");
            

}


}


}