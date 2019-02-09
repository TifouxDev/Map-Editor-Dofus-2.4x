


















// Generated on 07/24/2016 18:35:51
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class ChangeHavenBagRoomRequestMessage : NetworkMessage
{

public const uint Id = 6638;
public uint MessageId
{
    get { return Id; }
}

public sbyte roomId;
        

public ChangeHavenBagRoomRequestMessage()
{
}

public ChangeHavenBagRoomRequestMessage(sbyte roomId)
        {
            this.roomId = roomId;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteSByte(roomId);
            

}

public void Deserialize(IDataReader reader)
{

roomId = reader.ReadSByte();
            if (roomId < 0)
                throw new System.Exception("Forbidden value on roomId = " + roomId + ", it doesn't respect the following condition : roomId < 0");
            

}


}


}