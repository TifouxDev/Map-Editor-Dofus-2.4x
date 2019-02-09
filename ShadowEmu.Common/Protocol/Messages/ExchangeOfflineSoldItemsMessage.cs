


















// Generated on 01/12/2017 03:53:02
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class ExchangeOfflineSoldItemsMessage : NetworkMessage
{

public const uint Id = 6613;
public uint MessageId
{
    get { return Id; }
}

public Types.ObjectItemGenericQuantityPrice[] bidHouseItems;
        public Types.ObjectItemGenericQuantityPrice[] merchantItems;
        

public ExchangeOfflineSoldItemsMessage()
{
}

public ExchangeOfflineSoldItemsMessage(Types.ObjectItemGenericQuantityPrice[] bidHouseItems, Types.ObjectItemGenericQuantityPrice[] merchantItems)
        {
            this.bidHouseItems = bidHouseItems;
            this.merchantItems = merchantItems;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteUShort((ushort)bidHouseItems.Length);
            foreach (var entry in bidHouseItems)
            {
                 entry.Serialize(writer);
            }
            writer.WriteUShort((ushort)merchantItems.Length);
            foreach (var entry in merchantItems)
            {
                 entry.Serialize(writer);
            }
            

}

public void Deserialize(IDataReader reader)
{

var limit = reader.ReadUShort();
            bidHouseItems = new Types.ObjectItemGenericQuantityPrice[limit];
            for (int i = 0; i < limit; i++)
            {
                 bidHouseItems[i] = new Types.ObjectItemGenericQuantityPrice();
                 bidHouseItems[i].Deserialize(reader);
            }
            limit = reader.ReadUShort();
            merchantItems = new Types.ObjectItemGenericQuantityPrice[limit];
            for (int i = 0; i < limit; i++)
            {
                 merchantItems[i] = new Types.ObjectItemGenericQuantityPrice();
                 merchantItems[i].Deserialize(reader);
            }
            

}


}


}