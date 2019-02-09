


















// Generated on 01/12/2017 03:53:02
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class ExchangeGuildTaxCollectorGetMessage : NetworkMessage
{

public const uint Id = 5762;
public uint MessageId
{
    get { return Id; }
}

public string collectorName;
        public short worldX;
        public short worldY;
        public int mapId;
        public uint subAreaId;
        public string userName;
        public double callerId;
        public string callerName;
        public double experience;
        public uint pods;
        public Types.ObjectItemGenericQuantity[] objectsInfos;
        

public ExchangeGuildTaxCollectorGetMessage()
{
}

public ExchangeGuildTaxCollectorGetMessage(string collectorName, short worldX, short worldY, int mapId, uint subAreaId, string userName, double callerId, string callerName, double experience, uint pods, Types.ObjectItemGenericQuantity[] objectsInfos)
        {
            this.collectorName = collectorName;
            this.worldX = worldX;
            this.worldY = worldY;
            this.mapId = mapId;
            this.subAreaId = subAreaId;
            this.userName = userName;
            this.callerId = callerId;
            this.callerName = callerName;
            this.experience = experience;
            this.pods = pods;
            this.objectsInfos = objectsInfos;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteUTF(collectorName);
            writer.WriteShort(worldX);
            writer.WriteShort(worldY);
            writer.WriteInt(mapId);
            writer.WriteVarShort((int)subAreaId);
            writer.WriteUTF(userName);
            writer.WriteVarLong(callerId);
            writer.WriteUTF(callerName);
            writer.WriteDouble(experience);
            writer.WriteVarShort((int)pods);
            writer.WriteUShort((ushort)objectsInfos.Length);
            foreach (var entry in objectsInfos)
            {
                 entry.Serialize(writer);
            }
            

}

public void Deserialize(IDataReader reader)
{

collectorName = reader.ReadUTF();
            worldX = reader.ReadShort();
            if (worldX < -255 || worldX > 255)
                throw new System.Exception("Forbidden value on worldX = " + worldX + ", it doesn't respect the following condition : worldX < -255 || worldX > 255");
            worldY = reader.ReadShort();
            if (worldY < -255 || worldY > 255)
                throw new System.Exception("Forbidden value on worldY = " + worldY + ", it doesn't respect the following condition : worldY < -255 || worldY > 255");
            mapId = reader.ReadInt();
            subAreaId = reader.ReadVarUhShort();
            if (subAreaId < 0)
                throw new System.Exception("Forbidden value on subAreaId = " + subAreaId + ", it doesn't respect the following condition : subAreaId < 0");
            userName = reader.ReadUTF();
            callerId = reader.ReadVarUhLong();
            if (callerId < 0 || callerId > 9.007199254740992E15)
                throw new System.Exception("Forbidden value on callerId = " + callerId + ", it doesn't respect the following condition : callerId < 0 || callerId > 9.007199254740992E15");
            callerName = reader.ReadUTF();
            experience = reader.ReadDouble();
            if (experience < -9.007199254740992E15 || experience > 9.007199254740992E15)
                throw new System.Exception("Forbidden value on experience = " + experience + ", it doesn't respect the following condition : experience < -9.007199254740992E15 || experience > 9.007199254740992E15");
            pods = reader.ReadVarUhShort();
            if (pods < 0)
                throw new System.Exception("Forbidden value on pods = " + pods + ", it doesn't respect the following condition : pods < 0");
            var limit = reader.ReadUShort();
            objectsInfos = new Types.ObjectItemGenericQuantity[limit];
            for (int i = 0; i < limit; i++)
            {
                 objectsInfos[i] = new Types.ObjectItemGenericQuantity();
                 objectsInfos[i].Deserialize(reader);
            }
            

}


}


}