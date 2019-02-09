


















// Generated on 01/12/2017 03:53:07
using System;
using System.Collections.Generic;
using System.Linq;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.IO;

namespace ShadowEmu.Common.Protocol.Types
{

public class GameRolePlayGroupMonsterInformations : GameRolePlayActorInformations
{

public const short Id = 160;
public override short TypeId
{
    get { return Id; }
}

public bool keyRingBonus;
        public bool hasHardcoreDrop;
        public bool hasAVARewardToken;
        public Types.GroupMonsterStaticInformations staticInfos;
        public double creationTime;
        public int ageBonusRate;
        public sbyte lootShare;
        public sbyte alignmentSide;
        

public GameRolePlayGroupMonsterInformations()
{
}

public GameRolePlayGroupMonsterInformations(double contextualId, Types.EntityLook look, Types.EntityDispositionInformations disposition, bool keyRingBonus, bool hasHardcoreDrop, bool hasAVARewardToken, Types.GroupMonsterStaticInformations staticInfos, double creationTime, int ageBonusRate, sbyte lootShare, sbyte alignmentSide)
         : base(contextualId, look, disposition)
        {
            this.keyRingBonus = keyRingBonus;
            this.hasHardcoreDrop = hasHardcoreDrop;
            this.hasAVARewardToken = hasAVARewardToken;
            this.staticInfos = staticInfos;
            this.creationTime = creationTime;
            this.ageBonusRate = ageBonusRate;
            this.lootShare = lootShare;
            this.alignmentSide = alignmentSide;
        }
        

public override void Serialize(IDataWriter writer)
{

base.Serialize(writer);
            byte flag1 = 0;
            flag1 = BooleanByteWrapper.SetFlag(flag1, 0, keyRingBonus);
            flag1 = BooleanByteWrapper.SetFlag(flag1, 1, hasHardcoreDrop);
            flag1 = BooleanByteWrapper.SetFlag(flag1, 2, hasAVARewardToken);
            writer.WriteByte(flag1);
            writer.WriteShort(staticInfos.TypeId);
            staticInfos.Serialize(writer);
            writer.WriteDouble(creationTime);
            writer.WriteInt(ageBonusRate);
            writer.WriteSByte(lootShare);
            writer.WriteSByte(alignmentSide);
            

}

public override void Deserialize(IDataReader reader)
{

base.Deserialize(reader);
            byte flag1 = reader.ReadByte();
            keyRingBonus = BooleanByteWrapper.GetFlag(flag1, 0);
            hasHardcoreDrop = BooleanByteWrapper.GetFlag(flag1, 1);
            hasAVARewardToken = BooleanByteWrapper.GetFlag(flag1, 2);
            staticInfos = ProtocolTypeManager.GetInstance<Types.GroupMonsterStaticInformations>(reader.ReadShort());
            staticInfos.Deserialize(reader);
            creationTime = reader.ReadDouble();
            if (creationTime < 0 || creationTime > 9.007199254740992E15)
                throw new System.Exception("Forbidden value on creationTime = " + creationTime + ", it doesn't respect the following condition : creationTime < 0 || creationTime > 9.007199254740992E15");
            ageBonusRate = reader.ReadInt();
            if (ageBonusRate < 0)
                throw new System.Exception("Forbidden value on ageBonusRate = " + ageBonusRate + ", it doesn't respect the following condition : ageBonusRate < 0");
            lootShare = reader.ReadSByte();
            if (lootShare < -1 || lootShare > 8)
                throw new System.Exception("Forbidden value on lootShare = " + lootShare + ", it doesn't respect the following condition : lootShare < -1 || lootShare > 8");
            alignmentSide = reader.ReadSByte();
            

}


}


}