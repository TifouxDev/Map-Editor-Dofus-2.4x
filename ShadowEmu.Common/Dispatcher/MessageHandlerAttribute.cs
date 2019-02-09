using ShadowEmu.Common.Dispatcher.Enum;
using ShadowEmu.Common.Protocol.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadowEmu.Common.Dispatcher
{
    public class MessageHandlerAttribute : Attribute
    {
        public Type MessageType { get; private set; }
        public uint MessageId { get; private set; }
        public PacketActivityEnum Priority { get; private set; }
        public MessageHandlerAttribute(Type type)
        {
            MessageType = type;
        }

        public MessageHandlerAttribute(uint id, PacketActivityEnum priority = PacketActivityEnum.None)
        {
            MessageId = id;
            Priority = priority;
        }
    }
}
