


















// Generated on 07/24/2016 18:36:06
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Types
{

public class CharacterHardcoreOrEpicInformations : CharacterBaseInformations
{

public const short Id = 474;
public override short TypeId
{
    get { return Id; }
}

public sbyte deathState;
        public uint deathCount;
        public byte deathMaxLevel;
        

public CharacterHardcoreOrEpicInformations()
{
}

public CharacterHardcoreOrEpicInformations(double id, string name, byte level, Types.EntityLook entityLook, sbyte breed, bool sex, sbyte deathState, uint deathCount, byte deathMaxLevel)
         : base(id, name, level, entityLook, breed, sex)
        {
            this.deathState = deathState;
            this.deathCount = deathCount;
            this.deathMaxLevel = deathMaxLevel;
        }
        

public override void Serialize(IDataWriter writer)
{

base.Serialize(writer);
            writer.WriteSByte(deathState);
            writer.WriteVarShort((int)deathCount);
            writer.WriteByte(deathMaxLevel);
            

}

public override void Deserialize(IDataReader reader)
{

base.Deserialize(reader);
            deathState = reader.ReadSByte();
            if (deathState < 0)
                throw new System.Exception("Forbidden value on deathState = " + deathState + ", it doesn't respect the following condition : deathState < 0");
            deathCount = reader.ReadVarUhShort();
            if (deathCount < 0)
                throw new System.Exception("Forbidden value on deathCount = " + deathCount + ", it doesn't respect the following condition : deathCount < 0");
            deathMaxLevel = reader.ReadByte();
            if (deathMaxLevel < 1 || deathMaxLevel > 200)
                throw new System.Exception("Forbidden value on deathMaxLevel = " + deathMaxLevel + ", it doesn't respect the following condition : deathMaxLevel < 1 || deathMaxLevel > 200");
            

}


}


}