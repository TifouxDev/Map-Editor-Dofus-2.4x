


















// Generated on 07/24/2016 18:36:01
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class RecycleResultMessage : NetworkMessage
{

public const uint Id = 6601;
public uint MessageId
{
    get { return Id; }
}

public uint nuggetsForPrism;
        public uint nuggetsForPlayer;
        

public RecycleResultMessage()
{
}

public RecycleResultMessage(uint nuggetsForPrism, uint nuggetsForPlayer)
        {
            this.nuggetsForPrism = nuggetsForPrism;
            this.nuggetsForPlayer = nuggetsForPlayer;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteVarInt((int)nuggetsForPrism);
            writer.WriteVarInt((int)nuggetsForPlayer);
            

}

public void Deserialize(IDataReader reader)
{

nuggetsForPrism = reader.ReadVarUhInt();
            if (nuggetsForPrism < 0)
                throw new System.Exception("Forbidden value on nuggetsForPrism = " + nuggetsForPrism + ", it doesn't respect the following condition : nuggetsForPrism < 0");
            nuggetsForPlayer = reader.ReadVarUhInt();
            if (nuggetsForPlayer < 0)
                throw new System.Exception("Forbidden value on nuggetsForPlayer = " + nuggetsForPlayer + ", it doesn't respect the following condition : nuggetsForPlayer < 0");
            

}


}


}