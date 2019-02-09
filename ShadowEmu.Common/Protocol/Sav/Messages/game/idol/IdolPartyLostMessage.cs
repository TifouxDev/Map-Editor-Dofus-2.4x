


















// Generated on 07/24/2016 18:35:58
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class IdolPartyLostMessage : NetworkMessage
{

public const uint Id = 6580;
public uint MessageId
{
    get { return Id; }
}

public uint idolId;
        

public IdolPartyLostMessage()
{
}

public IdolPartyLostMessage(uint idolId)
        {
            this.idolId = idolId;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteVarShort((int)idolId);
            

}

public void Deserialize(IDataReader reader)
{

idolId = reader.ReadVarUhShort();
            if (idolId < 0)
                throw new System.Exception("Forbidden value on idolId = " + idolId + ", it doesn't respect the following condition : idolId < 0");
            

}


}


}