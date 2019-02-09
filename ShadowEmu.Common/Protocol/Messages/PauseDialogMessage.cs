


















// Generated on 01/12/2017 03:53:00
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class PauseDialogMessage : NetworkMessage
{

public const uint Id = 6012;
public uint MessageId
{
    get { return Id; }
}

public sbyte dialogType;
        

public PauseDialogMessage()
{
}

public PauseDialogMessage(sbyte dialogType)
        {
            this.dialogType = dialogType;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteSByte(dialogType);
            

}

public void Deserialize(IDataReader reader)
{

dialogType = reader.ReadSByte();
            if (dialogType < 0)
                throw new System.Exception("Forbidden value on dialogType = " + dialogType + ", it doesn't respect the following condition : dialogType < 0");
            

}


}


}