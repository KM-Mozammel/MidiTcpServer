using MidiTcpServer;

var midi = new MidiHandler();
var server = new TcpServer();
var boradcast = new ClientBroadcaster(server.Clients);

midi.OnMidiMessage += boradcast.Broadcast;


server.Start();
midi.Start();

Console.ReadLine();