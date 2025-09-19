using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace MidiTcpServer
{
    public class ClientBroadcaster
    {
        private List<TcpClient> clients;

        public ClientBroadcaster(List<TcpClient> clients)
        {
            this.clients = clients;
        }

        public void Broadcast(string message)
        {
            byte[] data = Encoding.UTF8.GetBytes(message + "\n");
            foreach (var client in clients)
            {
                if (client.Connected)
                {
                    client.GetStream().Write(data, 0, data.Length);
                }
            }
        }
    }
}
