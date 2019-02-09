


















// Generated on 07/24/2016 18:35:59
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class ExchangeBidHouseUnsoldItemsMessage : NetworkMessage
{

public const uint Id = 6612;
public uint MessageId
{
    get { return Id; }
}

public Types.ObjectItemGenericQuantity[] items;
        

public ExchangeBidHouseUnsoldItemsMessage()
{
}

public ExchangeBidHouseUnsoldItemsMessage(Types.ObjectItemGenericQuantity[] items)
        {
            this.items = items;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteUShort((ushort)items.Length);
            foreach (var entry in items)
            {
                 entry.Serialize(writer);
            }
            

}

public void Deserialize(IDataReader reader)
{

var limit = reader.ReadUShort();
            items = new Types.ObjectItemGenericQuantity[limit];
            for (int i = 0; i < limit; i++)
            {
                 items[i] = new Types.ObjectItemGenericQuantity();
                 items[i].Deserialize(reader);
            }
            

}


}


}