using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using ShadowEmu.Common.Network;
using ShadowEmu.Common.Dispatcher.Enum;

namespace ShadowEmu.Common.Dispatcher
{
    public class MessageDispatcher
    {

        private SortedDictionary<PriorityPacket, Queue<Tuple<NetworkMessage, ClientHost>>> messagesToDispatch = new SortedDictionary<PriorityPacket, Queue<Tuple<NetworkMessage, ClientHost>>>();

        private int currentThreadId;
        private object currentProcessor;

        public object CurrentProcessor
        {
            get { return currentProcessor; }
        }

        public int CurrentThreadId
        {
            get { return currentThreadId; }
        }

        private ManualResetEventSlim resumeEvent = new ManualResetEventSlim(true);
        private ManualResetEventSlim messageEnqueuedEvent = new ManualResetEventSlim(false);

        private bool stopped;
        private bool dispatching;

        public event Action<MessageDispatcher, NetworkMessage> MessageDispatched;

        protected void OnMessageDispatched(NetworkMessage message)
        {
            var evnt = MessageDispatched;
            if (evnt != null)
                MessageDispatched(this, message);
        }

        public MessageDispatcher()
        {
            methods = new List<MethodHandler>();

            messagesToDispatch.Add(PriorityPacket.DEFAULT, new Queue<Tuple<NetworkMessage, ClientHost>>());
            messagesToDispatch.Add(PriorityPacket.HIGH, new Queue<Tuple<NetworkMessage, ClientHost>>());

            messagesToDispatch.Add(PriorityPacket.VERY_HIGH, new Queue<Tuple<NetworkMessage, ClientHost>>());
            this.AddFrame();
        }

        private void AddFrame()
        {
            IEnumerable<Type> types =
             (from a in AppDomain.CurrentDomain.GetAssemblies()
             from t in a.GetTypes()
             select t).ToArray();

            foreach (Type type in types)
            {
                if(type.GetInterfaces().Contains(typeof(IPacket)))
                {
                    var instance = Activator.CreateInstance(type);
      
                    Register(instance);
                }
            }
        }
        public bool Stopped
        {
            get { return stopped; }
        }

        public virtual void Enqueue(NetworkMessage message, ClientHost token = null, bool executeIfCan = false)
        {
            if (IsInDispatchingContext())
            {
                Dispatch(message, token);
            }
            else
            {
                lock (messageEnqueuedEvent)
                {
                    messagesToDispatch[PriorityPacket.DEFAULT].Enqueue(Tuple.Create(message, token));

                    if (!dispatching)
                        messageEnqueuedEvent.Set();
                }
            }
        }

        public bool IsInDispatchingContext()
        {
            return System.Threading.Thread.CurrentThread.ManagedThreadId == currentThreadId &&
                 currentProcessor != null;
        }

        public void ProcessDispatching(object processor)
        {
            if (stopped)
                return;

            if (Interlocked.CompareExchange(ref currentThreadId, System.Threading.Thread.CurrentThread.ManagedThreadId, 0) == 0)
            {
                currentProcessor = processor;
                dispatching = true;

                var copy = messagesToDispatch.ToArray();
                foreach (var keyPair in copy)
                {
                    if (stopped)
                        break;

                    while (keyPair.Value.Count != 0)
                    {
                        if (stopped)
                            break;

                        var message = keyPair.Value.Dequeue();

                        if (message != null)
                            Dispatch(message.Item1, message.Item2);
                    }
                }

                currentProcessor = null;
                dispatching = false;
                Interlocked.Exchange(ref currentThreadId, 0);
            }

            lock (messagesToDispatch)
            {
                if (messagesToDispatch.Sum(x => x.Value.Count) > 0)
                    messageEnqueuedEvent.Set();
                else
                    messageEnqueuedEvent.Reset();
            }
        }

        protected virtual void Dispatch(NetworkMessage message, ClientHost token)
        {
            try
            {
                var messageId = (uint)message.GetType().GetProperty("MessageId").GetValue(message);
                List<MethodHandler> functions = new List<MethodHandler>();
                foreach (var method in methods.ToArray())
                {
                    foreach (var attribute in method.Attributes)
                    {
                        if (attribute.MessageId == messageId && (attribute.Priority == Protocol.Enums.PacketActivityEnum.None || attribute.Priority.HasFlag(token.Activity)))
                        {
                            functions.Add(method);
                            break;
                        }
                    }
                }
                foreach (MethodHandler func in functions)
                {
                    func.Invoke(message, token);
                }
                OnMessageDispatched(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("Can't dispatch message '{0}' due to exception '{1}'. (Source={2};) (Inner={3})", message.ToString(), ex.Message, ex.Source, ex.InnerException));

                return;
            }
        }

        /// <summary>
        /// Block the current thread until a message is enqueued
        /// </summary>
        public void Wait()
        {
            if (stopped)
                resumeEvent.Wait();

            if (messagesToDispatch.Sum(x => x.Value.Count) > 0)
                return;

            messageEnqueuedEvent.Wait();
        }

        public void Resume()
        {
            if (!stopped)
                return;

            stopped = false;
            resumeEvent.Set();
        }

        public void Stop()
        {
            if (stopped)
                return;

            stopped = true;
            resumeEvent.Reset();
        }

        public void Dispose()
        {
            Stop();

            foreach (var messages in messagesToDispatch)
            {
                messages.Value.Clear();
            }
            methods.Clear();
        }


        private Stopwatch _spy;

        /// <summary>
        /// Says how many milliseconds elapsed since last message. 
        /// </summary>
        public long DelayFromLastMessage
        {
            get
            {
                if (_spy == null) _spy = Stopwatch.StartNew(); return _spy.ElapsedMilliseconds;
            }
        }

        /// <summary>
        /// Reset timer for last received message
        /// </summary>
        protected void ActivityUpdate()
        {
            if (_spy == null)
                _spy = Stopwatch.StartNew();
            else
                _spy.Restart();
        }


        public List<MethodHandler> methods;

        private List<string> m_loader = new List<string>();
        public void Register(object @object)
        {

            if (@object == null)
            {
                throw new ArgumentNullException("object");
            }

            Type type = @object.GetType();
            if (m_loader.Contains(type.Name.ToLower()))
            {
                Console.WriteLine("Error two frame " + type.Name);
                return;
            }
            else
            {
                m_loader.Add(type.Name.ToLower());
                foreach (var methodInfo in type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy))
                {
                    MessageHandlerAttribute[] attributes = methodInfo.GetCustomAttributes<MessageHandlerAttribute>().ToArray();
                    if (attributes.Length != 0)
                    {
                        Register(methodInfo, @object, attributes);
                    }
                }
            }


        }

        public void Register(MethodInfo method, object instance, MessageHandlerAttribute[] attributes)
        {
            if (method == null)
            {
                throw new ArgumentNullException("method");
            }
            if (instance == null)
            {
                throw new ArgumentNullException("instance");
            }
            if (attributes == null || attributes.Length == 0)
            {
                return;
            }

            ParameterInfo[] parameters = method.GetParameters();
            if (parameters.Length != 2)
            {
                throw new Exception(string.Format("Only one parameter is allowed to use the MessageHandler attribute. (method {0})", method.Name));
            }

            methods.Add(new MethodHandler(method, instance, attributes));
        }

        public void UnRegister(Type instance)
        {
            m_loader.Remove(instance.Name.ToLower());
            methods.RemoveAll(entry => entry.Instance.GetType() == instance);
        }

    }


}
