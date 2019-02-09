


















// Generated on 01/12/2017 03:52:55
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class GameContextRefreshEntityLookMessage : NetworkMessage
{

public const uint Id = 5637;
public uint MessageId
{
    get { return Id; }
}

public double id;
        public Types.EntityLook look;
        

public GameContextRefreshEntityLookMessage()
{
}

public GameContextRefreshEntityLookMessage(double id, Types.EntityLook look)
        {
            this.id = id;
            this.look = look;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteDouble(id);
            look.Serialize(writer);
            

}

public void Deserialize(IDataReader reader)
{

id = reader.ReadDouble();
            if (id < -9.007199254740992E15 || id > 9.007199254740992E15)
                throw new System.Exception("Forbidden value on id = " + id + ", it doesn't respect the following condition : id < -9.007199254740992E15 || id > 9.007199254740992E15");
            look = new Types.EntityLook();
            look.Deserialize(reader);
            

}


}


}