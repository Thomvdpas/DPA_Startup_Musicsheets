using System;
using System.Collections.Generic;
using DPA_Musicsheets.Adapters;
using DPA_Musicsheets.Models;
using PSAMControlLibrary;
using Sanford.Multimedia.Midi;

namespace DPA_Musicsheets.MusicLoaders.Midi
{
    public class MidiStrategy
    {
        private readonly Sequence _sequence;
        private readonly MidiHandlerFactory _midiHandlerFactory;
        private MusicPiece _musicPiece;

        public MidiStrategy(Sequence sequence)
        {
            _sequence = sequence;
            _midiHandlerFactory = new MidiHandlerFactory(this);

            TimeSignatures = new Dictionary<int, Signature>();
            Markers = new Dictionary<int, List<Tuple<Marker, int>>>();
        }

        public Dictionary<int, Signature> TimeSignatures { get; set; }

        public Dictionary<int, List<Tuple<Marker, int>>> Markers { get; set; }

        public MusicPiece Convert()
        {
            _musicPiece = new MusicPiece(_sequence.Division);

            foreach (var track in _sequence)
            {
                foreach (var midiEvent in track.Iterator())
                {
                    var messageType = midiEvent.MidiMessage.MessageType;
                    var midiHandler = _midiHandlerFactory.GetMidiHandler(messageType);
                    midiHandler.Handle(midiEvent, _musicPiece);
                }
            }
            
            return _musicPiece;
        }

        public void Change(int absoluteTicks, Signature timeSignature)
        {
            if (!TimeSignatures.ContainsKey(absoluteTicks))
            {
                TimeSignatures.Add(absoluteTicks, timeSignature);
            }

            if (_musicPiece.Signature == null)
            {
                _musicPiece. = timeSignature;
            }
        }
    }
}