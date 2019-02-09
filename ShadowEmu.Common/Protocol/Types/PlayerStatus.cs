


















// Generated on 01/12/2017 03:53:07
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Types
{

public class PlayerStatus : NetworkType
{

public const short Id = 415;
public virtual short TypeId
{
    get { return Id; }
}

public sbyte statusId;
        

public PlayerStatus()
{
}

public PlayerStatus(sbyte statusId)
        {
            this.statusId = statusId;
        }
        

public virtual void Serialize(IDataWriter writer)
{

writer.WriteSByte(statusId);
            

}

public virtual void Deserialize(IDataReader reader)
{

statusId = reader.ReadSByte();
            if (statusId < 0)
                throw new System.Exception("Forbidden value on statusId = " + statusId + ", it doesn't respect the following condition : statusId < 0");
            

}


}


}