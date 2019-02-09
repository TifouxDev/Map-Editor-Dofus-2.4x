using System;
using System.Net;
using System.Net.Sockets;

namespace ShadowEmu.Common.Network
{
    public class SimpleServer
    {

        #region Variables

        private Socket socketListener;
        private bool runing = false;

        public bool Connected
        {
            get { return runing; }
        }
        public SimpleServer()
        {
            socketListener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socketListener.ReceiveTimeout = -1;
            socketListener.SendTimeout = -1; 
        }

        #endregion

        #region Methods

        public void Start(short listenPort)
        {
            if (!runing)
            {
                runing = true;
                socketListener.Bind(new IPEndPoint(IPAddress.Any, listenPort));
                socketListener.Listen(5);
                socketListener.BeginAccept(BeiginAcceptCallBack, socketListener);
            }
        }

        public void Stop()
        {
            runing = false;
            socketListener.Shutdown(SocketShutdown.Both);
        }

        private void BeiginAcceptCallBack(IAsyncResult result)
        {
            if (runing)
            {
                Socket listener = (Socket)result.AsyncState;
                Socket acceptedSocket = listener.EndAccept(result);
                OnConnectionAccepted(acceptedSocket);
                socketListener.BeginAccept(BeiginAcceptCallBack, socketListener);
            }
        }

        #endregion

        #region Events

        public delegate void ConnectionAcceptedDelegate(Socket acceptedSocket);
        public event ConnectionAcceptedDelegate ConnectionAccepted;
        private void OnConnectionAccepted(Socket client)
        {
            if (ConnectionAccepted != null)
                ConnectionAccepted(client);
        }

        #endregion

    }
}
