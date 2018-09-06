﻿using DPA_Musicsheets.Enums;
using DPA_Musicsheets.Interfaces;

namespace DPA_Musicsheets.Models
{
    public abstract class BaseNote : ICloneable<BaseNote>
    {
        private double _duration;

        protected PitchType PitchType;
        protected NoteType NoteType;
        protected bool IsPoint;

        protected double Duration
        {
            get => IsPoint ? _duration * 1.5 : _duration;
            set => _duration = value;
        }

        protected BaseNote(PitchType pitchType, NoteType noteType, double duration)
        {
            PitchType = pitchType;
            NoteType = noteType;
            Duration = duration;
        }

        public abstract BaseNote ShallowClone();

        public abstract BaseNote Clone();
    }
}
