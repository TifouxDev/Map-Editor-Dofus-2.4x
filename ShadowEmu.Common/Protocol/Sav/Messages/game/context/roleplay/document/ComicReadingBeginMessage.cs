


















// Generated on 07/24/2016 18:35:51
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class ComicReadingBeginMessage : NetworkMessage
{

public const uint Id = 6536;
public uint MessageId
{
    get { return Id; }
}

public uint comicId;
        

public ComicReadingBeginMessage()
{
}

public ComicReadingBeginMessage(uint comicId)
        {
            this.comicId = comicId;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteVarShort((int)comicId);
            

}

public void Deserialize(IDataReader reader)
{

comicId = reader.ReadVarUhShort();
            if (comicId < 0)
                throw new System.Exception("Forbidden value on comicId = " + comicId + ", it doesn't respect the following condition : comicId < 0");
            

}


}


}