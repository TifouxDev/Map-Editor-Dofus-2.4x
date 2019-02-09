


















// Generated on 01/12/2017 03:53:01
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class OnConnectionEventMessage : NetworkMessage
{

public const uint Id = 5726;
public uint MessageId
{
    get { return Id; }
}

public sbyte eventType;
        

public OnConnectionEventMessage()
{
}

public OnConnectionEventMessage(sbyte eventType)
        {
            this.eventType = eventType;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteSByte(eventType);
            

}

public void Deserialize(IDataReader reader)
{

eventType = reader.ReadSByte();
            if (eventType < 0)
                throw new System.Exception("Forbidden value on eventType = " + eventType + ", it doesn't respect the following condition : eventType < 0");
            

}


}


}