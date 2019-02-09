


















// Generated on 07/24/2016 18:35:59
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class ExchangeCraftCountModifiedMessage : NetworkMessage
{

public const uint Id = 6595;
public uint MessageId
{
    get { return Id; }
}

public int count;
        

public ExchangeCraftCountModifiedMessage()
{
}

public ExchangeCraftCountModifiedMessage(int count)
        {
            this.count = count;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteVarInt((int)count);
            

}

public void Deserialize(IDataReader reader)
{

count = reader.ReadVarInt();
            

}


}


}