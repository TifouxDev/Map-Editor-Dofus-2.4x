


















// Generated on 01/12/2017 03:52:59
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class TreasureHuntAvailableRetryCountUpdateMessage : NetworkMessage
{

public const uint Id = 6491;
public uint MessageId
{
    get { return Id; }
}

public sbyte questType;
        public int availableRetryCount;
        

public TreasureHuntAvailableRetryCountUpdateMessage()
{
}

public TreasureHuntAvailableRetryCountUpdateMessage(sbyte questType, int availableRetryCount)
        {
            this.questType = questType;
            this.availableRetryCount = availableRetryCount;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteSByte(questType);
            writer.WriteInt(availableRetryCount);
            

}

public void Deserialize(IDataReader reader)
{

questType = reader.ReadSByte();
            if (questType < 0)
                throw new System.Exception("Forbidden value on questType = " + questType + ", it doesn't respect the following condition : questType < 0");
            availableRetryCount = reader.ReadInt();
            

}


}


}