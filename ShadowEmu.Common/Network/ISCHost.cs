using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadowEmu.Common.Network
{
    public class ISCHost
    {
        private SimpleClient m_client;
        public event EventHandler<DisconnectedISCArgs> Disconnected;
        public ISCHost(SimpleClient client)
        {
            m_client = client;
         
            if (client != null)
            {
                m_client.Disconnected += this.ClientDisconnected;
            }
        }
        #region Events

        private void ClientDisconnected(object sender, SimpleClient.DisconnectedEventArgs e)
        {
            OnDisconnected(new DisconnectedISCArgs(this));
        }

        #endregion
        public void Send(NetworkMessage message)
        {
         
        }

        public void Send(byte[] bits)
        {
            m_client.Send(bits);
        }
           private void OnDisconnected(DisconnectedISCArgs e)
        {
            if (Disconnected != null)
                Disconnected(this, e);
        }
        public class DisconnectedISCArgs : EventArgs
        {
            public ISCHost Host { get; private set; }

            public DisconnectedISCArgs(ISCHost host)
            {
                Host = host;
            }
        }
    }
}
