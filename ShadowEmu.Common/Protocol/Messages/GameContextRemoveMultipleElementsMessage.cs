


















// Generated on 01/12/2017 03:52:55
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class GameContextRemoveMultipleElementsMessage : NetworkMessage
{

public const uint Id = 252;
public uint MessageId
{
    get { return Id; }
}

public double[] id;
        

public GameContextRemoveMultipleElementsMessage()
{
}

public GameContextRemoveMultipleElementsMessage(double[] id)
        {
            this.id = id;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteUShort((ushort)id.Length);
            foreach (var entry in id)
            {
                 writer.WriteDouble(entry);
            }
            

}

public void Deserialize(IDataReader reader)
{

var limit = reader.ReadUShort();
            id = new double[limit];
            for (int i = 0; i < limit; i++)
            {
                 id[i] = reader.ReadDouble();
            }
            

}


}


}