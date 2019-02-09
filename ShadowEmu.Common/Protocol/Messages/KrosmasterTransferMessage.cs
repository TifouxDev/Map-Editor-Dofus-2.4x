


















// Generated on 01/12/2017 03:53:06
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class KrosmasterTransferMessage : NetworkMessage
{

public const uint Id = 6348;
public uint MessageId
{
    get { return Id; }
}

public string uid;
        public sbyte failure;
        

public KrosmasterTransferMessage()
{
}

public KrosmasterTransferMessage(string uid, sbyte failure)
        {
            this.uid = uid;
            this.failure = failure;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteUTF(uid);
            writer.WriteSByte(failure);
            

}

public void Deserialize(IDataReader reader)
{

uid = reader.ReadUTF();
            failure = reader.ReadSByte();
            if (failure < 0)
                throw new System.Exception("Forbidden value on failure = " + failure + ", it doesn't respect the following condition : failure < 0");
            

}


}


}