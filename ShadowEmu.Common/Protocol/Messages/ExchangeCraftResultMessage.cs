


















// Generated on 01/12/2017 03:53:02
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class ExchangeCraftResultMessage : NetworkMessage
{

public const uint Id = 5790;
public uint MessageId
{
    get { return Id; }
}

public sbyte craftResult;
        

public ExchangeCraftResultMessage()
{
}

public ExchangeCraftResultMessage(sbyte craftResult)
        {
            this.craftResult = craftResult;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteSByte(craftResult);
            

}

public void Deserialize(IDataReader reader)
{

craftResult = reader.ReadSByte();
            if (craftResult < 0)
                throw new System.Exception("Forbidden value on craftResult = " + craftResult + ", it doesn't respect the following condition : craftResult < 0");
            

}


}


}