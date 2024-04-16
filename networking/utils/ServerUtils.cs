using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace networking.utils
{
    public abstract class AbstractServer
    {
        private TcpListener _server;
        private string _host;
        private int _port;

        protected AbstractServer(string host, int port)
        {
            this._host = host;
            this._port = port;
        }

        public void Start()
        {
            IPAddress address = IPAddress.Parse(_host);
            IPEndPoint endPoint = new IPEndPoint(address, _port);
            _server = new TcpListener(endPoint);
            _server.Start();

            while (true)
            {
                Console.WriteLine("Waiting for clients...");
                TcpClient client = _server.AcceptTcpClient();
                Console.WriteLine("Client connected");
                ProcessRequest(client);
            }
        }

        public abstract void ProcessRequest(TcpClient client);
    }

    public abstract class ConcurrentAbstractServer : AbstractServer
    {
        protected ConcurrentAbstractServer(string host, int port) : base(host, port) { }
        public override void ProcessRequest(TcpClient client)
        {
            Thread newClient = CreateWorker(client);
            newClient.Start();
        }

        protected abstract Thread CreateWorker(TcpClient client);
    }
    
    
}