


















// Generated on 01/12/2017 03:53:08
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Types
{

    public class DareCriteria : NetworkType
    {

        public const short Id = 501;
        public virtual short TypeId
        {
            get { return Id; }
        }

        public sbyte type;
        public int[] parameters;


        public DareCriteria()
        {
        }

        public DareCriteria(sbyte type, int[] parameters)
        {
            this.type = type;
            this.parameters = parameters;
        }


        public virtual void Serialize(IDataWriter writer)
        {

            writer.WriteSByte(type);
            writer.WriteUShort((ushort)parameters.Length);
            foreach (var entry in parameters)
            {
                writer.WriteInt(entry);
            }


        }

        public virtual void Deserialize(IDataReader reader)
        {

            type = reader.ReadSByte();
            if (type < 0)
                throw new System.Exception("Forbidden value on type = " + type + ", it doesn't respect the following condition : type < 0");
            var limit = reader.ReadUShort();
            parameters = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                parameters[i] = reader.ReadInt();
            }


        }


    }


}