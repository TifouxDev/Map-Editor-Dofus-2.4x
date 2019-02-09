


















// Generated on 01/12/2017 03:53:03
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class InventoryContentAndPresetMessage : InventoryContentMessage
{

public const uint Id = 6162;
public uint MessageId
{
    get { return Id; }
}

public Types.Preset[] presets;
        public Types.IdolsPreset[] idolsPresets;
        

public InventoryContentAndPresetMessage()
{
}

public InventoryContentAndPresetMessage(Types.ObjectItem[] objects, uint kamas, Types.Preset[] presets, Types.IdolsPreset[] idolsPresets)
         : base(objects, kamas)
        {
            this.presets = presets;
            this.idolsPresets = idolsPresets;
        }
        

public void Serialize(IDataWriter writer)
{

base.Serialize(writer);
            writer.WriteUShort((ushort)presets.Length);
            foreach (var entry in presets)
            {
                 entry.Serialize(writer);
            }
            writer.WriteUShort((ushort)idolsPresets.Length);
            foreach (var entry in idolsPresets)
            {
                 entry.Serialize(writer);
            }
            

}

public void Deserialize(IDataReader reader)
{

base.Deserialize(reader);
            var limit = reader.ReadUShort();
            presets = new Types.Preset[limit];
            for (int i = 0; i < limit; i++)
            {
                 presets[i] = new Types.Preset();
                 presets[i].Deserialize(reader);
            }
            limit = reader.ReadUShort();
            idolsPresets = new Types.IdolsPreset[limit];
            for (int i = 0; i < limit; i++)
            {
                 idolsPresets[i] = new Types.IdolsPreset();
                 idolsPresets[i].Deserialize(reader);
            }
            

}


}


}