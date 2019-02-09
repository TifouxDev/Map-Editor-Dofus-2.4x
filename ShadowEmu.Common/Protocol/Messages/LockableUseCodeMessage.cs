


















// Generated on 01/12/2017 03:52:58
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class LockableUseCodeMessage : NetworkMessage
{

public const uint Id = 5667;
public uint MessageId
{
    get { return Id; }
}

public string code;
        

public LockableUseCodeMessage()
{
}

public LockableUseCodeMessage(string code)
        {
            this.code = code;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteUTF(code);
            

}

public void Deserialize(IDataReader reader)
{

code = reader.ReadUTF();
            

}


}


}