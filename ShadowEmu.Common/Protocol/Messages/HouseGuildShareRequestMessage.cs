


















// Generated on 01/12/2017 03:52:57
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class HouseGuildShareRequestMessage : NetworkMessage
{

public const uint Id = 5704;
public uint MessageId
{
    get { return Id; }
}

public bool enable;
        public uint rights;
        

public HouseGuildShareRequestMessage()
{
}

public HouseGuildShareRequestMessage(bool enable, uint rights)
        {
            this.enable = enable;
            this.rights = rights;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteBoolean(enable);
            writer.WriteVarInt((int)rights);
            

}

public void Deserialize(IDataReader reader)
{

enable = reader.ReadBoolean();
            rights = reader.ReadVarUhInt();
            if (rights < 0)
                throw new System.Exception("Forbidden value on rights = " + rights + ", it doesn't respect the following condition : rights < 0");
            

}


}


}