


















// Generated on 01/12/2017 03:53:05
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class OrnamentSelectRequestMessage : NetworkMessage
{

public const uint Id = 6374;
public uint MessageId
{
    get { return Id; }
}

public uint ornamentId;
        

public OrnamentSelectRequestMessage()
{
}

public OrnamentSelectRequestMessage(uint ornamentId)
        {
            this.ornamentId = ornamentId;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteVarShort((int)ornamentId);
            

}

public void Deserialize(IDataReader reader)
{

ornamentId = reader.ReadVarUhShort();
            if (ornamentId < 0)
                throw new System.Exception("Forbidden value on ornamentId = " + ornamentId + ", it doesn't respect the following condition : ornamentId < 0");
            

}


}


}