


















// Generated on 01/12/2017 03:52:59
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class SpellVariantActivationMessage : NetworkMessage
{

public const uint Id = 6705;
public uint MessageId
{
    get { return Id; }
}

public bool result;
        public uint activatedSpellId;
        public uint deactivatedSpellId;
        

public SpellVariantActivationMessage()
{
}

public SpellVariantActivationMessage(bool result, uint activatedSpellId, uint deactivatedSpellId)
        {
            this.result = result;
            this.activatedSpellId = activatedSpellId;
            this.deactivatedSpellId = deactivatedSpellId;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteBoolean(result);
            writer.WriteVarShort((int)activatedSpellId);
            writer.WriteVarShort((int)deactivatedSpellId);
            

}

public void Deserialize(IDataReader reader)
{

result = reader.ReadBoolean();
            activatedSpellId = reader.ReadVarUhShort();
            if (activatedSpellId < 0)
                throw new System.Exception("Forbidden value on activatedSpellId = " + activatedSpellId + ", it doesn't respect the following condition : activatedSpellId < 0");
            deactivatedSpellId = reader.ReadVarUhShort();
            if (deactivatedSpellId < 0)
                throw new System.Exception("Forbidden value on deactivatedSpellId = " + deactivatedSpellId + ", it doesn't respect the following condition : deactivatedSpellId < 0");
            

}


}


}