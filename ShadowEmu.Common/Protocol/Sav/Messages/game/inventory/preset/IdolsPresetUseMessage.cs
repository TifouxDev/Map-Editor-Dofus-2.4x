


















// Generated on 07/24/2016 18:36:02
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class IdolsPresetUseMessage : NetworkMessage
{

public const uint Id = 6615;
public uint MessageId
{
    get { return Id; }
}

public sbyte presetId;
        public bool party;
        

public IdolsPresetUseMessage()
{
}

public IdolsPresetUseMessage(sbyte presetId, bool party)
        {
            this.presetId = presetId;
            this.party = party;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteSByte(presetId);
            writer.WriteBoolean(party);
            

}

public void Deserialize(IDataReader reader)
{

presetId = reader.ReadSByte();
            if (presetId < 0)
                throw new System.Exception("Forbidden value on presetId = " + presetId + ", it doesn't respect the following condition : presetId < 0");
            party = reader.ReadBoolean();
            

}


}


}