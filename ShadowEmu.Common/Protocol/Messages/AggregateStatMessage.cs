


















// Generated on 01/12/2017 03:52:52
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class AggregateStatMessage : NetworkMessage
{

public const uint Id = 6669;
public uint MessageId
{
    get { return Id; }
}

public uint statId;
        

public AggregateStatMessage()
{
}

public AggregateStatMessage(uint statId)
        {
            this.statId = statId;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteVarShort((int)statId);
            

}

public void Deserialize(IDataReader reader)
{

statId = reader.ReadVarUhShort();
            if (statId < 0)
                throw new System.Exception("Forbidden value on statId = " + statId + ", it doesn't respect the following condition : statId < 0");
            

}


}


}