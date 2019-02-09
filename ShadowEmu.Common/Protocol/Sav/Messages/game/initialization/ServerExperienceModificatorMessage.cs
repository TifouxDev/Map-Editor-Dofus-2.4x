


















// Generated on 07/24/2016 18:35:58
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class ServerExperienceModificatorMessage : NetworkMessage
{

public const uint Id = 6237;
public uint MessageId
{
    get { return Id; }
}

public uint experiencePercent;
        

public ServerExperienceModificatorMessage()
{
}

public ServerExperienceModificatorMessage(uint experiencePercent)
        {
            this.experiencePercent = experiencePercent;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteVarShort((int)experiencePercent);
            

}

public void Deserialize(IDataReader reader)
{

experiencePercent = reader.ReadVarUhShort();
            if (experiencePercent < 0)
                throw new System.Exception("Forbidden value on experiencePercent = " + experiencePercent + ", it doesn't respect the following condition : experiencePercent < 0");
            

}


}


}