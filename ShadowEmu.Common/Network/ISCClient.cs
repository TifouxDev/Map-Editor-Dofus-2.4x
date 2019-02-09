using ShadowEmu.Common.IO;
using ShadowEmu.Common.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadowEmu.Common.Network
{
    public class ISCClient
    {
        private string m_address;
        private short m_port;

        private SimpleClient m_client;
        public ISCClient(string ip, short port)
        {
            m_address = ip;
            m_port = port;
            m_client = new SimpleClient();
        }


        public void Start()
        {
            m_client.Start(m_address, m_port);
            m_client.Disconnected += ClientDisconnected;
        }

        public void Send(ISCMessage message)
        {
            var writer = new BigEndianWriter();
          writer.WriteInt((int)message.RequestId);
            writer.WriteInt((int)message.MessageId);
            ConsoleLogger.Debug("[ISC] Sent : " + message.ToString().Split('.').Last());
            message.Serialize(writer);
            if (m_client.Runing)
                m_client.Send(writer.Data);
        }

        public void Send(byte[] bits)
        {
            if (m_client.Runing)
                m_client.Send(bits);
        }
        private void ClientDataReceive(object sender, SimpleClient.DataReceivedEventArgs e)
        {
            Logger.ConsoleLogger.Error("ISC : New data arrival");
        }

        private void ClientDisconnected(object sender, SimpleClient.DisconnectedEventArgs e)
        {
            Logger.ConsoleLogger.Error("ISC : Disconnected");
        }
    }
}
