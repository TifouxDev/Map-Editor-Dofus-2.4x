


















// Generated on 01/12/2017 03:53:04
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class IdolsPresetUpdateMessage : NetworkMessage
{

public const uint Id = 6606;
public uint MessageId
{
    get { return Id; }
}

public Types.IdolsPreset idolsPreset;
        

public IdolsPresetUpdateMessage()
{
}

public IdolsPresetUpdateMessage(Types.IdolsPreset idolsPreset)
        {
            this.idolsPreset = idolsPreset;
        }
        

public void Serialize(IDataWriter writer)
{

idolsPreset.Serialize(writer);
            

}

public void Deserialize(IDataReader reader)
{

idolsPreset = new Types.IdolsPreset();
            idolsPreset.Deserialize(reader);
            

}


}


}