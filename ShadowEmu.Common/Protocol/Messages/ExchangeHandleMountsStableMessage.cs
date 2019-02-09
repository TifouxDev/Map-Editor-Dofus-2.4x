


















// Generated on 01/12/2017 03:53:02
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class ExchangeHandleMountsStableMessage : NetworkMessage
{

public const uint Id = 6562;
public uint MessageId
{
    get { return Id; }
}

public sbyte actionType;
        public uint[] ridesId;
        

public ExchangeHandleMountsStableMessage()
{
}

public ExchangeHandleMountsStableMessage(sbyte actionType, uint[] ridesId)
        {
            this.actionType = actionType;
            this.ridesId = ridesId;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteSByte(actionType);
            writer.WriteUShort((ushort)ridesId.Length);
            foreach (var entry in ridesId)
            {
                 writer.WriteVarInt((int)entry);
            }
            

}

public void Deserialize(IDataReader reader)
{

actionType = reader.ReadSByte();
            var limit = reader.ReadUShort();
            ridesId = new uint[limit];
            for (int i = 0; i < limit; i++)
            {
                 ridesId[i] = reader.ReadVarUhInt();
            }
            

}


}


}