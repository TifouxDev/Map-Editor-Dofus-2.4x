


















// Generated on 01/12/2017 03:52:54
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class LifePointsRegenBeginMessage : NetworkMessage
{

public const uint Id = 5684;
public uint MessageId
{
    get { return Id; }
}

public byte regenRate;
        

public LifePointsRegenBeginMessage()
{
}

public LifePointsRegenBeginMessage(byte regenRate)
        {
            this.regenRate = regenRate;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteByte(regenRate);
            

}

public void Deserialize(IDataReader reader)
{

regenRate = reader.ReadByte();
            if (regenRate < 0 || regenRate > 255)
                throw new System.Exception("Forbidden value on regenRate = " + regenRate + ", it doesn't respect the following condition : regenRate < 0 || regenRate > 255");
            

}


}


}