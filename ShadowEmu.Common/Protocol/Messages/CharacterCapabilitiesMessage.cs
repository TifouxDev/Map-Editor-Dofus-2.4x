


















// Generated on 01/12/2017 03:53:01
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class CharacterCapabilitiesMessage : NetworkMessage
{

public const uint Id = 6339;
public uint MessageId
{
    get { return Id; }
}

public uint guildEmblemSymbolCategories;
        

public CharacterCapabilitiesMessage()
{
}

public CharacterCapabilitiesMessage(uint guildEmblemSymbolCategories)
        {
            this.guildEmblemSymbolCategories = guildEmblemSymbolCategories;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteVarInt((int)guildEmblemSymbolCategories);
            

}

public void Deserialize(IDataReader reader)
{

guildEmblemSymbolCategories = reader.ReadVarUhInt();
            if (guildEmblemSymbolCategories < 0)
                throw new System.Exception("Forbidden value on guildEmblemSymbolCategories = " + guildEmblemSymbolCategories + ", it doesn't respect the following condition : guildEmblemSymbolCategories < 0");
            

}


}


}