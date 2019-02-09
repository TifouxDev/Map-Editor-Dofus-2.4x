


















// Generated on 01/12/2017 03:53:05
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class TitleLostMessage : NetworkMessage
{

public const uint Id = 6371;
public uint MessageId
{
    get { return Id; }
}

public uint titleId;
        

public TitleLostMessage()
{
}

public TitleLostMessage(uint titleId)
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