


















// Generated on 07/24/2016 18:35:43
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class AchievementDetailsRequestMessage : NetworkMessage
{

public const uint Id = 6380;
public uint MessageId
{
    get { return Id; }
}

public uint achievementId;
        

public AchievementDetailsRequestMessage()
{
}

public AchievementDetailsRequestMessage(uint achievementId)
        {
            this.achievementId = achievementId;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteVarShort((int)achievementId);
            

}

public void Deserialize(IDataReader reader)
{

achievementId = reader.ReadVarUhShort();
            if (achievementId < 0)
                throw new System.Exception("Forbidden value on achievementId = " + achievementId + ", it doesn't respect the following condition : achievementId < 0");
            

}


}


}