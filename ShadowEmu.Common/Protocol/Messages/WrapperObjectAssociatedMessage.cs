


















// Generated on 01/12/2017 03:53:04
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class WrapperObjectAssociatedMessage : SymbioticObjectAssociatedMessage
{

public const uint Id = 6523;
public uint MessageId
{
    get { return Id; }
}



public WrapperObjectAssociatedMessage()
{
}

public WrapperObjectAssociatedMessage(uint hostUID)
         : base(hostUID)
        {
        }
        

public void Serialize(IDataWriter writer)
{

base.Serialize(writer);
            

}

public void Deserialize(IDataReader reader)
{

base.Deserialize(reader);
            

}


}


}