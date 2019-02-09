


















// Generated on 07/24/2016 18:35:52
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class LockableStateUpdateHouseDoorMessage : LockableStateUpdateAbstractMessage
{

public const uint Id = 5668;
public uint MessageId
{
    get { return Id; }
}

public uint houseId;
        

public LockableStateUpdateHouseDoorMessage()
{
}

public LockableStateUpdateHouseDoorMessage(bool locked, uint houseId)
         : base(locked)
        {
            this.houseId = houseId;
        }
        

public void Serialize(IDataWriter writer)
{

base.Serialize(writer);
            writer.WriteVarInt((int)houseId);
            

}

public void Deserialize(IDataReader reader)
{

base.Deserialize(reader);
            houseId = reader.ReadVarUhInt();
            if (houseId < 0)
                throw new System.Exception("Forbidden value on houseId = " + houseId + ", it doesn't respect the following condition : houseId < 0");
            

}


}


}