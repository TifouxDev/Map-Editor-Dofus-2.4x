


















// Generated on 01/12/2017 03:52:54
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class CharacterLevelUpMessage : NetworkMessage
{

public const uint Id = 5670;
public uint MessageId
{
    get { return Id; }
}

public byte newLevel;
        

public CharacterLevelUpMessage()
{
}

public CharacterLevelUpMessage(byte newLevel)
        {
            this.newLevel = newLevel;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteByte(newLevel);
            

}

public void Deserialize(IDataReader reader)
{

newLevel = reader.ReadByte();
            if (newLevel < 2 || newLevel > 206)
                throw new System.Exception("Forbidden value on newLevel = " + newLevel + ", it doesn't respect the following condition : newLevel < 2 || newLevel > 206");
            

}


}


}