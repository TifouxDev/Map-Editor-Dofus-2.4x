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
        SELF = 1,
        ALLY_ALL = 2,
        ALLY_SUMMONS = 4,
        ALLY_NoSELF = 8,
        ALLY_STATIC_SUMMONS = 16,
        ENEMY_ALL = 32,
        ENNEMY_SUMMONS = 64,
        ENNEMY_SELF = 128,
        ALL = 256,
        ONLY_SELF = 512,
        ALL_HUMAN = 1024,
        ALL_SUMMONS = 2048,
        TELEPORT_FIGHTER = 4096,
    }
}
