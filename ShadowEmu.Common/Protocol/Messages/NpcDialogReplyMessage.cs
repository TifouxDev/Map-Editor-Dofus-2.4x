


















// Generated on 01/12/2017 03:52:58
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class NpcDialogReplyMessage : NetworkMessage
{

public const uint Id = 5616;
public uint MessageId
{
    get { return Id; }
}

public uint replyId;
        

public NpcDialogReplyMessage()
{
}

public NpcDialogReplyMessage(uint replyId)
        {
            this.replyId = replyId;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteVarShort((int)replyId);
            

}

public void Deserialize(IDataReader reader)
{

replyId = reader.ReadVarUhShort();
            if (replyId < 0)
                throw new System.Exception("Forbidden value on replyId = " + replyId + ", it doesn't respect the following condition : replyId < 0");
            

}


}


}