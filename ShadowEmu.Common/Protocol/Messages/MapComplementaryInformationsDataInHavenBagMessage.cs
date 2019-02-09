


















// Generated on 01/12/2017 03:52:56
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class MapComplementaryInformationsDataInHavenBagMessage : MapComplementaryInformationsDataMessage
{

public const uint Id = 6622;
public uint MessageId
{
    get { return Id; }
}

public Types.CharacterMinimalInformations ownerInformations;
        public sbyte theme;
        public sbyte roomId;
        public sbyte maxRoomId;
        

public MapComplementaryInformationsDataInHavenBagMessage()
{
}

public MapComplementaryInformationsDataInHavenBagMessage(uint subAreaId, int mapId, Types.HouseInformations[] houses, Types.GameRolePlayActorInformations[] actors, Types.InteractiveElement[] interactiveElements, Types.StatedElement[] statedElements, Types.MapObstacle[] obstacles, Types.FightCommonInformations[] fights, bool hasAggressiveMonsters, Types.CharacterMinimalInformations ownerInformations, sbyte theme, sbyte roomId, sbyte maxRoomId, FightStartingPositions positions)
         : base(subAreaId, mapId, houses, actors, interactiveElements, statedElements, obstacles, fights, hasAggressiveMonsters, positions)
        {
            this.ownerInformations = ownerInformations;
            this.theme = theme;
            this.roomId = roomId;
            this.maxRoomId = maxRoomId;
        }
        

public void Serialize(IDataWriter writer)
{

base.Serialize(writer);
            ownerInformations.Serialize(writer);
            writer.WriteSByte(theme);
            writer.WriteSByte(roomId);
            writer.WriteSByte(maxRoomId);
            

}

public void Deserialize(IDataReader reader)
{

base.Deserialize(reader);
            ownerInformations = new Types.CharacterMinimalInformations();
            ownerInformations.Deserialize(reader);
            theme = reader.ReadSByte();
            roomId = reader.ReadSByte();
            if (roomId < 0)
                throw new System.Exception("Forbidden value on roomId = " + roomId + ", it doesn't respect the following condition : roomId < 0");
            maxRoomId = reader.ReadSByte();
            if (maxRoomId < 0)
                throw new System.Exception("Forbidden value on maxRoomId = " + maxRoomId + ", it doesn't respect the following condition : maxRoomId < 0");
            

}


}


}