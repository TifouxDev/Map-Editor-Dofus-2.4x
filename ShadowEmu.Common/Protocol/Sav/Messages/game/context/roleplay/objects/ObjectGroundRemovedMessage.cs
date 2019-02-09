


















// Generated on 07/24/2016 18:35:53
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class ObjectGroundRemovedMessage : NetworkMessage
{

public const uint Id = 3014;
public uint MessageId
{
    get { return Id; }
}

public uint cell;
        

public ObjectGroundRemovedMessage()
{
}

public ObjectGroundRemovedMessage(uint cell)
        {
            this.cell = cell;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteVarShort((int)cell);
            

}

public void Deserialize(IDataReader reader)
{

cell = reader.ReadVarUhShort();
            if (cell < 0 || cell > 559)
                throw new System.Exception("Forbidden value on cell = " + cell + ", it doesn't respect the following condition : cell < 0 || cell > 559");
            

}


}


}