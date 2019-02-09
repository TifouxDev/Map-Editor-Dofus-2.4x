


















// Generated on 01/12/2017 03:52:54
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class CharacterSelectedSuccessMessage : NetworkMessage
{

public const uint Id = 153;
public uint MessageId
{
    get { return Id; }
}

public Types.CharacterBaseInformations infos;
        public bool isCollectingStats;
        

public CharacterSelectedSuccessMessage()
{
}

public CharacterSelectedSuccessMessage(Types.CharacterBaseInformations infos, bool isCollectingStats)
        {
            this.infos = infos;
            this.isCollectingStats = isCollectingStats;
        }
        

public void Serialize(IDataWriter writer)
{

infos.Serialize(writer);
            writer.WriteBoolean(isCollectingStats);
            

}

public void Deserialize(IDataReader reader)
{

infos = new Types.CharacterBaseInformations();
            infos.Deserialize(reader);
            isCollectingStats = reader.ReadBoolean();
            

}


}


}