


















// Generated on 01/12/2017 03:52:59
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class TreasureHuntLegendaryRequestMessage : NetworkMessage
{

public const uint Id = 6499;
public uint MessageId
{
    get { return Id; }
}

public uint legendaryId;
        

public TreasureHuntLegendaryRequestMessage()
{
}

public TreasureHuntLegendaryRequestMessage(uint legendaryId)
        {
            this.legendaryId = legendaryId;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteVarShort((int)legendaryId);
            

}

public void Deserialize(IDataReader reader)
{

legendaryId = reader.ReadVarUhShort();
            if (legendaryId < 0)
                throw new System.Exception("Forbidden value on legendaryId = " + legendaryId + ", it doesn't respect the following condition : legendaryId < 0");
            

}


}


}