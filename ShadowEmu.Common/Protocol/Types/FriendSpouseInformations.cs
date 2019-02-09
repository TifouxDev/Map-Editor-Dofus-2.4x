


















// Generated on 01/12/2017 03:53:09
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Types
{

public class FriendSpouseInformations : NetworkType
{

public const short Id = 77;
public virtual short TypeId
{
    get { return Id; }
}

public int spouseAccountId;
        public double spouseId;
        public string spouseName;
        public byte spouseLevel;
        public sbyte breed;
        public sbyte sex;
        public Types.EntityLook spouseEntityLook;
        public Types.GuildInformations guildInfo;
        public sbyte alignmentSide;
        

public FriendSpouseInformations()
{
}

public FriendSpouseInformations(int spouseAccountId, double spouseId, string spouseName, byte spouseLevel, sbyte breed, sbyte sex, Types.EntityLook spouseEntityLook, Types.GuildInformations guildInfo, sbyte alignmentSide)
        {
            this.spouseAccountId = spouseAccountId;
            this.spouseId = spouseId;
            this.spouseName = spouseName;
            this.spouseLevel = spouseLevel;
            this.breed = breed;
            this.sex = sex;
            this.spouseEntityLook = spouseEntityLook;
            this.guildInfo = guildInfo;
            this.alignmentSide = alignmentSide;
        }
        

public virtual void Serialize(IDataWriter writer)
{

writer.WriteInt(spouseAccountId);
            writer.WriteVarLong(spouseId);
            writer.WriteUTF(spouseName);
            writer.WriteByte(spouseLevel);
            writer.WriteSByte(breed);
            writer.WriteSByte(sex);
            spouseEntityLook.Serialize(writer);
            guildInfo.Serialize(writer);
            writer.WriteSByte(alignmentSide);
            

}

public virtual void Deserialize(IDataReader reader)
{

spouseAccountId = reader.ReadInt();
            if (spouseAccountId < 0)
                throw new System.Exception("Forbidden value on spouseAccountId = " + spouseAccountId + ", it doesn't respect the following condition : spouseAccountId < 0");
            spouseId = reader.ReadVarUhLong();
            if (spouseId < 0 || spouseId > 9.007199254740992E15)
                throw new System.Exception("Forbidden value on spouseId = " + spouseId + ", it doesn't respect the following condition : spouseId < 0 || spouseId > 9.007199254740992E15");
            spouseName = reader.ReadUTF();
            spouseLevel = reader.ReadByte();
            if (spouseLevel < 1 || spouseLevel > 206)
                throw new System.Exception("Forbidden value on spouseLevel = " + spouseLevel + ", it doesn't respect the following condition : spouseLevel < 1 || spouseLevel > 206");
            breed = reader.ReadSByte();
            sex = reader.ReadSByte();
            spouseEntityLook = new Types.EntityLook();
            spouseEntityLook.Deserialize(reader);
            guildInfo = new Types.GuildInformations();
            guildInfo.Deserialize(reader);
            alignmentSide = reader.ReadSByte();
            

}


}


}