


















// Generated on 01/12/2017 03:53:09
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Types
{

public class EntityLook : NetworkType
{

public const short Id = 55;
public virtual short TypeId
{
    get { return Id; }
}

public uint bonesId;
        public uint[] skins;
        public int[] indexedColors;
        public int[] scales;
        public Types.SubEntity[] subentities;
        

public EntityLook()
{
}

public EntityLook(uint bonesId, uint[] skins, int[] indexedColors, int[] scales, Types.SubEntity[] subentities)
        {
            this.bonesId = bonesId;
            this.skins = skins;
            this.indexedColors = indexedColors;
            this.scales = scales;
            this.subentities = subentities;
        }
        

public virtual void Serialize(IDataWriter writer)
{

writer.WriteVarShort((int)bonesId);
            writer.WriteUShort((ushort)skins.Length);
            foreach (var entry in skins)
            {
                 writer.WriteVarShort((int)entry);
            }
            writer.WriteUShort((ushort)indexedColors.Length);
            foreach (var entry in indexedColors)
            {
                 writer.WriteInt(entry);
            }
            writer.WriteUShort((ushort)scales.Length);
            foreach (var entry in scales)
            {
                 writer.WriteVarShort((int)entry);
            }
            writer.WriteUShort((ushort)subentities.Length);
            foreach (var entry in subentities)
            {
                 entry.Serialize(writer);
            }
            

}

public virtual void Deserialize(IDataReader reader)
{

bonesId = reader.ReadVarUhShort();
            if (bonesId < 0)
                throw new System.Exception("Forbidden value on bonesId = " + bonesId + ", it doesn't respect the following condition : bonesId < 0");
            var limit = reader.ReadUShort();
            skins = new uint[limit];
            for (int i = 0; i < limit; i++)
            {
                 skins[i] = reader.ReadVarUhShort();
            }
            limit = reader.ReadUShort();
            indexedColors = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                 indexedColors[i] = reader.ReadInt();
            }
            limit = reader.ReadUShort();
            scales = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                 scales[i] = reader.ReadVarShort();
            }
            limit = reader.ReadUShort();
            subentities = new Types.SubEntity[limit];
            for (int i = 0; i < limit; i++)
            {
                 subentities[i] = new Types.SubEntity();
                 subentities[i].Deserialize(reader);
            }
            

}


}


}