


















// Generated on 07/24/2016 18:36:03
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class URLOpenMessage : NetworkMessage
{

public const uint Id = 6266;
public uint MessageId
{
    get { return Id; }
}

public sbyte urlId;
        

public URLOpenMessage()
{
}

public URLOpenMessage(sbyte urlId)
        {
            this.urlId = urlId;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteSByte(urlId);
            

}

public void Deserialize(IDataReader reader)
{

urlId = reader.ReadSByte();
            if (urlId < 0)
                throw new System.Exception("Forbidden value on urlId = " + urlId + ", it doesn't respect the following condition : urlId < 0");
            

}


}


}