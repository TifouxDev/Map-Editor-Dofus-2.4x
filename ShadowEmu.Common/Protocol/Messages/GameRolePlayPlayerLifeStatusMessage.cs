


















// Generated on 01/12/2017 03:52:57
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class GameRolePlayPlayerLifeStatusMessage : NetworkMessage
{

public const uint Id = 5996;
public uint MessageId
{
    get { return Id; }
}

public sbyte state;
        public int phenixMapId;
        

public GameRolePlayPlayerLifeStatusMessage()
{
}

public GameRolePlayPlayerLifeStatusMessage(sbyte state, int phenixMapId)
        {
            this.state = state;
            this.phenixMapId = phenixMapId;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteSByte(state);
            writer.WriteInt(phenixMapId);
            

}

public void Deserialize(IDataReader reader)
{

state = reader.ReadSByte();
            if (state < 0)
                throw new System.Exception("Forbidden value on state = " + state + ", it doesn't respect the following condition : state < 0");
            phenixMapId = reader.ReadInt();
            if (phenixMapId < 0)
                throw new System.Exception("Forbidden value on phenixMapId = " + phenixMapId + ", it doesn't respect the following condition : phenixMapId < 0");
            

}


}


}