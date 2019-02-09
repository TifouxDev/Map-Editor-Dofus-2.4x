


















// Generated on 01/12/2017 03:53:06
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Types
{

public class CharacterBaseInformations : CharacterMinimalPlusLookInformations
{

public const short Id = 45;
public override short TypeId
{
    get { return Id; }
}

public byte breed;
        public bool sex;
        

public CharacterBaseInformations()
{
}

public CharacterBaseInformations(double id, string name, byte level, Types.EntityLook entityLook, byte breed, bool sex)
         : base(id, name, level, entityLook)
        {
            this.breed = breed;
            this.sex = sex;
        }
        

public override void Serialize(IDataWriter writer)
{

base.Serialize(writer);
            writer.WriteByte(breed);
            writer.WriteBoolean(sex);
            

}

public override void Deserialize(IDataReader reader)
{

base.Deserialize(reader);
            breed = reader.ReadByte();
            sex = reader.ReadBoolean();
            

}


}


}