


















// Generated on 07/24/2016 18:35:56
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class SpouseStatusMessage : NetworkMessage
{

public const uint Id = 6265;
public uint MessageId
{
    get { return Id; }
}

public bool hasSpouse;
        

public SpouseStatusMessage()
{
}

public SpouseStatusMessage(bool hasSpouse)
        {
            this.hasSpouse = hasSpouse;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteBoolean(hasSpouse);
            

}

public void Deserialize(IDataReader reader)
{

hasSpouse = reader.ReadBoolean();
            

}


}


}