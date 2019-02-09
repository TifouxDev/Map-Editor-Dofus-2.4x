


















// Generated on 01/12/2017 03:52:52
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class BasicPongMessage : NetworkMessage
{

public const uint Id = 183;
public uint MessageId
{
    get { return Id; }
}

public bool quiet;
        

public BasicPongMessage()
{
}

public BasicPongMessage(bool quiet)
        {
            this.quiet = quiet;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteBoolean(quiet);
            

}

public void Deserialize(IDataReader reader)
{

quiet = reader.ReadBoolean();
            

}


}


}