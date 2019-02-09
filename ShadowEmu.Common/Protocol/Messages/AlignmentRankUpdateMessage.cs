


















// Generated on 01/12/2017 03:53:05
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class AlignmentRankUpdateMessage : NetworkMessage
{

public const uint Id = 6058;
public uint MessageId
{
    get { return Id; }
}

public sbyte alignmentRank;
        public bool verbose;
        

public AlignmentRankUpdateMessage()
{
}

public AlignmentRankUpdateMessage(sbyte alignmentRank, bool verbose)
        {
            this.alignmentRank = alignmentRank;
            this.verbose = verbose;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteSByte(alignmentRank);
            writer.WriteBoolean(verbose);
            

}

public void Deserialize(IDataReader reader)
{

alignmentRank = reader.ReadSByte();
            if (alignmentRank < 0)
                throw new System.Exception("Forbidden value on alignmentRank = " + alignmentRank + ", it doesn't respect the following condition : alignmentRank < 0");
            verbose = reader.ReadBoolean();
            

}


}


}