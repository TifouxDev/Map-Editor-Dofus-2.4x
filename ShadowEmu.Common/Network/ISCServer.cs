using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ShadowEmu.Common.Network
{
    public class ISCServer
    {
        private short m_port;

        public SimpleServer Server;
        public List<ISCHost> m_clients;

        public ISCServer(short port)
        {
            m_port = port;
            Server = new SimpleServer();
            m_clients = new List<ISCHost>();
        }

        public void StartListen()
        {
            Server.Start(m_port);
        }

        private void ClientDisconnected(object sender, ISCHost.DisconnectedISCArgs e)
        {
            Logger.ConsoleLogger.Infos("ISC : server Closed.");
            m_clients.Remove(e.Host);
        }


    }
}
