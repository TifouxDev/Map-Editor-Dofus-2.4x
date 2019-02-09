


















// Generated on 01/12/2017 03:53:00
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class GuildGetInformationsMessage : NetworkMessage
{

public const uint Id = 5550;
public uint MessageId
{
    get { return Id; }
}

public sbyte infoType;
        

public GuildGetInformationsMessage()
{
}

public GuildGetInformationsMessage(sbyte infoType)
        {
            this.infoType = infoType;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteSByte(infoType);
            

}

public void Deserialize(IDataReader reader)
{

infoType = reader.ReadSByte();
            if (infoType < 0)
                throw new System.Exception("Forbidden value on infoType = " + infoType + ", it doesn't respect the following condition : infoType < 0");
            

}


}


}