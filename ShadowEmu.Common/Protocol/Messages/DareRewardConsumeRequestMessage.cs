


















// Generated on 01/12/2017 03:53:00
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class DareRewardConsumeRequestMessage : NetworkMessage
{

public const uint Id = 6676;
public uint MessageId
{
    get { return Id; }
}

public double dareId;
        public sbyte type;
        

public DareRewardConsumeRequestMessage()
{
}

public DareRewardConsumeRequestMessage(double dareId, sbyte type)
        {
            this.dareId = dareId;
            this.type = type;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteDouble(dareId);
            writer.WriteSByte(type);
            

}

public void Deserialize(IDataReader reader)
{

dareId = reader.ReadDouble();
            if (dareId < -9.007199254740992E15 || dareId > 9.007199254740992E15)
                throw new System.Exception("Forbidden value on dareId = " + dareId + ", it doesn't respect the following condition : dareId < -9.007199254740992E15 || dareId > 9.007199254740992E15");
            type = reader.ReadSByte();
            if (type < 0)
                throw new System.Exception("Forbidden value on type = " + type + ", it doesn't respect the following condition : type < 0");
            

}


}


}