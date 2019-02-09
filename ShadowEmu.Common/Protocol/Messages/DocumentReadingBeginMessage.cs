


















// Generated on 01/12/2017 03:52:57
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class DocumentReadingBeginMessage : NetworkMessage
{

public const uint Id = 5675;
public uint MessageId
{
    get { return Id; }
}

public uint documentId;
        

public DocumentReadingBeginMessage()
{
}

public DocumentReadingBeginMessage(uint documentId)
        {
            this.documentId = documentId;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteVarShort((int)documentId);
            

}

public void Deserialize(IDataReader reader)
{

documentId = reader.ReadVarUhShort();
            if (documentId < 0)
                throw new System.Exception("Forbidden value on documentId = " + documentId + ", it doesn't respect the following condition : documentId < 0");
            

}


}


}