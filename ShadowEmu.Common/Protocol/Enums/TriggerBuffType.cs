using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadowEmu.Common.Protocol.Enums
{
    [System.Flags]
    public enum TriggerBuffType
    {
        BUFF_ADDED = 1,
        TURN_BEGIN = 2,
        TURN_END = 4,
        MOVE = 8,
        BEFORE_ATTACKED = 16,
        AFTER_ATTACKED = 32,
        BEFORE_ATTACK = 64,
        AFTER_ATTACK = 128,
        BUFF_ENDED = 256,
        BUFF_ENDED_TURNEND = 512,
        BEFORE_SPELLATTACK = 1024,
        BEFORE_REDUCTION = 2048,
        DELAYED = 4096,
        AURA = 8192,
        PORTAL = 16384,
        DIE = 32768,
        UNKNOWN = 2147483647
    }
}
