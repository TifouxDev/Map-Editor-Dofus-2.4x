


















// Generated on 01/12/2017 03:52:59
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class QuestStepInfoRequestMessage : NetworkMessage
{

public const uint Id = 5622;
public uint MessageId
{
    get { return Id; }
}

public uint questId;
        

public QuestStepInfoRequestMessage()
{
}

public QuestStepInfoRequestMessage(uint questId)
        {
            this.questId = questId;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteVarShort((int)questId);
            

}

public void Deserialize(IDataReader reader)
{

questId = reader.ReadVarUhShort();
            if (questId < 0)
                throw new System.Exception("Forbidden value on questId = " + questId + ", it doesn't respect the following condition : questId < 0");
            

}


}


}