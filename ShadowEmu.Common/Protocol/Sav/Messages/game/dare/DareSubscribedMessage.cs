


















// Generated on 07/24/2016 18:35:56
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class DareSubscribedMessage : NetworkMessage
{

public const uint Id = 6660;
public uint MessageId
{
    get { return Id; }
}

public bool success;
        public bool subscribe;
        public double dareId;
        public Types.DareVersatileInformations dareVersatilesInfos;
        

public DareSubscribedMessage()
{
}

public DareSubscribedMessage(bool success, bool subscribe, double dareId, Types.DareVersatileInformations dareVersatilesInfos)
        {
            this.success = success;
            this.subscribe = subscribe;
            this.dareId = dareId;
            this.dareVersatilesInfos = dareVersatilesInfos;
        }
        

public void Serialize(IDataWriter writer)
{

byte flag1 = 0;
            flag1 = BooleanByteWrapper.SetFlag(flag1, 0, success);
            flag1 = BooleanByteWrapper.SetFlag(flag1, 1, subscribe);
            writer.WriteByte(flag1);
            writer.WriteDouble(dareId);
            dareVersatilesInfos.Serialize(writer);
            

}

public void Deserialize(IDataReader reader)
{

byte flag1 = reader.ReadByte();
            success = BooleanByteWrapper.GetFlag(flag1, 0);
            subscribe = BooleanByteWrapper.GetFlag(flag1, 1);
            dareId = reader.ReadDouble();
            if (dareId < 0 || dareId > 9.007199254740992E15)
                throw new System.Exception("Forbidden value on dareId = " + dareId + ", it doesn't respect the following condition : dareId < 0 || dareId > 9.007199254740992E15");
            dareVersatilesInfos = new Types.DareVersatileInformations();
            dareVersatilesInfos.Deserialize(reader);
            

}


}


}