


















// Generated on 01/12/2017 03:52:59
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class StatsUpgradeResultMessage : NetworkMessage
{

public const uint Id = 5609;
public uint MessageId
{
    get { return Id; }
}

public sbyte result;
        public uint nbCharacBoost;
        

public StatsUpgradeResultMessage()
{
}

public StatsUpgradeResultMessage(sbyte result, uint nbCharacBoost)
        {
            this.result = result;
            this.nbCharacBoost = nbCharacBoost;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteSByte(result);
            writer.WriteVarShort((int)nbCharacBoost);
            

}

public void Deserialize(IDataReader reader)
{

result = reader.ReadSByte();
            nbCharacBoost = reader.ReadVarUhShort();
            if (nbCharacBoost < 0)
                throw new System.Exception("Forbidden value on nbCharacBoost = " + nbCharacBoost + ", it doesn't respect the following condition : nbCharacBoost < 0");
            

}


}


}