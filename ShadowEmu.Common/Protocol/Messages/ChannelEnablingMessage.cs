


















// Generated on 01/12/2017 03:52:55
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class ChannelEnablingMessage : NetworkMessage
{

public const uint Id = 890;
public uint MessageId
{
    get { return Id; }
}

public sbyte channel;
        public bool enable;
        

public ChannelEnablingMessage()
{
}

public ChannelEnablingMessage(sbyte channel, bool enable)
        {
            this.channel = channel;
            this.enable = enable;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteSByte(channel);
            writer.WriteBoolean(enable);
            

}

public void Deserialize(IDataReader reader)
{

channel = reader.ReadSByte();
            if (channel < 0)
                throw new System.Exception("Forbidden value on channel = " + channel + ", it doesn't respect the following condition : channel < 0");
            enable = reader.ReadBoolean();
            

}


}


}