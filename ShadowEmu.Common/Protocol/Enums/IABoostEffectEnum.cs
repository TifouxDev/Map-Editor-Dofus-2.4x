using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadowEmu.Common.Protocol.Enums
{
    public enum IABoostEffectEnum
    {
        Effect_AddMP = 78,
        Effect_AddGlobalDamageReduction_105 = 105,
        Effect_AddDamageReflection = 107,
        Effect_HealHP_108,
        Effect_AddHealth = 110,
        Effect_AddAP_111,
        Effect_AddDamageBonus,
        Effect_AddDamageMultiplicator = 114,
        Effect_AddCriticalHit,
        Effect_AddRange = 117,
        Effect_AddStrength,
        Effect_AddAgility,
        Effect_RegainAP,
        Effect_AddDamageBonus_121,
        Effect_AddCriticalMiss,
        Effect_AddChance,
        Effect_AddWisdom,
        Effect_AddVitality,
        Effect_AddIntelligence,
        Effect_AddMP_128 = 128,
        Effect_AddRange_136 = 136,
        Effect_AddPhysicalDamage_137 = 137,
        Effect_AddPhysicalDamage_142 = 142,
        Effect_AddGlobalDamageReduction = 164,
        Effect_AddDamageBonusPercent,
        Effect_AddSummonLimit = 182,
        Effect_AddMagicDamageReduction,
        Effect_AddPhysicalDamageReduction,
        Effect_AddEarthResistPercent = 210,
        Effect_AddWaterResistPercent,
        Effect_AddAirResistPercent,
        Effect_AddFireResistPercent,
        Effect_AddNeutralResistPercent,
        Effect_AddTrapBonus = 225,
        Effect_AddTrapBonusPercent,
        Effect_AddEarthElementReduction = 240,
        Effect_AddWaterElementReduction,
        Effect_AddAirElementReduction,
        Effect_AddFireElementReduction,
        Effect_AddNeutralElementReduction,

        Effect_AddPushDamageBonus = 414,
        Effect_AddPushDamageReduction = 416,
        Effect_AddCriticalDamageBonus = 418,
        Effect_AddCriticalDamageReduction = 420,
        Effect_AddEarthDamageBonus = 422,
        Effect_AddFireDamageBonus = 424,
        Effect_AddWaterDamageBonus = 426,
        Effect_AddAirDamageBonus = 428,
        Effect_AddNeutralDamageBonus = 430,

        Effect_AddShieldPercent = 1039,
        Effect_AddShield,

        Effect_AddFinalDommagePourcent = 1171,
    }
}
