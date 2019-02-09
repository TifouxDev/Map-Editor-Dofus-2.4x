


















// Generated on 07/24/2016 18:35:58
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class TeleportDestinationsListMessage : NetworkMessage
{

public const uint Id = 5960;
public uint MessageId
{
    get { return Id; }
}

public sbyte teleporterType;
        public int[] mapIds;
        public uint[] subAreaIds;
        public uint[] costs;
        public sbyte[] destTeleporterType;
        

public TeleportDestinationsListMessage()
{
}

public TeleportDestinationsListMessage(sbyte teleporterType, int[] mapIds, uint[] subAreaIds, uint[] costs, sbyte[] destTeleporterType)
        {
            this.teleporterType = teleporterType;
            this.mapIds = mapIds;
            this.subAreaIds = subAreaIds;
            this.costs = costs;
            this.destTeleporterType = destTeleporterType;
        }


        public void Serialize(IDataWriter writer)
        {

            writer.WriteSByte(teleporterType);
            writer.WriteShort((short)mapIds.Length);
            foreach (var entry in mapIds)
            {
                writer.WriteInt(entry);
            }
            writer.WriteShort((short)subAreaIds.Length);
            foreach (var entry in subAreaIds)
            {
                writer.WriteVarShort((int)entry);
            }
            writer.WriteShort((short)costs.Length);
            foreach (var entry in costs)
            {
                writer.WriteVarShort((int)entry);
            }
            writer.WriteShort((short)destTeleporterType.Length);
            foreach (var entry in destTeleporterType)
            {
                writer.WriteSByte(entry);
            }


        }

public void Deserialize(IDataReader reader)
{

teleporterType = reader.ReadSByte();
            if (teleporterType < 0)
                throw new System.Exception("Forbidden value on teleporterType = " + teleporterType + ", it doesn't respect the following condition : teleporterType < 0");
            var limit = reader.ReadUShort();
            mapIds = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                 mapIds[i] = reader.ReadInt();
            }
            limit = reader.ReadUShort();
            subAreaIds = new uint[limit];
            for (int i = 0; i < limit; i++)
            {
                 subAreaIds[i] = reader.ReadVarUhShort();
            }
            limit = reader.ReadUShort();
            costs = new uint[limit];
            for (int i = 0; i < limit; i++)
            {
                 costs[i] = reader.ReadVarUhShort();
            }
            limit = reader.ReadUShort();
            destTeleporterType = new sbyte[limit];
            for (int i = 0; i < limit; i++)
            {
                 destTeleporterType[i] = reader.ReadSByte();
            }
            

}


}


}