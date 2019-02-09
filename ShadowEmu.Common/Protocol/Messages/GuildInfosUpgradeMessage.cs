


















// Generated on 01/12/2017 03:53:00
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Protocol.Types;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Messages
{

public class GuildInfosUpgradeMessage : NetworkMessage
{

public const uint Id = 5636;
public uint MessageId
{
    get { return Id; }
}

public sbyte maxTaxCollectorsCount;
        public sbyte taxCollectorsCount;
        public uint taxCollectorLifePoints;
        public uint taxCollectorDamagesBonuses;
        public uint taxCollectorPods;
        public uint taxCollectorProspecting;
        public uint taxCollectorWisdom;
        public uint boostPoints;
        public uint[] spellId;
        public short[] spellLevel;
        

public GuildInfosUpgradeMessage()
{
}

public GuildInfosUpgradeMessage(sbyte maxTaxCollectorsCount, sbyte taxCollectorsCount, uint taxCollectorLifePoints, uint taxCollectorDamagesBonuses, uint taxCollectorPods, uint taxCollectorProspecting, uint taxCollectorWisdom, uint boostPoints, uint[] spellId, short[] spellLevel)
        {
            this.maxTaxCollectorsCount = maxTaxCollectorsCount;
            this.taxCollectorsCount = taxCollectorsCount;
            this.taxCollectorLifePoints = taxCollectorLifePoints;
            this.taxCollectorDamagesBonuses = taxCollectorDamagesBonuses;
            this.taxCollectorPods = taxCollectorPods;
            this.taxCollectorProspecting = taxCollectorProspecting;
            this.taxCollectorWisdom = taxCollectorWisdom;
            this.boostPoints = boostPoints;
            this.spellId = spellId;
            this.spellLevel = spellLevel;
        }
        

public void Serialize(IDataWriter writer)
{

writer.WriteSByte(maxTaxCollectorsCount);
            writer.WriteSByte(taxCollectorsCount);
            writer.WriteVarShort((int)taxCollectorLifePoints);
            writer.WriteVarShort((int)taxCollectorDamagesBonuses);
            writer.WriteVarShort((int)taxCollectorPods);
            writer.WriteVarShort((int)taxCollectorProspecting);
            writer.WriteVarShort((int)taxCollectorWisdom);
            writer.WriteVarShort((int)boostPoints);
            writer.WriteUShort((ushort)spellId.Length);
            foreach (var entry in spellId)
            {
                 writer.WriteVarShort((int)entry);
            }
            writer.WriteUShort((ushort)spellLevel.Length);
            foreach (var entry in spellLevel)
            {
                 writer.WriteShort(entry);
            }
            

}

public void Deserialize(IDataReader reader)
{

maxTaxCollectorsCount = reader.ReadSByte();
            if (maxTaxCollectorsCount < 0)
                throw new System.Exception("Forbidden value on maxTaxCollectorsCount = " + maxTaxCollectorsCount + ", it doesn't respect the following condition : maxTaxCollectorsCount < 0");
            taxCollectorsCount = reader.ReadSByte();
            if (taxCollectorsCount < 0)
                throw new System.Exception("Forbidden value on taxCollectorsCount = " + taxCollectorsCount + ", it doesn't respect the following condition : taxCollectorsCount < 0");
            taxCollectorLifePoints = reader.ReadVarUhShort();
            if (taxCollectorLifePoints < 0)
                throw new System.Exception("Forbidden value on taxCollectorLifePoints = " + taxCollectorLifePoints + ", it doesn't respect the following condition : taxCollectorLifePoints < 0");
            taxCollectorDamagesBonuses = reader.ReadVarUhShort();
            if (taxCollectorDamagesBonuses < 0)
                throw new System.Exception("Forbidden value on taxCollectorDamagesBonuses = " + taxCollectorDamagesBonuses + ", it doesn't respect the following condition : taxCollectorDamagesBonuses < 0");
            taxCollectorPods = reader.ReadVarUhShort();
            if (taxCollectorPods < 0)
                throw new System.Exception("Forbidden value on taxCollectorPods = " + taxCollectorPods + ", it doesn't respect the following condition : taxCollectorPods < 0");
            taxCollectorProspecting = reader.ReadVarUhShort();
            if (taxCollectorProspecting < 0)
                throw new System.Exception("Forbidden value on taxCollectorProspecting = " + taxCollectorProspecting + ", it doesn't respect the following condition : taxCollectorProspecting < 0");
            taxCollectorWisdom = reader.ReadVarUhShort();
            if (taxCollectorWisdom < 0)
                throw new System.Exception("Forbidden value on taxCollectorWisdom = " + taxCollectorWisdom + ", it doesn't respect the following condition : taxCollectorWisdom < 0");
            boostPoints = reader.ReadVarUhShort();
            if (boostPoints < 0)
                throw new System.Exception("Forbidden value on boostPoints = " + boostPoints + ", it doesn't respect the following condition : boostPoints < 0");
            var limit = reader.ReadUShort();
            spellId = new uint[limit];
            for (int i = 0; i < limit; i++)
            {
                 spellId[i] = reader.ReadVarUhShort();
            }
            limit = reader.ReadUShort();
            spellLevel = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                 spellLevel[i] = reader.ReadShort();
            }
            

}


}


}