using System;
using System.Collections.Generic;
using DPA_Musicsheets.Adapters;
using DPA_Musicsheets.Models;
using PSAMControlLibrary;
using Sanford.Multimedia.Midi;

namespace DPA_Musicsheets.MusicLoaders.Midi
{
    public class MidiMetaHandler : AbstractMidiHandler
    {
        private MusicPiece _currentMusicPiece;
        private MidiEvent _currentMidiEvent;

        private Dictionary<MetaType, Action> MetaActionDictionary => new Dictionary<MetaType, Action>
        {
            {MetaType.TimeSignature, HandleTimeSignature},
            {MetaType.Tempo, HandleTempo},
            {MetaType.EndOfTrack, HandleEndOfTrack},
            {MetaType.Marker, HandleMarker}
        };

        public MidiMetaHandler(MidiStrategy midiStrategy)
        {
            MidiStrategy = midiStrategy;
            MessageType = MessageType.Meta;
        }

        public override void Handle(MidiEvent midiEvent, MusicPiece piece)
        {
            _currentMidiEvent = midiEvent;
            _currentMusicPiece = piece;

            if (midiEvent.MidiMessage is MetaMessage metaMessage && MetaActionDictionary.TryGetValue(metaMessage.MetaType, out var action))
            {
                action();
            }
        }

        private void HandleTimeSignature()
        {
            if (!(_currentMidiEvent.MidiMessage is MetaMessage metaMessage)) return;
            var timeSignatureBytes = metaMessage.GetBytes();

            var beatNote = timeSignatureBytes[0];
            var beatsPerBar = (int)(1 / Math.Pow(timeSignatureBytes[1], -2));

            // Correct time signature
            var rest = beatsPerBar % 4;
            beatsPerBar -= rest;

            this.MidiStrategy.Change(_currentMidiEvent.AbsoluteTicks, new Signature(beatNote, beatsPerBar));
        }

        private void HandleTempo()
        {
            throw new NotImplementedException();
        }

        private void HandleEndOfTrack()
        {
            throw new NotImplementedException();
        }

        private void HandleMarker()
        {
            throw new NotImplementedException();
        }
    }
}