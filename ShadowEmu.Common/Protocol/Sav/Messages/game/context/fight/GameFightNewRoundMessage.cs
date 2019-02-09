


















// Generated on 07/24/2016 18:35:49
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class GameFightNewRoundMessage : NetworkMessage
{

public const uint Id = 6239;
public uint MessageId
{
    get { return Id; }
}

public uint roundNumber;
        

public GameFightNewRoundMessage()
{
}

public GameFightNewRoundMessage(uint roundNumber)
        {
            this.roundNumber = roundNumber;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteVarInt((int)roundNumber);
            

}

public void Deserialize(IDataReader reader)
{

roundNumber = reader.ReadVarUhInt();
            if (roundNumber < 0)
                throw new System.Exception("Forbidden value on roundNumber = " + roundNumber + ", it doesn't respect the following condition : roundNumber < 0");
            

}


}


}