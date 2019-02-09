


















// Generated on 01/12/2017 03:53:04
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class InventoryPresetItemUpdateMessage : NetworkMessage
{

public const uint Id = 6168;
public uint MessageId
{
    get { return Id; }
}

public sbyte presetId;
        public Types.PresetItem presetItem;
        

public InventoryPresetItemUpdateMessage()
{
}

public InventoryPresetItemUpdateMessage(sbyte presetId, Types.PresetItem presetItem)
        {
            this.presetId = presetId;
            this.presetItem = presetItem;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteSByte(presetId);
            presetItem.Serialize(writer);
            

}

public void Deserialize(IDataReader reader)
{

presetId = reader.ReadSByte();
            if (presetId < 0)
                throw new System.Exception("Forbidden value on presetId = " + presetId + ", it doesn't respect the following condition : presetId < 0");
            presetItem = new Types.PresetItem();
            presetItem.Deserialize(reader);
            

}


}


}