using ShadowEmu.Common.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadowEmu.Common.Network
{
    public interface ISCMessage
    {
        uint MessageId { get;  }
        uint RequestId { get; set; }
        void Serialize(IDataWriter writer);
        void Deserialize(IDataReader reader);
    }
}
