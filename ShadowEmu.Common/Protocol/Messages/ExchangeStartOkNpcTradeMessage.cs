


















// Generated on 01/12/2017 03:53:03
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class ExchangeStartOkNpcTradeMessage : NetworkMessage
{

public const uint Id = 5785;
public uint MessageId
{
    get { return Id; }
}

public double npcId;
        

public ExchangeStartOkNpcTradeMessage()
{
}

public ExchangeStartOkNpcTradeMessage(double npcId)
        {
            this.npcId = npcId;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteDouble(npcId);
            

}

public void Deserialize(IDataReader reader)
{

npcId = reader.ReadDouble();
            if (npcId < -9.007199254740992E15 || npcId > 9.007199254740992E15)
                throw new System.Exception("Forbidden value on npcId = " + npcId + ", it doesn't respect the following condition : npcId < -9.007199254740992E15 || npcId > 9.007199254740992E15");
            

}


}


}