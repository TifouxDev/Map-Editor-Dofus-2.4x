


















// Generated on 07/24/2016 18:35:48
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class GameContextCreateMessage : NetworkMessage
{

public const uint Id = 200;
public uint MessageId
{
    get { return Id; }
}

public sbyte context;
        

public GameContextCreateMessage()
{
}

public GameContextCreateMessage(sbyte context)
        {
            this.context = context;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteSByte(context);
            

}

public void Deserialize(IDataReader reader)
{

context = reader.ReadSByte();
            if (context < 0)
                throw new System.Exception("Forbidden value on context = " + context + ", it doesn't respect the following condition : context < 0");
            

}


}


}