


















// Generated on 01/12/2017 03:53:09
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Types
{

public class HouseInformationsForSell : NetworkType
{

public const short Id = 221;
public virtual short TypeId
{
    get { return Id; }
}

public uint modelId;
        public string ownerName;
        public bool ownerConnected;
        public short worldX;
        public short worldY;
        public uint subAreaId;
        public sbyte nbRoom;
        public sbyte nbChest;
        public int[] skillListIds;
        public bool isLocked;
        public uint price;
        

public HouseInformationsForSell()
{
}

public HouseInformationsForSell(uint modelId, string ownerName, bool ownerConnected, short worldX, short worldY, uint subAreaId, sbyte nbRoom, sbyte nbChest, int[] skillListIds, bool isLocked, uint price)
        {
            this.modelId = modelId;
            this.ownerName = ownerName;
            this.ownerConnected = ownerConnected;
            this.worldX = worldX;
            this.worldY = worldY;
            this.subAreaId = subAreaId;
            this.nbRoom = nbRoom;
            this.nbChest = nbChest;
            this.skillListIds = skillListIds;
            this.isLocked = isLocked;
            this.price = price;
        }
        

public virtual void Serialize(IDataWriter writer)
{

writer.WriteVarInt((int)modelId);
            writer.WriteUTF(ownerName);
            writer.WriteBoolean(ownerConnected);
            writer.WriteShort(worldX);
            writer.WriteShort(worldY);
            writer.WriteVarShort((int)subAreaId);
            writer.WriteSByte(nbRoom);
            writer.WriteSByte(nbChest);
            writer.WriteUShort((ushort)skillListIds.Length);
            foreach (var entry in skillListIds)
            {
                 writer.WriteInt(entry);
            }
            writer.WriteBoolean(isLocked);
            writer.WriteVarInt((int)price);
            

}

public virtual void Deserialize(IDataReader reader)
{

modelId = reader.ReadVarUhInt();
            if (modelId < 0)
                throw new System.Exception("Forbidden value on modelId = " + modelId + ", it doesn't respect the following condition : modelId < 0");
            ownerName = reader.ReadUTF();
            ownerConnected = reader.ReadBoolean();
            worldX = reader.ReadShort();
            if (worldX < -255 || worldX > 255)
                throw new System.Exception("Forbidden value on worldX = " + worldX + ", it doesn't respect the following condition : worldX < -255 || worldX > 255");
            worldY = reader.ReadShort();
            if (worldY < -255 || worldY > 255)
                throw new System.Exception("Forbidden value on worldY = " + worldY + ", it doesn't respect the following condition : worldY < -255 || worldY > 255");
            subAreaId = reader.ReadVarUhShort();
            if (subAreaId < 0)
                throw new System.Exception("Forbidden value on subAreaId = " + subAreaId + ", it doesn't respect the following condition : subAreaId < 0");
            nbRoom = reader.ReadSByte();
            nbChest = reader.ReadSByte();
            var limit = reader.ReadUShort();
            skillListIds = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                 skillListIds[i] = reader.ReadInt();
            }
            isLocked = reader.ReadBoolean();
            price = reader.ReadVarUhInt();
            if (price < 0)
                throw new System.Exception("Forbidden value on price = " + price + ", it doesn't respect the following condition : price < 0");
            

}


}


}