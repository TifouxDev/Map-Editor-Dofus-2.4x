


















// Generated on 01/12/2017 03:53:02
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class ExchangeBidHouseBuyResultMessage : NetworkMessage
{

public const uint Id = 6272;
public uint MessageId
{
    get { return Id; }
}

public uint uid;
        public bool bought;
        

public ExchangeBidHouseBuyResultMessage()
{
}

public ExchangeBidHouseBuyResultMessage(uint uid, bool bought)
        {
            this.uid = uid;
            this.bought = bought;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteVarInt((int)uid);
            writer.WriteBoolean(bought);
            

}

public void Deserialize(IDataReader reader)
{

uid = reader.ReadVarUhInt();
            if (uid < 0)
                throw new System.Exception("Forbidden value on uid = " + uid + ", it doesn't respect the following condition : uid < 0");
            bought = reader.ReadBoolean();
            

}


}


}