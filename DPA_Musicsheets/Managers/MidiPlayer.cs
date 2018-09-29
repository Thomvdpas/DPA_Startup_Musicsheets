using System;
using DPA_Musicsheets.Adapters;
using Sanford.Multimedia.Midi;

namespace DPA_Musicsheets.Managers
{
    public class MidiPlayer
    {
        private readonly OutputDevice _outputDevice;
        private MidiSequencer _midiSequencer;
        public bool IsRunning { get; set; }

        public MidiSequencer MidiSequencer
        {
            get => MidiSequencer;
            set
            {
                MidiSequencer = value ?? throw new ArgumentNullException(nameof(value));
                _midiSequencer = value;
            }
        }

        public MidiPlayer()
        {
            // The OutputDevice is a midi device on the midi channel of your computer.
            // The audio will be streamed towards this output.
            // DeviceID 0 is your computer's audio channel.
            _outputDevice = new OutputDevice(0);
            _midiSequencer = new MidiSequencer();

            _midiSequencer.GetSequencer().ChannelMessagePlayed += ChannelMessagePlayed;

            // Wanneer de sequence klaar is moeten we alles closen en stoppen.
            _midiSequencer.GetSequencer().PlayingCompleted += (playingSender, playingEvent) =>
            {
                _midiSequencer.Stop();
                IsRunning = false;
            };
        }

        // Wanneer een channelmessage langskomt sturen we deze direct door naar onze audio.
        // Channelmessages zijn tonen met commands als NoteOn en NoteOff
        // In midi wordt elke noot gespeeld totdat NoteOff is benoemd. Wanneer dus nooit een NoteOff komt nadat die een NoteOn heeft gehad
        // zal deze note dus oneindig lang blijven spelen.
        private void ChannelMessagePlayed(object sender, ChannelMessageEventArgs e)
        {
            try
            {
                _outputDevice.Send(e.Message);
            }
            catch (Exception ex) when (ex is ObjectDisposedException || ex is OutputDeviceException)
            {
                // Don't crash when we can't play
                // We have to do it this way because IsDisposed on
                // _outDevice may be false when it is being disposed
                // so this is the only safe way to prevent race conditions
            }
        }

        public void Start()
        {
            if (IsRunning) return;
            IsRunning = true;
            _midiSequencer.Continue();
        }

        public void Stop()
        {
            IsRunning = false;
            _midiSequencer.Stop();
            _midiSequencer.Position = 0;
        }

        public void Pause()
        {
            IsRunning = false;
            _midiSequencer.Stop();
        }

        /// <summary>
        /// Stop the player and clear the sequence on cleanup.
        /// </summary>
        public void Cleanup()
        {
            _midiSequencer.Stop();
            _midiSequencer.Dispose();
            _outputDevice.Dispose();
        }
    }
}