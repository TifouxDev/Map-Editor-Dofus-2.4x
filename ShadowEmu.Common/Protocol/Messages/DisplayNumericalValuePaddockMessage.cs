


















// Generated on 01/12/2017 03:52:55
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class DisplayNumericalValuePaddockMessage : NetworkMessage
{

public const uint Id = 6563;
public uint MessageId
{
    get { return Id; }
}

public int rideId;
        public int value;
        public sbyte type;
        

public DisplayNumericalValuePaddockMessage()
{
}

public DisplayNumericalValuePaddockMessage(int rideId, int value, sbyte type)
        {
            this.rideId = rideId;
            this.value = value;
            this.type = type;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteInt(rideId);
            writer.WriteInt(value);
            writer.WriteSByte(type);
            

}

public void Deserialize(IDataReader reader)
{

rideId = reader.ReadInt();
            value = reader.ReadInt();
            type = reader.ReadSByte();
            if (type < 0)
                throw new System.Exception("Forbidden value on type = " + type + ", it doesn't respect the following condition : type < 0");
            

}


}


}