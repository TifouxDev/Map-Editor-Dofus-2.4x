


















// Generated on 01/12/2017 03:53:04
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class AccessoryPreviewErrorMessage : NetworkMessage
{

public const uint Id = 6521;
public uint MessageId
{
    get { return Id; }
}

public sbyte error;
        

public AccessoryPreviewErrorMessage()
{
}

public AccessoryPreviewErrorMessage(sbyte error)
        {
            this.error = error;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteSByte(error);
            

}

public void Deserialize(IDataReader reader)
{

error = reader.ReadSByte();
            if (error < 0)
                throw new System.Exception("Forbidden value on error = " + error + ", it doesn't respect the following condition : error < 0");
            

}


}


}