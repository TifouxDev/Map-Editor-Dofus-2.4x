


















// Generated on 07/24/2016 18:35:49
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class GameFightOptionToggleMessage : NetworkMessage
{

public const uint Id = 707;
public uint MessageId
{
    get { return Id; }
}

public sbyte option;
        

public GameFightOptionToggleMessage()
{
}

public GameFightOptionToggleMessage(sbyte option)
        {
            this.option = option;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteSByte(option);
            

}

public void Deserialize(IDataReader reader)
{

option = reader.ReadSByte();
            if (option < 0)
                throw new System.Exception("Forbidden value on option = " + option + ", it doesn't respect the following condition : option < 0");
            

}


}


}