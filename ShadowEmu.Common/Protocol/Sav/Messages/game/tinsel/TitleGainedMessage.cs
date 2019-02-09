


















// Generated on 07/24/2016 18:36:04
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class TitleGainedMessage : NetworkMessage
{

public const uint Id = 6364;
public uint MessageId
{
    get { return Id; }
}

public uint titleId;
        

public TitleGainedMessage()
{
}

public TitleGainedMessage(uint titleId)
        {
            this.titleId = titleId;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteVarShort((int)titleId);
            

}

public void Deserialize(IDataReader reader)
{

titleId = reader.ReadVarUhShort();
            if (titleId < 0)
                throw new System.Exception("Forbidden value on titleId = " + titleId + ", it doesn't respect the following condition : titleId < 0");
            

}


}


}