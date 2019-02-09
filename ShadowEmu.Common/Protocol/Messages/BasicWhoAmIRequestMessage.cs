


















// Generated on 01/12/2017 03:52:54
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class BasicWhoAmIRequestMessage : NetworkMessage
{

public const uint Id = 5664;
public uint MessageId
{
    get { return Id; }
}

public bool verbose;
        

public BasicWhoAmIRequestMessage()
{
}

public BasicWhoAmIRequestMessage(bool verbose)
        {
            this.verbose = verbose;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteBoolean(verbose);
            

}

public void Deserialize(IDataReader reader)
{

verbose = reader.ReadBoolean();
            

}


}


}