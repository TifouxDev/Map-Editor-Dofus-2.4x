


















// Generated on 01/12/2017 03:53:02
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class ExchangeBidHousePriceMessage : NetworkMessage
{

public const uint Id = 5805;
public uint MessageId
{
    get { return Id; }
}

public uint genId;
        

public ExchangeBidHousePriceMessage()
{
}

public ExchangeBidHousePriceMessage(uint genId)
        {
            this.genId = genId;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteVarShort((int)genId);
            

}

public void Deserialize(IDataReader reader)
{

genId = reader.ReadVarUhShort();
            if (genId < 0)
                throw new System.Exception("Forbidden value on genId = " + genId + ", it doesn't respect the following condition : genId < 0");
            

}


}


}