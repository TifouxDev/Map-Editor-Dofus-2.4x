


















// Generated on 01/12/2017 03:53:08
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Types
{

public class QuestActiveInformations : NetworkType
{

public const short Id = 381;
public virtual short TypeId
{
    get { return Id; }
}

public uint questId;
        

public QuestActiveInformations()
{
}

public QuestActiveInformations(uint questId)
        {
            this.questId = questId;
        }
        

public virtual void Serialize(IDataWriter writer)
{

writer.WriteVarShort((int)questId);
            

}

public virtual void Deserialize(IDataReader reader)
{

questId = reader.ReadVarUhShort();
            if (questId < 0)
                throw new System.Exception("Forbidden value on questId = " + questId + ", it doesn't respect the following condition : questId < 0");
            

}


}


}