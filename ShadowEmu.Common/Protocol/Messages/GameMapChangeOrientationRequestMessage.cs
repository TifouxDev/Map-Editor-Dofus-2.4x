


















// Generated on 01/12/2017 03:52:55
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class GameMapChangeOrientationRequestMessage : NetworkMessage
{

public const uint Id = 945;
public uint MessageId
{
    get { return Id; }
}

public sbyte direction;
        

public GameMapChangeOrientationRequestMessage()
{
}

public GameMapChangeOrientationRequestMessage(sbyte direction)
        {
            this.direction = direction;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteSByte(direction);
            

}

public void Deserialize(IDataReader reader)
{

direction = reader.ReadSByte();
            if (direction < 0)
                throw new System.Exception("Forbidden value on direction = " + direction + ", it doesn't respect the following condition : direction < 0");
            

}


}


}