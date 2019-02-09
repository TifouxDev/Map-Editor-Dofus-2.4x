


















// Generated on 01/12/2017 03:53:06
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Types
{

    public class CharacterSpellModification : NetworkType
    {

        public const short Id = 215;
        public virtual short TypeId
        {
            get { return Id; }
        }

        public sbyte modificationType;
        public uint spellId;
        public Types.CharacterBaseCharacteristic value;


        public CharacterSpellModification()
        {
        }

        public CharacterSpellModification(sbyte modificationType, uint spellId, Types.CharacterBaseCharacteristic value)
        {
            this.modificationType = modificationType;
            this.spellId = spellId;
            this.value = value;
        }


        public virtual void Serialize(IDataWriter writer)
        {

            writer.WriteSByte(modificationType);
            writer.WriteVarShort((int)spellId);
            value.Serialize(writer);


        }

        public virtual void Deserialize(IDataReader reader)
        {

            modificationType = reader.ReadSByte();
            if (modificationType < 0)
                throw new System.Exception("Forbidden value on modificationType = " + modificationType + ", it doesn't respect the following condition : modificationType < 0");
            spellId = reader.ReadVarUhShort();
            if (spellId < 0)
                throw new System.Exception("Forbidden value on spellId = " + spellId + ", it doesn't respect the following condition : spellId < 0");
            value = new Types.CharacterBaseCharacteristic();
            value.Deserialize(reader);


        }


    }


}