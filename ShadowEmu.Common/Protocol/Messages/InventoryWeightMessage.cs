


















// Generated on 01/12/2017 03:53:03
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class InventoryWeightMessage : NetworkMessage
{

public const uint Id = 3009;
public uint MessageId
{
    get { return Id; }
}

public uint weight;
        public uint weightMax;
        

public InventoryWeightMessage()
{
}

public InventoryWeightMessage(uint weight, uint weightMax)
        {
            this.weight = weight;
            this.weightMax = weightMax;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteVarInt((int)weight);
            writer.WriteVarInt((int)weightMax);
            

}

public void Deserialize(IDataReader reader)
{

weight = reader.ReadVarUhInt();
            if (weight < 0)
                throw new System.Exception("Forbidden value on weight = " + weight + ", it doesn't respect the following condition : weight < 0");
            weightMax = reader.ReadVarUhInt();
            if (weightMax < 0)
                throw new System.Exception("Forbidden value on weightMax = " + weightMax + ", it doesn't respect the following condition : weightMax < 0");
            

}


}


}