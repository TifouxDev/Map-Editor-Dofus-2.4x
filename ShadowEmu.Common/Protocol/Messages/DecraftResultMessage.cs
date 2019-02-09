


















// Generated on 01/12/2017 03:53:02
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class DecraftResultMessage : NetworkMessage
{

public const uint Id = 6569;
public uint MessageId
{
    get { return Id; }
}

public Types.DecraftedItemStackInfo[] results;
        

public DecraftResultMessage()
{
}

public DecraftResultMessage(Types.DecraftedItemStackInfo[] results)
        {
            this.results = results;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteUShort((ushort)results.Length);
            foreach (var entry in results)
            {
                 entry.Serialize(writer);
            }
            

}

public void Deserialize(IDataReader reader)
{

var limit = reader.ReadUShort();
            results = new Types.DecraftedItemStackInfo[limit];
            for (int i = 0; i < limit; i++)
            {
                 results[i] = new Types.DecraftedItemStackInfo();
                 results[i].Deserialize(reader);
            }
            

}


}


}