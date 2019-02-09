


















// Generated on 01/12/2017 03:53:05
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class DownloadErrorMessage : NetworkMessage
{

public const uint Id = 1513;
public uint MessageId
{
    get { return Id; }
}

public sbyte errorId;
        public string message;
        public string helpUrl;
        

public DownloadErrorMessage()
{
}

public DownloadErrorMessage(sbyte errorId, string message, string helpUrl)
        {
            this.errorId = errorId;
            this.message = message;
            this.helpUrl = helpUrl;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteSByte(errorId);
            writer.WriteUTF(message);
            writer.WriteUTF(helpUrl);
            

}

public void Deserialize(IDataReader reader)
{

errorId = reader.ReadSByte();
            if (errorId < 0)
                throw new System.Exception("Forbidden value on errorId = " + errorId + ", it doesn't respect the following condition : errorId < 0");
            message = reader.ReadUTF();
            helpUrl = reader.ReadUTF();
            

}


}


}