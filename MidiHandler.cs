using Sanford.Multimedia.Midi;
using System;

namespace MidiTcpServer
{
    public class MidiHandler
    {
        private InputDevice inputDevice;
        public event Action<string> OnMidiMessage;

        public void Start()
        {
            try
            {
                inputDevice = new InputDevice(0);
                inputDevice.ChannelMessageReceived += (s, e) =>
                {
                    var msg = e.Message;
                    string midiData = $"Note: {msg.Data1}, Velocity: {msg.Data2}";
                    Console.WriteLine(midiData);
                    OnMidiMessage?.Invoke(midiData);
                };
                inputDevice.StartRecording();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error initializing MIDI input device: {ex.Message}");
            }
        }
    }
}