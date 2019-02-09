


















// Generated on 01/12/2017 03:53:06
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class HaapiApiKeyMessage : NetworkMessage
{

public const uint Id = 6649;
public uint MessageId
{
    get { return Id; }
}

public sbyte keyType;
        public string token;
        

public HaapiApiKeyMessage()
{
}

public HaapiApiKeyMessage(sbyte keyType, string token)
        {
            this.keyType = keyType;
            this.token = token;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteSByte(keyType);
            writer.WriteUTF(token);
            

}

public void Deserialize(IDataReader reader)
{

keyType = reader.ReadSByte();
            if (keyType < 0)
                throw new System.Exception("Forbidden value on keyType = " + keyType + ", it doesn't respect the following condition : keyType < 0");
            token = reader.ReadUTF();
            

}


}


}