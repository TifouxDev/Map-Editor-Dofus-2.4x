


















// Generated on 07/24/2016 18:35:55
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class PartyCompanionUpdateLightMessage : PartyUpdateLightMessage
{

public const uint Id = 6472;
public uint MessageId
{
    get { return Id; }
}

public sbyte indexId;
        

public PartyCompanionUpdateLightMessage()
{
}

public PartyCompanionUpdateLightMessage(uint partyId, double id, uint lifePoints, uint maxLifePoints, uint prospecting, byte regenRate, sbyte indexId)
         : base(partyId, id, lifePoints, maxLifePoints, prospecting, regenRate)
        {
            this.indexId = indexId;
        }
        

public void Serialize(IDataWriter writer)
{

base.Serialize(writer);
            writer.WriteSByte(indexId);
            

}

public void Deserialize(IDataReader reader)
{

base.Deserialize(reader);
            indexId = reader.ReadSByte();
            if (indexId < 0)
                throw new System.Exception("Forbidden value on indexId = " + indexId + ", it doesn't respect the following condition : indexId < 0");
            

}


}


}