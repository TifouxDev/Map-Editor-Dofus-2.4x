


















// Generated on 01/12/2017 03:53:04
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class IdolsPresetSaveMessage : NetworkMessage
{

public const uint Id = 6603;
public uint MessageId
{
    get { return Id; }
}

public sbyte presetId;
        public sbyte symbolId;
        

public IdolsPresetSaveMessage()
{
}

public IdolsPresetSaveMessage(sbyte presetId, sbyte symbolId)
        {
            this.presetId = presetId;
            this.symbolId = symbolId;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteSByte(presetId);
            writer.WriteSByte(symbolId);
            

}

public void Deserialize(IDataReader reader)
{

presetId = reader.ReadSByte();
            if (presetId < 0)
                throw new System.Exception("Forbidden value on presetId = " + presetId + ", it doesn't respect the following condition : presetId < 0");
            symbolId = reader.ReadSByte();
            if (symbolId < 0)
                throw new System.Exception("Forbidden value on symbolId = " + symbolId + ", it doesn't respect the following condition : symbolId < 0");
            

}


}


}