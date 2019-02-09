


















// Generated on 01/12/2017 03:53:05
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class DownloadPartMessage : NetworkMessage
{

public const uint Id = 1503;
public uint MessageId
{
    get { return Id; }
}

public string id;
        

public DownloadPartMessage()
{
}

public DownloadPartMessage(string id)
        {
            this.id = id;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteUTF(id);
            

}

public void Deserialize(IDataReader reader)
{

id = reader.ReadUTF();
            

}


}


}