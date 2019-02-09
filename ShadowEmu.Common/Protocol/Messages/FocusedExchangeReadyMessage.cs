


















// Generated on 01/12/2017 03:53:03
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class FocusedExchangeReadyMessage : ExchangeReadyMessage
{

public const uint Id = 6701;
public uint MessageId
{
    get { return Id; }
}

public uint focusActionId;
        

public FocusedExchangeReadyMessage()
{
}

public FocusedExchangeReadyMessage(bool ready, uint step, uint focusActionId)
         : base(ready, step)
        {
            this.focusActionId = focusActionId;
        }
        

public void Serialize(IDataWriter writer)
{

base.Serialize(writer);
            writer.WriteVarInt((int)focusActionId);
            

}

public void Deserialize(IDataReader reader)
{

base.Deserialize(reader);
            focusActionId = reader.ReadVarUhInt();
            if (focusActionId < 0)
                throw new System.Exception("Forbidden value on focusActionId = " + focusActionId + ", it doesn't respect the following condition : focusActionId < 0");
            

}


}


}