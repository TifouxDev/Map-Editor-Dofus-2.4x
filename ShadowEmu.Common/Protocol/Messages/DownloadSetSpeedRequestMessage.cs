


















// Generated on 01/12/2017 03:53:05
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class DownloadSetSpeedRequestMessage : NetworkMessage
{

public const uint Id = 1512;
public uint MessageId
{
    get { return Id; }
}

public sbyte downloadSpeed;
        

public DownloadSetSpeedRequestMessage()
{
}

public DownloadSetSpeedRequestMessage(sbyte downloadSpeed)
        {
            this.downloadSpeed = downloadSpeed;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteSByte(downloadSpeed);
            

}

public void Deserialize(IDataReader reader)
{

downloadSpeed = reader.ReadSByte();
            if (downloadSpeed < 1 || downloadSpeed > 10)
                throw new System.Exception("Forbidden value on downloadSpeed = " + downloadSpeed + ", it doesn't respect the following condition : downloadSpeed < 1 || downloadSpeed > 10");
            

}


}


}