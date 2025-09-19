using MidiTcpServer;

var midi = new MidiHandler();
var wsBridge = new WebSocketServerBridge();

//var server = new TcpServer();
//var boradcast = new ClientBroadcaster(server.Clients);

midi.OnMidiMessage += wsBridge.Broadcast;

wsBridge.Start();
midi.Start();

Console.ReadLine();