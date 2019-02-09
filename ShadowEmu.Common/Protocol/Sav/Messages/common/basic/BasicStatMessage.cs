


















// Generated on 07/24/2016 18:35:43
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class BasicStatMessage : NetworkMessage
{

public const uint Id = 6530;
public uint MessageId
{
    get { return Id; }
}

public double timeSpent;
        public uint statId;
        

public BasicStatMessage()
{
}

public BasicStatMessage(double timeSpent, uint statId)
        {
            this.timeSpent = timeSpent;
            this.statId = statId;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteDouble(timeSpent);
            writer.WriteVarShort((int)statId);
            

}

public void Deserialize(IDataReader reader)
{

timeSpent = reader.ReadDouble();
            if (timeSpent < 0 || timeSpent > 9.007199254740992E15)
                throw new System.Exception("Forbidden value on timeSpent = " + timeSpent + ", it doesn't respect the following condition : timeSpent < 0 || timeSpent > 9.007199254740992E15");
            statId = reader.ReadVarUhShort();
            if (statId < 0)
                throw new System.Exception("Forbidden value on statId = " + statId + ", it doesn't respect the following condition : statId < 0");
            

}


}


}