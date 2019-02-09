


















// Generated on 01/12/2017 03:53:04
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class IdolsPresetUseResultMessage : NetworkMessage
{

public const uint Id = 6614;
public uint MessageId
{
    get { return Id; }
}

public sbyte presetId;
        public sbyte code;
        public uint[] missingIdols;
        

public IdolsPresetUseResultMessage()
{
}

public IdolsPresetUseResultMessage(sbyte presetId, sbyte code, uint[] missingIdols)
        {
            this.presetId = presetId;
            this.code = code;
            this.missingIdols = missingIdols;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteSByte(presetId);
            writer.WriteSByte(code);
            writer.WriteUShort((ushort)missingIdols.Length);
            foreach (var entry in missingIdols)
            {
                 writer.WriteVarShort((int)entry);
            }
            

}

public void Deserialize(IDataReader reader)
{

presetId = reader.ReadSByte();
            if (presetId < 0)
                throw new System.Exception("Forbidden value on presetId = " + presetId + ", it doesn't respect the following condition : presetId < 0");
            code = reader.ReadSByte();
            if (code < 0)
                throw new System.Exception("Forbidden value on code = " + code + ", it doesn't respect the following condition : code < 0");
            var limit = reader.ReadUShort();
            missingIdols = new uint[limit];
            for (int i = 0; i < limit; i++)
            {
                 missingIdols[i] = reader.ReadVarUhShort();
            }
            

}


}


}