


















// Generated on 01/12/2017 03:53:09
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Types
{

public class IdolsPreset : NetworkType
{

public const short Id = 491;
public virtual short TypeId
{
    get { return Id; }
}

public sbyte presetId;
        public sbyte symbolId;
        public uint[] idolId;
        

public IdolsPreset()
{
}

public IdolsPreset(sbyte presetId, sbyte symbolId, uint[] idolId)
        {
            this.presetId = presetId;
            this.symbolId = symbolId;
            this.idolId = idolId;
        }
        

public virtual void Serialize(IDataWriter writer)
{

writer.WriteSByte(presetId);
            writer.WriteSByte(symbolId);
            writer.WriteUShort((ushort)idolId.Length);
            foreach (var entry in idolId)
            {
                 writer.WriteVarShort((int)entry);
            }
            

}

public virtual void Deserialize(IDataReader reader)
{

presetId = reader.ReadSByte();
            if (presetId < 0)
                throw new System.Exception("Forbidden value on presetId = " + presetId + ", it doesn't respect the following condition : presetId < 0");
            symbolId = reader.ReadSByte();
            if (symbolId < 0)
                throw new System.Exception("Forbidden value on symbolId = " + symbolId + ", it doesn't respect the following condition : symbolId < 0");
            var limit = reader.ReadUShort();
            idolId = new uint[limit];
            for (int i = 0; i < limit; i++)
            {
                 idolId[i] = reader.ReadVarUhShort();
            }
            

}


}


}