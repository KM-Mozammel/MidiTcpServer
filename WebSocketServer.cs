using Fleck;
using System.Collections.Generic;

namespace MidiTcpServer
{
    public class WebSocketServerBridge
    {
        private List<IWebSocketConnection> clients = new List<IWebSocketConnection>();

        public void Start(int port = 8181)
        {
            var server = new WebSocketServer($"ws://0.0.0.0:{port}");
            server.Start(socket =>
            {
                socket.OnOpen = () => clients.Add(socket);
                socket.OnClose = () => clients.Remove(socket);
            });
            Console.WriteLine($"WebSocket server started on ws://localhost:{port}");
        }

        public void Broadcast(string message)
        {
            foreach (var client in clients)
            {
                client.Send(message);
            }
        }
    }
}