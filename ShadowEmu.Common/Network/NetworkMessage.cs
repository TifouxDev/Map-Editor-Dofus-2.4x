using ShadowEmu.Common.IO;
using System;

namespace ShadowEmu.Common.Network
{
    public interface NetworkMessage
    {
        uint MessageId { get; }
        void Serialize(IDataWriter writer);
        void Deserialize(IDataReader reader);
    }
}