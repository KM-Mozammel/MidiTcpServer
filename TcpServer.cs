using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;

namespace MidiTcpServer
{
    public class TcpServer
    {
        private TcpListener listener;
        public List<TcpClient> Clients { get; } = new List<TcpClient>();

        public void Start(int port = 5000)
        {
            listener = new TcpListener(IPAddress.Any, port);
            listener.Start();

            Console.WriteLine($"TCP Server started on port {port}");
            listener.BeginAcceptTcpClient(OnClientConnected, null);
        }

        private void OnClientConnected(IAsyncResult ar)
        {
            TcpClient client = listener.EndAcceptTcpClient(ar);
            Clients.Add(client);
            Console.WriteLine("Client connected");
            listener.BeginAcceptTcpClient(OnClientConnected, null);
        }
    }
}
