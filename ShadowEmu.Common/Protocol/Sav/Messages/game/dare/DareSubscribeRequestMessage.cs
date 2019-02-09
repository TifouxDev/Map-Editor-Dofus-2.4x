


















// Generated on 07/24/2016 18:35:56
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class DareSubscribeRequestMessage : NetworkMessage
{

public const uint Id = 6666;
public uint MessageId
{
    get { return Id; }
}

public double dareId;
        public bool subscribe;
        

public DareSubscribeRequestMessage()
{
}

public DareSubscribeRequestMessage(double dareId, bool subscribe)
        {
            this.dareId = dareId;
            this.subscribe = subscribe;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteDouble(dareId);
            writer.WriteBoolean(subscribe);
            

}

public void Deserialize(IDataReader reader)
{

dareId = reader.ReadDouble();
            if (dareId < 0 || dareId > 9.007199254740992E15)
                throw new System.Exception("Forbidden value on dareId = " + dareId + ", it doesn't respect the following condition : dareId < 0 || dareId > 9.007199254740992E15");
            subscribe = reader.ReadBoolean();
            

}


}


}