


















// Generated on 01/12/2017 03:52:59
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class SpellVariantActivationRequestMessage : NetworkMessage
{

public const uint Id = 6707;
public uint MessageId
{
    get { return Id; }
}

public uint spellId;
        

public SpellVariantActivationRequestMessage()
{
}

public SpellVariantActivationRequestMessage(uint spellId)
        {
            this.spellId = spellId;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteVarShort((int)spellId);
            

}

public void Deserialize(IDataReader reader)
{

spellId = reader.ReadVarUhShort();
            if (spellId < 0)
                throw new System.Exception("Forbidden value on spellId = " + spellId + ", it doesn't respect the following condition : spellId < 0");
            

}


}


}