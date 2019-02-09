


















// Generated on 01/12/2017 03:52:55
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class GameFightHumanReadyStateMessage : NetworkMessage
{

public const uint Id = 740;
public uint MessageId
{
    get { return Id; }
}

public double characterId;
        public bool isReady;
        

public GameFightHumanReadyStateMessage()
{
}

public GameFightHumanReadyStateMessage(double characterId, bool isReady)
        {
            this.characterId = characterId;
            this.isReady = isReady;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteVarLong(characterId);
            writer.WriteBoolean(isReady);
            

}

public void Deserialize(IDataReader reader)
{

characterId = reader.ReadVarUhLong();
            if (characterId < 0 || characterId > 9.007199254740992E15)
                throw new System.Exception("Forbidden value on characterId = " + characterId + ", it doesn't respect the following condition : characterId < 0 || characterId > 9.007199254740992E15");
            isReady = reader.ReadBoolean();
            

}


}


}