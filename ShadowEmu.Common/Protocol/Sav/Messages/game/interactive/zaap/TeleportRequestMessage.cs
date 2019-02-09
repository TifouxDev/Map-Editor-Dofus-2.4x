


















// Generated on 07/24/2016 18:35:58
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class TeleportRequestMessage : NetworkMessage
{

public const uint Id = 5961;
public uint MessageId
{
    get { return Id; }
}

public sbyte teleporterType;
        public int mapId;
        

public TeleportRequestMessage()
{
}

public TeleportRequestMessage(sbyte teleporterType, int mapId)
        {
            this.teleporterType = teleporterType;
            this.mapId = mapId;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteSByte(teleporterType);
            writer.WriteInt(mapId);
            

}

public void Deserialize(IDataReader reader)
{

teleporterType = reader.ReadSByte();
            if (teleporterType < 0)
                throw new System.Exception("Forbidden value on teleporterType = " + teleporterType + ", it doesn't respect the following condition : teleporterType < 0");
            mapId = reader.ReadInt();
            if (mapId < 0)
                throw new System.Exception("Forbidden value on mapId = " + mapId + ", it doesn't respect the following condition : mapId < 0");
            

}


}


}