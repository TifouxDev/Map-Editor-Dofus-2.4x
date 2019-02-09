


















// Generated on 01/12/2017 03:53:07
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Types
{

public class GameFightSpellCooldown : NetworkType
{

public const short Id = 205;
public virtual short TypeId
{
    get { return Id; }
}

public int spellId;
        public sbyte cooldown;
        

public GameFightSpellCooldown()
{
}

public GameFightSpellCooldown(int spellId, sbyte cooldown)
        {
            this.spellId = spellId;
            this.cooldown = cooldown;
        }
        

public virtual void Serialize(IDataWriter writer)
{

writer.WriteInt(spellId);
            writer.WriteSByte(cooldown);
            

}

public virtual void Deserialize(IDataReader reader)
{

spellId = reader.ReadInt();
            cooldown = reader.ReadSByte();
            if (cooldown < 0)
                throw new System.Exception("Forbidden value on cooldown = " + cooldown + ", it doesn't respect the following condition : cooldown < 0");
            

}


}


}