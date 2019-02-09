


















// Generated on 01/12/2017 03:53:03
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class MimicryObjectAssociatedMessage : SymbioticObjectAssociatedMessage
{

public const uint Id = 6462;
public uint MessageId
{
    get { return Id; }
}



public MimicryObjectAssociatedMessage()
{
}

public MimicryObjectAssociatedMessage(uint hostUID)
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