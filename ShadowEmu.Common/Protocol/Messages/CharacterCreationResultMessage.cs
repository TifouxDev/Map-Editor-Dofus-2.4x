


















// Generated on 01/12/2017 03:52:54
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class CharacterCreationResultMessage : NetworkMessage
{

public const uint Id = 161;
public uint MessageId
{
    get { return Id; }
}

public sbyte result;
        

public CharacterCreationResultMessage()
{
}

public CharacterCreationResultMessage(sbyte result)
        {
            this.result = result;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteSByte(result);
            

}

public void Deserialize(IDataReader reader)
{

result = reader.ReadSByte();
            if (result < 0)
                throw new System.Exception("Forbidden value on result = " + result + ", it doesn't respect the following condition : result < 0");
            

}


}


}