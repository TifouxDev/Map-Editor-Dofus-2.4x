


















// Generated on 01/12/2017 03:52:59
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class StatsUpgradeRequestMessage : NetworkMessage
{

public const uint Id = 5610;
public uint MessageId
{
    get { return Id; }
}

public bool useAdditionnal;
        public sbyte statId;
        public uint boostPoint;
        

public StatsUpgradeRequestMessage()
{
}

public StatsUpgradeRequestMessage(bool useAdditionnal, sbyte statId, uint boostPoint)
        {
            this.useAdditionnal = useAdditionnal;
            this.statId = statId;
            this.boostPoint = boostPoint;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteBoolean(useAdditionnal);
            writer.WriteSByte(statId);
            writer.WriteVarShort((int)boostPoint);
            

}

public void Deserialize(IDataReader reader)
{

useAdditionnal = reader.ReadBoolean();
            statId = reader.ReadSByte();
            if (statId < 0)
                throw new System.Exception("Forbidden value on statId = " + statId + ", it doesn't respect the following condition : statId < 0");
            boostPoint = reader.ReadVarUhShort();
            if (boostPoint < 0)
                throw new System.Exception("Forbidden value on boostPoint = " + boostPoint + ", it doesn't respect the following condition : boostPoint < 0");
            

}


}


}