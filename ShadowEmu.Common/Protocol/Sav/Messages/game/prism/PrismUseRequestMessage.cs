


















// Generated on 07/24/2016 18:36:03
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class PrismUseRequestMessage : NetworkMessage
{

public const uint Id = 6041;
public uint MessageId
{
    get { return Id; }
}

public sbyte moduleToUse;
        

public PrismUseRequestMessage()
{
}

public PrismUseRequestMessage(sbyte moduleToUse)
        {
            this.moduleToUse = moduleToUse;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteSByte(moduleToUse);
            

}

public void Deserialize(IDataReader reader)
{

moduleToUse = reader.ReadSByte();
            if (moduleToUse < 0)
                throw new System.Exception("Forbidden value on moduleToUse = " + moduleToUse + ", it doesn't respect the following condition : moduleToUse < 0");
            

}


}


}