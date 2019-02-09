


















// Generated on 07/24/2016 18:36:03
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class CharacterReportMessage : NetworkMessage
{

public const uint Id = 6079;
public uint MessageId
{
    get { return Id; }
}

public double reportedId;
        public sbyte reason;
        

public CharacterReportMessage()
{
}

public CharacterReportMessage(double reportedId, sbyte reason)
        {
            this.reportedId = reportedId;
            this.reason = reason;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteVarLong(reportedId);
            writer.WriteSByte(reason);
            

}

public void Deserialize(IDataReader reader)
{

reportedId = reader.ReadVarUhLong();
            if (reportedId < 0 || reportedId > 9.007199254740992E15)
                throw new System.Exception("Forbidden value on reportedId = " + reportedId + ", it doesn't respect the following condition : reportedId < 0 || reportedId > 9.007199254740992E15");
            reason = reader.ReadSByte();
            if (reason < 0)
                throw new System.Exception("Forbidden value on reason = " + reason + ", it doesn't respect the following condition : reason < 0");
            

}


}


}