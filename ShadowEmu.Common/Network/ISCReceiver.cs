using ShadowEmu.Common.IO;
using ShadowEmu.Common.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using ShadowEmu.Common.Extensions;
using NLog;
namespace ShadowEmu.Common.Network
{
    public static class ISCReceiver
    {
        #region Variables

        private static readonly Dictionary<uint, Func<ISCMessage>> m_constructors = new Dictionary<uint, Func<ISCMessage>>(800);
        private static readonly Dictionary<uint, Type> m_messages = new Dictionary<uint, Type>(800);
        private static NLog.Logger m_logger = LogManager.GetCurrentClassLogger();
        #endregion

        #region Methods
        public static ISCMessage BuildMessage(uint id, IDataReader reader)
        {
            if (!m_messages.ContainsKey(id))
                throw new MessageNotFoundException(string.Format("NetworkMessage <id:{0}> doesn't exist", id));

            ISCMessage message = m_constructors[id]();

            if (message == null)
                throw new MessageNotFoundException(string.Format("Constructors[{0}] (delegate {1}) does not exist", id, m_messages[id]));

            message.Deserialize(reader);

            return message;
        }

        public static void Initialize()
        {
            Assembly asm = Assembly.GetAssembly(typeof(ISCMessage));

            foreach (Type type in asm.GetTypes())
            {
                if (type.Namespace == null || !type.Namespace.Contains("Protocol.ISC"))
                    continue;

                FieldInfo fieldId = type.GetField("Id");

                if (fieldId != null)
                {
                    var id = (uint)fieldId.GetValue(type);
                    if (m_messages.ContainsKey(id))
                        throw new AmbiguousMatchException(
                            string.Format(
                                "MessageReceiver() => {0} item is already in the dictionary, old type is : {1}, new type is  {2}",
                                id, m_messages[id], type));

                    m_messages.Add(id, type);

                    ConstructorInfo ctor = type.GetConstructor(Type.EmptyTypes);

                    if (ctor == null)
                        continue;

                    m_constructors.Add(id, ctor.CreateDelegate<Func<ShadowEmu.Common.Network.ISCMessage>>());
                }
            }

            m_logger.Debug(string.Format("<{0}> ISCmessage(s) loaded.", m_messages.Count));
        }

        public static Type GetMessageType(uint id)
        {
            if (!m_messages.ContainsKey(id))
                throw new MessageNotFoundException(string.Format("ISCMessage <id:{0}> doesn't exist", id));

            return m_messages[id];
        }



        #endregion

        #region Nested type: MessageNotFoundException

        [Serializable]
        public class MessageNotFoundException : System.Exception
        {
            public MessageNotFoundException()
            {
            }

            public MessageNotFoundException(string message)
                : base(message)
            {
            }

            public MessageNotFoundException(string message, System.Exception inner)
                : base(message, inner)
            {
            }

            protected MessageNotFoundException(
                SerializationInfo info,
                StreamingContext context)
                : base(info, context)
            {
            }
        }

        #endregion
    }
}
