


















// Generated on 01/12/2017 03:53:06
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class HaapiApiKeyRequestMessage : NetworkMessage
{

public const uint Id = 6648;
public uint MessageId
{
    get { return Id; }
}

public sbyte keyType;
        

public HaapiApiKeyRequestMessage()
{
}

public HaapiApiKeyRequestMessage(sbyte keyType)
        {
            this.keyType = keyType;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteSByte(keyType);
            

}

public void Deserialize(IDataReader reader)
{

keyType = reader.ReadSByte();
            if (keyType < 0)
                throw new System.Exception("Forbidden value on keyType = " + keyType + ", it doesn't respect the following condition : keyType < 0");
            

}


}


}