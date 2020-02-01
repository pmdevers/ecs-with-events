using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Engine
{
    public static partial class Math1
    {
        public static float Acos(float x)
        {
            return (float)System.Math.Acos(x);
        }

        public static float Acosh(float x)
        {

            if (x < (1f))
                return (0f);
            return (float)System.Math.Log(x + System.Math.Sqrt(x * x - (1f)));
        }

        public static float Asin(float x)
        {
            return (float)System.Math.Asin(x);
        }

        public static float Asinh(float x)
        {
            return (float)(x < 0f ? -1f : (x > 0f ? 1f : 0f)) * (float)System.Math.Log(System.Math.Abs(x) + System.Math.Sqrt(1f + x * x));
        }

        public static float Atan(float y, float x)
        {
            return (float)System.Math.Atan2(y, x);
        }

        public static float Atan(float y_over_x)
        {
            return (float)System.Math.Atan(y_over_x);
        }

        public static float Atanh(float x)
        {
            if (System.Math.Abs(x) >= 1f)
                return 0;
            return (0.5f) * (float)System.Math.Log((1f + x) / (1f - x));
        }

        public static float Cos(float angle)
        {
            return (float)System.Math.Cos(angle);
        }

        public static float Cosh(float angle)
        {
            return (float)System.Math.Cosh(angle);
        }

        public static float Degrees(float radians)
        {
            return radians * (57.295779513082320876798154814105f);
        }

        public static float Radians(float degrees)
        {
            return degrees * (0.01745329251994329576923690768489f);
        }

        public static float Sin(float angle)
        {
            return (float)System.Math.Sin(angle);
        }

        public static float Sinh(float angle)
        {
            return (float)System.Math.Sinh(angle);
        }

        public static float Tan(float angle)
        {
            return (float)System.Math.Tan(angle);
        }

        public static float Tanh(float angle)
        {
            return (float)System.Math.Tanh(angle);
        }
    }
}
