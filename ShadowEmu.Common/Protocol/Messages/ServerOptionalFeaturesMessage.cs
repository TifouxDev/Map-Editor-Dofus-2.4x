


















// Generated on 01/12/2017 03:52:54
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class ServerOptionalFeaturesMessage : NetworkMessage
{

public const uint Id = 6305;
public uint MessageId
{
    get { return Id; }
}

public sbyte[] features;
        

public ServerOptionalFeaturesMessage()
{
}

public ServerOptionalFeaturesMessage(sbyte[] features)
        {
            this.features = features;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteUShort((ushort)features.Length);
            foreach (var entry in features)
            {
                 writer.WriteSByte(entry);
            }
            

}

public void Deserialize(IDataReader reader)
{

var limit = reader.ReadUShort();
            features = new sbyte[limit];
            for (int i = 0; i < limit; i++)
            {
                 features[i] = reader.ReadSByte();
            }
            

}


}


}