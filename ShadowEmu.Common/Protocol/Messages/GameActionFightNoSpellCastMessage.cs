


















// Generated on 01/12/2017 03:52:53
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class GameActionFightNoSpellCastMessage : NetworkMessage
{

public const uint Id = 6132;
public uint MessageId
{
    get { return Id; }
}

public uint spellLevelId;
        

public GameActionFightNoSpellCastMessage()
{
}

public GameActionFightNoSpellCastMessage(uint spellLevelId)
        {
            this.spellLevelId = spellLevelId;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteVarInt((int)spellLevelId);
            

}

public void Deserialize(IDataReader reader)
{

spellLevelId = reader.ReadVarUhInt();
            if (spellLevelId < 0)
                throw new System.Exception("Forbidden value on spellLevelId = " + spellLevelId + ", it doesn't respect the following condition : spellLevelId < 0");
            

}


}


}