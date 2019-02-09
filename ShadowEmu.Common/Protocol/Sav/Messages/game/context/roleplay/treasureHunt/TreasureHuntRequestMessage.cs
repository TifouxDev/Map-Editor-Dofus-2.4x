


















// Generated on 07/24/2016 18:35:55
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class TreasureHuntRequestMessage : NetworkMessage
{

public const uint Id = 6488;
public uint MessageId
{
    get { return Id; }
}

public byte questLevel;
        public sbyte questType;
        

public TreasureHuntRequestMessage()
{
}

public TreasureHuntRequestMessage(byte questLevel, sbyte questType)
        {
            this.questLevel = questLevel;
            this.questType = questType;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteByte(questLevel);
            writer.WriteSByte(questType);
            

}

public void Deserialize(IDataReader reader)
{

questLevel = reader.ReadByte();
            if (questLevel < 1 || questLevel > 200)
                throw new System.Exception("Forbidden value on questLevel = " + questLevel + ", it doesn't respect the following condition : questLevel < 1 || questLevel > 200");
            questType = reader.ReadSByte();
            if (questType < 0)
                throw new System.Exception("Forbidden value on questType = " + questType + ", it doesn't respect the following condition : questType < 0");
            

}


}


}