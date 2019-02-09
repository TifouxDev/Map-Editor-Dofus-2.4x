


















// Generated on 07/24/2016 18:35:43
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class HelloConnectMessage : NetworkMessage
{

public const uint Id = 3;
public uint MessageId
{
    get { return Id; }
}

public string salt;
        public sbyte[] key;
        

public HelloConnectMessage()
{
}

public HelloConnectMessage(string salt, sbyte[] key)
        {
            this.salt = salt;
            this.key = key;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteUTF(salt);
            writer.WriteUShort((ushort)key.Length);
            foreach (var entry in key)
            {
                 writer.WriteSByte(entry);
            }
            

}

public void Deserialize(IDataReader reader)
{

salt = reader.ReadUTF();
            var limit = reader.ReadUShort();
            key = new sbyte[limit];
            for (int i = 0; i < limit; i++)
            {
                 key[i] = reader.ReadSByte();
            }
            

}


}


}