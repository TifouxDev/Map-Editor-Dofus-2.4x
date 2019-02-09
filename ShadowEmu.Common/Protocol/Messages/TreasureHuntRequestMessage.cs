


















// Generated on 01/12/2017 03:52:59
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
            if (questLevel < 1 || questLevel > 206)
                throw new System.Exception("Forbidden value on questLevel = " + questLevel + ", it doesn't respect the following condition : questLevel < 1 || questLevel > 206");
            questType = reader.ReadSByte();
            if (questType < 0)
                throw new System.Exception("Forbidden value on questType = " + questType + ", it doesn't respect the following condition : questType < 0");
            

}


}


}