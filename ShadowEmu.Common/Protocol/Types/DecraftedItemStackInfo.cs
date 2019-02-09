


















// Generated on 01/12/2017 03:53:08
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Types
{

public class DecraftedItemStackInfo : NetworkType
{

public const short Id = 481;
public virtual short TypeId
{
    get { return Id; }
}

public uint objectUID;
        public float bonusMin;
        public float bonusMax;
        public uint[] runesId;
        public uint[] runesQty;
        

public DecraftedItemStackInfo()
{
}

public DecraftedItemStackInfo(uint objectUID, float bonusMin, float bonusMax, uint[] runesId, uint[] runesQty)
        {
            this.objectUID = objectUID;
            this.bonusMin = bonusMin;
            this.bonusMax = bonusMax;
            this.runesId = runesId;
            this.runesQty = runesQty;
        }
        

public virtual void Serialize(IDataWriter writer)
{

writer.WriteVarInt((int)objectUID);
            writer.WriteFloat(bonusMin);
            writer.WriteFloat(bonusMax);
            writer.WriteUShort((ushort)runesId.Length);
            foreach (var entry in runesId)
            {
                 writer.WriteVarShort((int)entry);
            }
            writer.WriteUShort((ushort)runesQty.Length);
            foreach (var entry in runesQty)
            {
                 writer.WriteVarInt((int)entry);
            }
            

}

public virtual void Deserialize(IDataReader reader)
{

objectUID = reader.ReadVarUhInt();
            if (objectUID < 0)
                throw new System.Exception("Forbidden value on objectUID = " + objectUID + ", it doesn't respect the following condition : objectUID < 0");
            bonusMin = reader.ReadFloat();
            bonusMax = reader.ReadFloat();
            var limit = reader.ReadUShort();
            runesId = new uint[limit];
            for (int i = 0; i < limit; i++)
            {
                 runesId[i] = reader.ReadVarUhShort();
            }
            limit = reader.ReadUShort();
            runesQty = new uint[limit];
            for (int i = 0; i < limit; i++)
            {
                 runesQty[i] = reader.ReadVarUhInt();
            }
            

}


}


}