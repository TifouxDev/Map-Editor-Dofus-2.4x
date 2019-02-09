


















// Generated on 01/12/2017 03:53:02
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class ExchangeBidHouseInListUpdatedMessage : ExchangeBidHouseInListAddedMessage
{

public const uint Id = 6337;
public uint MessageId
{
    get { return Id; }
}



public ExchangeBidHouseInListUpdatedMessage()
{
}

public ExchangeBidHouseInListUpdatedMessage(int itemUID, int objGenericId, Types.ObjectEffect[] effects, uint[] prices)
         : base(itemUID, objGenericId, effects, prices)
        {
        }
        

public void Serialize(IDataWriter writer)
{

base.Serialize(writer);
            

}

public void Deserialize(IDataReader reader)
{

base.Deserialize(reader);
            

}


}


}