


















// Generated on 01/12/2017 03:52:57
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class RoomAvailableUpdateMessage : NetworkMessage
{

public const uint Id = 6630;
public uint MessageId
{
    get { return Id; }
}

public byte nbRoom;
        

public RoomAvailableUpdateMessage()
{
}

public RoomAvailableUpdateMessage(byte nbRoom)
        {
            this.nbRoom = nbRoom;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteByte(nbRoom);
            

}

public void Deserialize(IDataReader reader)
{

nbRoom = reader.ReadByte();
            if (nbRoom < 0 || nbRoom > 255)
                throw new System.Exception("Forbidden value on nbRoom = " + nbRoom + ", it doesn't respect the following condition : nbRoom < 0 || nbRoom > 255");
            

}


}


}