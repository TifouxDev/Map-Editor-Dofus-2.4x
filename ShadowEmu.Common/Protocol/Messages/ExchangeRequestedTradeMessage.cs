


















// Generated on 01/12/2017 03:53:03
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class ExchangeRequestedTradeMessage : ExchangeRequestedMessage
{

public const uint Id = 5523;
public uint MessageId
{
    get { return Id; }
}

public double source;
        public double target;
        

public ExchangeRequestedTradeMessage()
{
}

public ExchangeRequestedTradeMessage(sbyte exchangeType, double source, double target)
         : base(exchangeType)
        {
            this.source = source;
            this.target = target;
        }
        

public void Serialize(IDataWriter writer)
{

base.Serialize(writer);
            writer.WriteVarLong(source);
            writer.WriteVarLong(target);
            

}

public void Deserialize(IDataReader reader)
{

base.Deserialize(reader);
            source = reader.ReadVarUhLong();
            if (source < 0 || source > 9.007199254740992E15)
                throw new System.Exception("Forbidden value on source = " + source + ", it doesn't respect the following condition : source < 0 || source > 9.007199254740992E15");
            target = reader.ReadVarUhLong();
            if (target < 0 || target > 9.007199254740992E15)
                throw new System.Exception("Forbidden value on target = " + target + ", it doesn't respect the following condition : target < 0 || target > 9.007199254740992E15");
            

}


}


}