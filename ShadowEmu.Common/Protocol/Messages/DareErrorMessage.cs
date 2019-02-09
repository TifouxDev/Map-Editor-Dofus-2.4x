


















// Generated on 01/12/2017 03:53:00
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class DareErrorMessage : NetworkMessage
{

public const uint Id = 6667;
public uint MessageId
{
    get { return Id; }
}

public sbyte error;
        

public DareErrorMessage()
{
}

public DareErrorMessage(sbyte error)
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