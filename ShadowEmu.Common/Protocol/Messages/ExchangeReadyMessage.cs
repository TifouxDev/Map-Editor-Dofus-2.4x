


















// Generated on 01/12/2017 03:53:02
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class ExchangeReadyMessage : NetworkMessage
{

public const uint Id = 5511;
public uint MessageId
{
    get { return Id; }
}

public bool ready;
        public uint step;
        

public ExchangeReadyMessage()
{
}

public ExchangeReadyMessage(bool ready, uint step)
        {
            this.ready = ready;
            this.step = step;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteBoolean(ready);
            writer.WriteVarShort((int)step);
            

}

public void Deserialize(IDataReader reader)
{

ready = reader.ReadBoolean();
            step = reader.ReadVarUhShort();
            if (step < 0)
                throw new System.Exception("Forbidden value on step = " + step + ", it doesn't respect the following condition : step < 0");
            

}


}


}