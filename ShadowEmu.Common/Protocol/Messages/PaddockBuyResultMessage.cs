


















// Generated on 01/12/2017 03:52:56
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class PaddockBuyResultMessage : NetworkMessage
{

public const uint Id = 6516;
public uint MessageId
{
    get { return Id; }
}

public int paddockId;
        public bool bought;
        public uint realPrice;
        

public PaddockBuyResultMessage()
{
}

public PaddockBuyResultMessage(int paddockId, bool bought, uint realPrice)
        {
            this.paddockId = paddockId;
            this.bought = bought;
            this.realPrice = realPrice;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteInt(paddockId);
            writer.WriteBoolean(bought);
            writer.WriteVarInt((int)realPrice);
            

}

public void Deserialize(IDataReader reader)
{

paddockId = reader.ReadInt();
            bought = reader.ReadBoolean();
            realPrice = reader.ReadVarUhInt();
            if (realPrice < 0)
                throw new System.Exception("Forbidden value on realPrice = " + realPrice + ", it doesn't respect the following condition : realPrice < 0");
            

}


}


}