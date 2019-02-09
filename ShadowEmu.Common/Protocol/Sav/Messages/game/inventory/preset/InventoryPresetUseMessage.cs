


















// Generated on 07/24/2016 18:36:02
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class InventoryPresetUseMessage : NetworkMessage
{

public const uint Id = 6167;
public uint MessageId
{
    get { return Id; }
}

public sbyte presetId;
        

public InventoryPresetUseMessage()
{
}

public InventoryPresetUseMessage(sbyte presetId)
        {
            this.presetId = presetId;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteSByte(presetId);
            

}

public void Deserialize(IDataReader reader)
{

presetId = reader.ReadSByte();
            if (presetId < 0)
                throw new System.Exception("Forbidden value on presetId = " + presetId + ", it doesn't respect the following condition : presetId < 0");
            

}


}


}