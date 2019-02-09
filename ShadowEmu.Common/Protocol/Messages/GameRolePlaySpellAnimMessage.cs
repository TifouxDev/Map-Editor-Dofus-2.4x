


















// Generated on 01/12/2017 03:52:59
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class GameRolePlaySpellAnimMessage : NetworkMessage
{

public const uint Id = 6114;
public uint MessageId
{
    get { return Id; }
}

public double casterId;
        public uint targetCellId;
        public uint spellId;
        public short spellLevel;
        

public GameRolePlaySpellAnimMessage()
{
}

public GameRolePlaySpellAnimMessage(double casterId, uint targetCellId, uint spellId, short spellLevel)
        {
            this.casterId = casterId;
            this.targetCellId = targetCellId;
            this.spellId = spellId;
            this.spellLevel = spellLevel;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteVarLong(casterId);
            writer.WriteVarShort((int)targetCellId);
            writer.WriteVarShort((int)spellId);
            writer.WriteShort(spellLevel);
            

}

public void Deserialize(IDataReader reader)
{

casterId = reader.ReadVarUhLong();
            if (casterId < 0 || casterId > 9.007199254740992E15)
                throw new System.Exception("Forbidden value on casterId = " + casterId + ", it doesn't respect the following condition : casterId < 0 || casterId > 9.007199254740992E15");
            targetCellId = reader.ReadVarUhShort();
            if (targetCellId < 0 || targetCellId > 559)
                throw new System.Exception("Forbidden value on targetCellId = " + targetCellId + ", it doesn't respect the following condition : targetCellId < 0 || targetCellId > 559");
            spellId = reader.ReadVarUhShort();
            if (spellId < 0)
                throw new System.Exception("Forbidden value on spellId = " + spellId + ", it doesn't respect the following condition : spellId < 0");
            spellLevel = reader.ReadShort();
            if (spellLevel < 1 || spellLevel > 200)
                throw new System.Exception("Forbidden value on spellLevel = " + spellLevel + ", it doesn't respect the following condition : spellLevel < 1 || spellLevel > 200");
            

}


}


}