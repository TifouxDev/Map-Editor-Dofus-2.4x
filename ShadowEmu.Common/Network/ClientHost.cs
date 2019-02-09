using ShadowEmu.Common.Dispatcher;
using ShadowEmu.Common.IO;
using ShadowEmu.Common.Logger;
using ShadowEmu.Common.Protocol.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace ShadowEmu.Common.Network
{
    public class ClientHost
    {
        #region Déclaration
        public SimpleClient Client;

        public event EventHandler<DisconnectedArgs> Disconnected;
        public bool logger = false;
        public bool FloodQuit = true;
        public event EventHandler<SimpleClient> FloodEvent;
        #endregion

        #region Dispatcher
        protected DispatcherTask m_dispatcherTask;
        protected MessageDispatcher m_Dispatcher;
        public PacketActivityEnum Activity { get; set; }
        #endregion
        public ClientHost(SimpleClient client)
        {
            Activity = PacketActivityEnum.None;
            Client = client;
            logger = true;
            m_Dispatcher = new MessageDispatcher();
            m_dispatcherTask = new DispatcherTask(m_Dispatcher);
            m_dispatcherTask.Start();
            m_floods = new List<NetworkMessage>();
            m_flood_timer = new System.Timers.Timer();
            m_flood_timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            m_flood_timer.Interval = 1000;
            if (FloodQuit)
                m_flood_timer.Start();

            if (client != null)
            {
                Client.DataReceived += this.ClientDataReceive;
                Client.Disconnected += this.ClientDisconnected;
            }
        }

        private void ClientHost_FloodEvent(object sender, SimpleClient e)
        {
            if (FloodEvent != null)
                FloodEvent.Invoke(sender, e);
        }

        /// <summary>
        /// Permet de déconnecter le client
        /// </summary>
        public void Dispose()
        {
            Client.Stop();

            m_Dispatcher = null;
            m_dispatcherTask = null;
        }

        #region Events
        private List<NetworkMessage> m_floods;
        private System.Timers.Timer m_flood_timer;
        private readonly object myListLock = new object();



        protected List<NetworkMessage> Floods
        {
            get
            {
                lock (myListLock)
                {
                    return m_floods;
                }

            }
        }

        public virtual void ClientDataReceive(object sender, SimpleClient.DataReceivedEventArgs e)
        {
            try
            {
                var messageDataReader = new BigEndianReader(e.Data.Data);
                NetworkMessage message = MessageReceiver.BuildMessage((uint)e.Data.MessageId.Value, messageDataReader);
                if (FloodQuit)
                    Floods.Add(message);

                if (message != null)
                {                       
                    m_Dispatcher.Enqueue(message, this);
                }
            }
            catch (Exception ex)
            {
                ConsoleLogger.Error("Error for build message : " + e.Data.MessageId);
            }
        }

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            bool restart = true;
            m_flood_timer.Stop();
            if (Floods.Count > 9)
            {
                ClientHost_FloodEvent(null, Client);
                restart = false;
            }
            Floods.Clear();
            if (restart)
                m_flood_timer.Start();
        }

        private void ClientDisconnected(object sender, SimpleClient.DisconnectedEventArgs e)
        {
            OnDisconnected(new DisconnectedArgs(this));
        }
        private void OnDisconnected(DisconnectedArgs e)
        {
            if (Disconnected != null)
                Disconnected(this, e);
        }
        #endregion
        public class DisconnectedArgs : EventArgs
        {
            public ClientHost Host { get; private set; }

            public DisconnectedArgs(ClientHost host)
            {
                Host = host;
            }
        }
        public virtual void Send(NetworkMessage message)
        {
            var writer = new BigEndianWriter();

            MessagePacking pack = new MessagePacking();
            pack.Pack(message, writer);
            if (logger)
                ConsoleLogger.Debug("Sent : " + message.ToString().Split('.').Last());

            if (Client.Runing && Client.Socket.Connected)
                Client.Send(writer.Data);

            if (Client.Runing == false || Client.Socket.Connected == false)
                this.Dispose();
        }

        public void Send(byte[] data, int id)
        {
            var writer = new BigEndianWriter(data);

            MessagePacking pack = new MessagePacking();
            pack.Pack(id, writer);

            if (Client.Runing)
                Client.Send(writer.Data);
        }
        public void Send(byte[] bits)
        {
            if (Client.Runing)
                Client.Send(bits);
        }

        public void AddFrame(object obj)
        {
            try
            {
                m_Dispatcher.Register(obj);
            }
            catch (Exception ex)
            {
                ConsoleLogger.Debug("Error : " + ex.Message + " | Inner : " + ex.InnerException);
            }
        }

        public void RemoveFrame(Type obj)
        {
            try
            {
                if(m_Dispatcher != null)
                    m_Dispatcher.UnRegister(obj);
            }
            catch (Exception ex)
            {
                ConsoleLogger.Debug("Error : " + ex.Message + " | Inner : " + ex.InnerException);
            }
        }
    }
}
