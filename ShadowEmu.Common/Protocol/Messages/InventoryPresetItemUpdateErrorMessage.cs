


















// Generated on 01/12/2017 03:53:04
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class InventoryPresetItemUpdateErrorMessage : NetworkMessage
{

public const uint Id = 6211;
public uint MessageId
{
    get { return Id; }
}

public sbyte code;
        

public InventoryPresetItemUpdateErrorMessage()
{
}

public InventoryPresetItemUpdateErrorMessage(sbyte code)
        {
            this.code = code;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteSByte(code);
            

}

public void Deserialize(IDataReader reader)
{

code = reader.ReadSByte();
            if (code < 0)
                throw new System.Exception("Forbidden value on code = " + code + ", it doesn't respect the following condition : code < 0");
            

}


}


}