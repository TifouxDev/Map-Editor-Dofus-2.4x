


















// Generated on 07/24/2016 18:36:08
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
        public int[] _params;
        

public DareCriteria()
{
}

public DareCriteria(sbyte type, int[] __params)
        {
            this.type = type;
            this._params = __params;
        }
        

public virtual void Serialize(IDataWriter writer)
{

writer.WriteSByte(type);
            writer.WriteUShort((ushort)_params.Length);
            foreach (var entry in _params)
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
            _params = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                 _params[i] = reader.ReadInt();
            }
            

}


}


}