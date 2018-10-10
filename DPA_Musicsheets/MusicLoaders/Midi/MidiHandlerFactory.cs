﻿using System.Collections.Generic;
using System.Linq;
using Sanford.Multimedia.Midi;

namespace DPA_Musicsheets.MusicLoaders.Midi
{
    public class MidiHandlerFactory
    {
        private readonly List<AbstractMidiHandler> _midiHandlers;

        public MidiHandlerFactory()
        {
            _midiHandlers = new List<AbstractMidiHandler>
            {
                new MidiMetaHandler(),
                new MidiChannelHandler()
            };
        }

        public AbstractMidiHandler GetMidiHandler(MessageType messageType)
        {
            return _midiHandlers.FirstOrDefault(handler => handler.MessageType.Equals(messageType));
        }
    }
}