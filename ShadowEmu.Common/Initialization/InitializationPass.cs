using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadowEmu.Common.Initialization
{
    public enum InitializationPass : byte
    {
        Database,
        Any,
        CoreReserved,
        First,
        Second,
        Third,
        Fourth,
        Fifth,
        Sixth,
        Seventh,
        Eighth,
        Ninth,
        Tenth,
        Last
    }
}
