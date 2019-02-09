


















// Generated on 07/24/2016 18:36:02
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class InventoryPresetUpdateMessage : NetworkMessage
{

public const uint Id = 6171;
public uint MessageId
{
    get { return Id; }
}

public Types.Preset preset;
        

public InventoryPresetUpdateMessage()
{
}

public InventoryPresetUpdateMessage(Types.Preset preset)
        {
            this.preset = preset;
        }
        

public void Serialize(IDataWriter writer)
{

preset.Serialize(writer);
            

}

public void Deserialize(IDataReader reader)
{

preset = new Types.Preset();
            preset.Deserialize(reader);
            

}


}


}