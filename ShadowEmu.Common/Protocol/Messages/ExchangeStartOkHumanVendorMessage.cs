


















// Generated on 01/12/2017 03:53:03
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class ExchangeStartOkHumanVendorMessage : NetworkMessage
{

public const uint Id = 5767;
public uint MessageId
{
    get { return Id; }
}

public double sellerId;
        public Types.ObjectItemToSellInHumanVendorShop[] objectsInfos;
        

public ExchangeStartOkHumanVendorMessage()
{
}

public ExchangeStartOkHumanVendorMessage(double sellerId, Types.ObjectItemToSellInHumanVendorShop[] objectsInfos)
        {
            this.sellerId = sellerId;
            this.objectsInfos = objectsInfos;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteDouble(sellerId);
            writer.WriteUShort((ushort)objectsInfos.Length);
            foreach (var entry in objectsInfos)
            {
                 entry.Serialize(writer);
            }
            

}

public void Deserialize(IDataReader reader)
{

sellerId = reader.ReadDouble();
            if (sellerId < -9.007199254740992E15 || sellerId > 9.007199254740992E15)
                throw new System.Exception("Forbidden value on sellerId = " + sellerId + ", it doesn't respect the following condition : sellerId < -9.007199254740992E15 || sellerId > 9.007199254740992E15");
            var limit = reader.ReadUShort();
            objectsInfos = new Types.ObjectItemToSellInHumanVendorShop[limit];
            for (int i = 0; i < limit; i++)
            {
                 objectsInfos[i] = new Types.ObjectItemToSellInHumanVendorShop();
                 objectsInfos[i].Deserialize(reader);
            }
            

}


}


}