


















// Generated on 01/12/2017 03:53:05
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class CinematicMessage : NetworkMessage
{

public const uint Id = 6053;
public uint MessageId
{
    get { return Id; }
}

public uint cinematicId;
        

public CinematicMessage()
{
}

public CinematicMessage(uint cinematicId)
        {
            this.cinematicId = cinematicId;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteVarShort((int)cinematicId);
            

}

public void Deserialize(IDataReader reader)
{

cinematicId = reader.ReadVarUhShort();
            if (cinematicId < 0)
                throw new System.Exception("Forbidden value on cinematicId = " + cinematicId + ", it doesn't respect the following condition : cinematicId < 0");
            

}


}


}