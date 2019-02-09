


















// Generated on 07/24/2016 18:35:56
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class GuildCharacsUpgradeRequestMessage : NetworkMessage
{

public const uint Id = 5706;
public uint MessageId
{
    get { return Id; }
}

public sbyte charaTypeTarget;
        

public GuildCharacsUpgradeRequestMessage()
{
}

public GuildCharacsUpgradeRequestMessage(sbyte charaTypeTarget)
        {
            this.charaTypeTarget = charaTypeTarget;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteSByte(charaTypeTarget);
            

}

public void Deserialize(IDataReader reader)
{

charaTypeTarget = reader.ReadSByte();
            if (charaTypeTarget < 0)
                throw new System.Exception("Forbidden value on charaTypeTarget = " + charaTypeTarget + ", it doesn't respect the following condition : charaTypeTarget < 0");
            

}


}


}