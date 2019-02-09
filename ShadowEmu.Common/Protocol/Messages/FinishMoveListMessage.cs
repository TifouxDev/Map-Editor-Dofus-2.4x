


















// Generated on 01/12/2017 03:53:00
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class FinishMoveListMessage : NetworkMessage
{

public const uint Id = 6704;
public uint MessageId
{
    get { return Id; }
}

public Types.FinishMoveInformations[] finishMoves;
        

public FinishMoveListMessage()
{
}

public FinishMoveListMessage(Types.FinishMoveInformations[] finishMoves)
        {
            this.finishMoves = finishMoves;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteUShort((ushort)finishMoves.Length);
            foreach (var entry in finishMoves)
            {
                 entry.Serialize(writer);
            }
            

}

public void Deserialize(IDataReader reader)
{

var limit = reader.ReadUShort();
            finishMoves = new Types.FinishMoveInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                 finishMoves[i] = new Types.FinishMoveInformations();
                 finishMoves[i].Deserialize(reader);
            }
            

}


}


}