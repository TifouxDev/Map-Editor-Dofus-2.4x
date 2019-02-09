using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadowEmu.Common.Protocol.Enums
{
    public enum SpellTargetType
    {
        NONE = 0,
        SELF = 32769,
        ALLY_1 = 3,
        ALLY_2 = 4,
        ALLY_SUMMONS = 8,
        ALLY_STATIC_SUMMONS = 16,
        ALLY_3 = 32,
        ALLY_4 = 64,
        ALLY_5 = 128,
        ALLY_ALL = 254,

        ENNEMY_1 = 256,
        ENNEMY_2 = 512,
        ENNEMY_SUMMONS = 1024,
        ENNEMY_STATIC_SUMMONS = 2048,
        ENNEMY_3 = 4096,
        ENNEMY_4 = 8192,
        ENNEMY_5 = 16384,

        ALL_SUMMONS = 3096,
        ALL_HUMAN,
        ENEMY_ALL = 32512,
        ALL = 32767,
        ONLY_SELF = 32768
    }
}
