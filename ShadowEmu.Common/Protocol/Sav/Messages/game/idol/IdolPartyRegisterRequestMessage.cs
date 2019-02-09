


















// Generated on 07/24/2016 18:35:58
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class IdolPartyRegisterRequestMessage : NetworkMessage
{

public const uint Id = 6582;
public uint MessageId
{
    get { return Id; }
}

public bool register;
        

public IdolPartyRegisterRequestMessage()
{
}

public IdolPartyRegisterRequestMessage(bool register)
        {
            this.register = register;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteBoolean(register);
            

}

public void Deserialize(IDataReader reader)
{

register = reader.ReadBoolean();
            

}


}


}