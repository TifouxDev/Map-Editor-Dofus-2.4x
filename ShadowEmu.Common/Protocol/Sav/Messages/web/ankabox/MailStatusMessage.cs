


















// Generated on 07/24/2016 18:36:05
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class MailStatusMessage : NetworkMessage
{

public const uint Id = 6275;
public uint MessageId
{
    get { return Id; }
}

public uint unread;
        public uint total;
        

public MailStatusMessage()
{
}

public MailStatusMessage(uint unread, uint total)
        {
            this.unread = unread;
            this.total = total;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteVarShort((int)unread);
            writer.WriteVarShort((int)total);
            

}

public void Deserialize(IDataReader reader)
{

unread = reader.ReadVarUhShort();
            if (unread < 0)
                throw new System.Exception("Forbidden value on unread = " + unread + ", it doesn't respect the following condition : unread < 0");
            total = reader.ReadVarUhShort();
            if (total < 0)
                throw new System.Exception("Forbidden value on total = " + total + ", it doesn't respect the following condition : total < 0");
            

}


}


}