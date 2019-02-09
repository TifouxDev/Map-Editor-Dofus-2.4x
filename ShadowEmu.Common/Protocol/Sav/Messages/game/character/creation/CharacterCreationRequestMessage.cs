


















// Generated on 07/24/2016 18:35:47
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

    public class CharacterCreationRequestMessage : NetworkMessage
    {

        public const uint Id = 160;
        public uint MessageId
        {
            get { return Id; }
        }

        public string name;
        public sbyte breed;
        public bool sex;
        public int[] colors;
        public uint cosmeticId;


        public CharacterCreationRequestMessage()
        {
        }

        public CharacterCreationRequestMessage(string name, sbyte breed, bool sex, int[] colors, uint cosmeticId)
        {
            this.name = name;
            this.breed = breed;
            this.sex = sex;
            this.colors = colors;
            this.cosmeticId = cosmeticId;
        }


        public void Serialize(IDataWriter writer)
        {

            writer.WriteUTF(name);
            writer.WriteSByte(breed);
            writer.WriteBoolean(sex);
            writer.WriteUShort((ushort)colors.Length);
            foreach (var entry in colors)
            {
                writer.WriteInt(entry);
            }
            writer.WriteVarShort((int)cosmeticId);


        }

        public void Deserialize(IDataReader reader)
        {

            name = reader.ReadUTF();
            breed = reader.ReadSByte();
            if (breed < (byte)Enums.PlayableBreedEnum.Feca || breed > (byte)Enums.PlayableBreedEnum.Huppermage)
                throw new System.Exception("Forbidden value on breed = " + breed + ", it doesn't respect the following condition : breed < (byte)Enums.PlayableBreedEnum.Feca || breed > (byte)Enums.PlayableBreedEnum.Huppermage");
            sex = reader.ReadBoolean();
            colors = new int[5];
            for (int i = 0; i < 5; i++)
            {
                colors[i] = reader.ReadInt();
            }
            cosmeticId = reader.ReadVarUhShort();
            if (cosmeticId < 0)
                throw new System.Exception("Forbidden value on cosmeticId = " + cosmeticId + ", it doesn't respect the following condition : cosmeticId < 0");


        }


    }


}