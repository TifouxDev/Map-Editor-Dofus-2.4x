


















// Generated on 07/24/2016 18:35:50
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class MountXpRatioMessage : NetworkMessage
{

public const uint Id = 5970;
public uint MessageId
{
    get { return Id; }
}

public sbyte ratio;
        

public MountXpRatioMessage()
{
}

public MountXpRatioMessage(sbyte ratio)
        {
            this.ratio = ratio;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteSByte(ratio);
            

}

public void Deserialize(IDataReader reader)
{

ratio = reader.ReadSByte();
            if (ratio < 0)
                throw new System.Exception("Forbidden value on ratio = " + ratio + ", it doesn't respect the following condition : ratio < 0");
            

}


}


}