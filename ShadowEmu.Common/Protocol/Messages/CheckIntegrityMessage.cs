


















// Generated on 01/12/2017 03:53:05
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class CheckIntegrityMessage : NetworkMessage
{

public const uint Id = 6372;
public uint MessageId
{
    get { return Id; }
}

public sbyte[] data;
        

public CheckIntegrityMessage()
{
}

public CheckIntegrityMessage(sbyte[] data)
        {
            this.data = data;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteUShort((ushort)data.Length);
            foreach (var entry in data)
            {
                 writer.WriteSByte(entry);
            }
            

}

public void Deserialize(IDataReader reader)
{

var limit = reader.ReadUShort();
            data = new sbyte[limit];
            for (int i = 0; i < limit; i++)
            {
                 data[i] = reader.ReadSByte();
            }
            

}


}


}