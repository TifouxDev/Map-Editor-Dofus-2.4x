


















// Generated on 07/24/2016 18:35:43
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class AchievementDetailedListRequestMessage : NetworkMessage
{

public const uint Id = 6357;
public uint MessageId
{
    get { return Id; }
}

public uint categoryId;
        

public AchievementDetailedListRequestMessage()
{
}

public AchievementDetailedListRequestMessage(uint categoryId)
        {
            this.categoryId = categoryId;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteVarShort((int)categoryId);
            

}

public void Deserialize(IDataReader reader)
{

categoryId = reader.ReadVarUhShort();
            if (categoryId < 0)
                throw new System.Exception("Forbidden value on categoryId = " + categoryId + ", it doesn't respect the following condition : categoryId < 0");
            

}


}


}