


















// Generated on 07/24/2016 18:35:50
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class CurrentMapMessage : NetworkMessage
{

public const uint Id = 220;
public uint MessageId
{
    get { return Id; }
}

public int mapId;
        public string mapKey;
        

public CurrentMapMessage()
{
}

public CurrentMapMessage(int mapId, string mapKey)
        {
            this.mapId = mapId;
            this.mapKey = mapKey;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteInt(mapId);
            writer.WriteUTF(mapKey);
            

}

public void Deserialize(IDataReader reader)
{

mapId = reader.ReadInt();
            if (mapId < 0)
                throw new System.Exception("Forbidden value on mapId = " + mapId + ", it doesn't respect the following condition : mapId < 0");
            mapKey = reader.ReadUTF();
            

}


}


}