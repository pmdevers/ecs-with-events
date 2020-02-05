using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Engine
{
    public struct GameTime
    {
        private readonly float _time;

        public static GameTime operator +(GameTime a, GameTime b) => new GameTime(a._time + b._time);

        public static GameTime operator -(GameTime a, GameTime b) => new GameTime(a._time - b._time);

        public static GameTime operator *(GameTime a, GameTime b) => new GameTime(a._time * b._time);

        public static GameTime operator /(GameTime a, GameTime b) => new GameTime(a._time / b._time);

        public static bool operator ==(GameTime a, GameTime b) => a._time == b._time;

        public static bool operator !=(GameTime a, GameTime b) => a._time != b._time;

        public static bool operator <(GameTime a, GameTime b) => a._time < b._time;

        public static bool operator >(GameTime a, GameTime b) => a._time > b._time;

        public static bool operator <=(GameTime a, GameTime b) => a._time <= b._time;

        public static bool operator >=(GameTime a, GameTime b) => a._time >= b._time;

        public static explicit operator float(GameTime val) => val.ToFloat();

        public static explicit operator double(GameTime val) => val.ToDouble();

        public static implicit operator GameTime(float val) => new GameTime(val);

        public static implicit operator GameTime(double val) => new GameTime((float)val);

        public GameTime(float time = 0.0f)
        {
            _time = time;
        }

        public float GetSeconds()
        {
            return _time;
        }

        public float GetMilliseconds()
        {
            return _time * 1000.0f;
        }

        private double ToDouble()
        {
            return (double)_time;
        }

        private float ToFloat()
        {
            return _time;
        }

        public override bool Equals(object obj)
        {
            return obj is GameTime time &&
                   _time == time._time;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_time);
        }
    }
}