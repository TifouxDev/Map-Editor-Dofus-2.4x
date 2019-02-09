


















// Generated on 01/12/2017 03:53:02
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class ExchangeBidHouseItemRemoveOkMessage : NetworkMessage
{

public const uint Id = 5946;
public uint MessageId
{
    get { return Id; }
}

public int sellerId;
        

public ExchangeBidHouseItemRemoveOkMessage()
{
}

public ExchangeBidHouseItemRemoveOkMessage(int sellerId)
        {
            this.sellerId = sellerId;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteInt(sellerId);
            

}

public void Deserialize(IDataReader reader)
{

sellerId = reader.ReadInt();
            

}


}


}