


















// Generated on 01/12/2017 03:52:57
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class HouseBuyRequestMessage : NetworkMessage
{

public const uint Id = 5738;
public uint MessageId
{
    get { return Id; }
}

public uint proposedPrice;
        

public HouseBuyRequestMessage()
{
}

public HouseBuyRequestMessage(uint proposedPrice)
        {
            this.proposedPrice = proposedPrice;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteVarInt((int)proposedPrice);
            

}

public void Deserialize(IDataReader reader)
{

proposedPrice = reader.ReadVarUhInt();
            if (proposedPrice < 0)
                throw new System.Exception("Forbidden value on proposedPrice = " + proposedPrice + ", it doesn't respect the following condition : proposedPrice < 0");
            

}


}


}