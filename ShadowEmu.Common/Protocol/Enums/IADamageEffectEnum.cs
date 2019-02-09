using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadowEmu.Common.Protocol.Enums
{
    public enum IADamageEffectEnum
    {
        Effect_StealHPFix = 82,
        Effect_StealAP_84 = 84,
        Effect_DamagePercentWater,
        Effect_DamagePercentEarth,
        Effect_DamagePercentAir,
        Effect_DamagePercentFire,
        Effect_DamagePercentNeutral,
        Effect_StealHPWater = 91,
        Effect_StealHPEarth,
        Effect_StealHPAir,
        Effect_StealHPFire,
        Effect_StealHPNeutral,
        Effect_DamageWater,
        Effect_DamageEarth,
        Effect_DamageAir,
        Effect_DamageFire,
        Effect_DamageNeutral,
        Effect_RemoveAP,
        Effect_SubRange = 116,
        Effect_LostMP = 127,
        Effect_LoseHPByUsingAP = 131,
        Effect_SkipTurn = 140,
        Effect_SubDamageBonus = 145,
        Effect_SubChance = 152,
        Effect_SubVitality,
        Effect_SubAgility,
        Effect_SubIntelligence,
        Effect_SubWisdom,
        Effect_SubStrength,
        Effect_SubAP = 168,
        Effect_SubMP,
        Effect_SubCriticalHit = 171,
        Effect_SubMagicDamageReduction,
        Effect_SubPhysicalDamageReduction,
    }
}
