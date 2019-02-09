using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadowEmu.Common.Network
{
    public delegate void RequestCallbackDelegate<in T>(T callbackMessage) where T : ISCMessage;
}

