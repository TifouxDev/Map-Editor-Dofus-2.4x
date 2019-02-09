


















// Generated on 07/24/2016 18:36:05
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class KrosmasterTransferRequestMessage : NetworkMessage
{

public const uint Id = 6349;
public uint MessageId
{
    get { return Id; }
}

public string uid;
        

public KrosmasterTransferRequestMessage()
{
}

public KrosmasterTransferRequestMessage(string uid)
        {
            this.uid = uid;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteUTF(uid);
            

}

public void Deserialize(IDataReader reader)
{

uid = reader.ReadUTF();
            

}


}


}