


















// Generated on 01/12/2017 03:52:54
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class BasicLatencyStatsMessage : NetworkMessage
{

public const uint Id = 5663;
public uint MessageId
{
    get { return Id; }
}

public ushort latency;
        public uint sampleCount;
        public uint max;
        

public BasicLatencyStatsMessage()
{
}

public BasicLatencyStatsMessage(ushort latency, uint sampleCount, uint max)
        {
            this.latency = latency;
            this.sampleCount = sampleCount;
            this.max = max;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteUShort(latency);
            writer.WriteVarShort((int)sampleCount);
            writer.WriteVarShort((int)max);
            

}

public void Deserialize(IDataReader reader)
{

latency = reader.ReadUShort();
            if (latency < 0 || latency > 65535)
                throw new System.Exception("Forbidden value on latency = " + latency + ", it doesn't respect the following condition : latency < 0 || latency > 65535");
            sampleCount = reader.ReadVarUhShort();
            if (sampleCount < 0)
                throw new System.Exception("Forbidden value on sampleCount = " + sampleCount + ", it doesn't respect the following condition : sampleCount < 0");
            max = reader.ReadVarUhShort();
            if (max < 0)
                throw new System.Exception("Forbidden value on max = " + max + ", it doesn't respect the following condition : max < 0");
            

}


}


}