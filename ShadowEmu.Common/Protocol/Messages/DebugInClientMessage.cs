


















// Generated on 01/12/2017 03:52:52
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class DebugInClientMessage : NetworkMessage
{

public const uint Id = 6028;
public uint MessageId
{
    get { return Id; }
}

public sbyte level;
        public string message;
        

public DebugInClientMessage()
{
}

public DebugInClientMessage(sbyte level, string message)
        {
            this.level = level;
            this.message = message;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteSByte(level);
            writer.WriteUTF(message);
            

}

public void Deserialize(IDataReader reader)
{

level = reader.ReadSByte();
            if (level < 0)
                throw new System.Exception("Forbidden value on level = " + level + ", it doesn't respect the following condition : level < 0");
            message = reader.ReadUTF();
            

}


}


}