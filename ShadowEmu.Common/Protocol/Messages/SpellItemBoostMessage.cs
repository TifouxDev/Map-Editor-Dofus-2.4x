


















// Generated on 01/12/2017 03:52:59
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class SpellItemBoostMessage : NetworkMessage
{

public const uint Id = 6011;
public uint MessageId
{
    get { return Id; }
}

public uint statId;
        public uint spellId;
        public int value;
        

public SpellItemBoostMessage()
{
}

public SpellItemBoostMessage(uint statId, uint spellId, int value)
        {
            this.statId = statId;
            this.spellId = spellId;
            this.value = value;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteVarInt((int)statId);
            writer.WriteVarShort((int)spellId);
            writer.WriteVarShort((int)value);
            

}

public void Deserialize(IDataReader reader)
{

statId = reader.ReadVarUhInt();
            if (statId < 0)
                throw new System.Exception("Forbidden value on statId = " + statId + ", it doesn't respect the following condition : statId < 0");
            spellId = reader.ReadVarUhShort();
            if (spellId < 0)
                throw new System.Exception("Forbidden value on spellId = " + spellId + ", it doesn't respect the following condition : spellId < 0");
            value = reader.ReadVarShort();
            

}


}


}