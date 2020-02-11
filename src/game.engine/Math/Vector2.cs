using System;

namespace Game.Engine
{
    /// <summary>
    /// Represents a two dimensional vector.
    /// </summary>
    public struct Vector2
    {
        public float X;
        public float Y;

        public float this[int index]
        {
            get
            {
                if (index == 0) return X;
                else if (index == 1) return Y;
                else throw new Exception("Out of range.");
            }
            set
            {
                if (index == 0) X = value;
                else if (index == 1) Y = value;
                else throw new Exception("Out of range.");
            }
        }

        public Vector2(float s)
        {
            X = Y = s;
        }

        public Vector2(float x, float y)
        {
            this.X = x;
            this.Y = y;
        }

        public Vector2(Vector2 v)
        {
            this.X = v.X;
            this.Y = v.Y;
        }

        public Vector2(Vector3 v)
        {
            this.X = v.x;
            this.Y = v.y;
        }
        public static Vector2 UnitX => new Vector2(1.0f, 0.0f);
        public static Vector2 UnitY => new Vector2(0.0f, 1.0f);
        public static Vector2 Zero => new Vector2(0f);

        public float LengthSquared()
        {
            return X * X + Y * Y;
        }

        public static float Dot(Vector2 value1, Vector2 value2)
        {
            return value1.X * value2.X +
                   value1.Y * value2.Y;
        }

        public static Vector2 TransformNormal(Vector2 normal, Matrix2 transform)
        {
            return new Vector2(
                normal.X * transform.M11 + normal.X * transform.M21,
                normal.X * transform.M12 + normal.X * transform.M22);
        }

        public static Vector2 Normalize(Vector2 value)
        {
            
                float ls = value.X * value.X + value.Y * value.Y;
                float invNorm = 1.0f / (float)Math.Sqrt((double)ls);
 
                return new Vector2(
                    value.X * invNorm,
                    value.Y * invNorm);
            
        }

        public static Vector2 operator +(Vector2 lhs, Vector2 rhs)
        {
            return new Vector2(lhs.X + rhs.X, lhs.Y + rhs.Y);
        }

        public static Vector2 operator +(Vector2 lhs, float rhs)
        {
            return new Vector2(lhs.X + rhs, lhs.Y + rhs);
        }

        public static Vector2 operator -(Vector2 lhs, Vector2 rhs)
        {
            return new Vector2(lhs.X - rhs.X, lhs.Y - rhs.Y);
        }

        public static Vector2 operator -(Vector2 lhs, float rhs)
        {
            return new Vector2(lhs.X - rhs, lhs.Y - rhs);
        }

        public static Vector2 operator *(Vector2 self, float s)
        {
            return new Vector2(self.X * s, self.Y * s);
        }

        public static Vector2 operator *(float lhs, Vector2 rhs)
        {
            return new Vector2(rhs.X * lhs, rhs.Y * lhs);
        }

        public static Vector2 operator *(Vector2 lhs, Vector2 rhs)
        {
            return new Vector2(rhs.X * lhs.X, rhs.Y * lhs.Y);
        }

        public static Vector2 operator /(Vector2 lhs, float rhs)
        {
            return new Vector2(lhs.X / rhs, lhs.Y / rhs);
        }

        public float[] ToArray()
        {
            return new[] { X, Y };
        }

        #region Comparision

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// The Difference is detected by the different values
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj.GetType() == typeof(Vector2))
            {
                var vec = (Vector2)obj;
                if (this.X == vec.X && this.Y == vec.Y)
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="v1">The first Vector.</param>
        /// <param name="v2">The second Vector.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator ==(Vector2 v1, Vector2 v2)
        {
            return v1.Equals(v2);
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="v1">The first Vector.</param>
        /// <param name="v2">The second Vector.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator !=(Vector2 v1, Vector2 v2)
        {
            return !v1.Equals(v2);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        public override int GetHashCode()
        {
            return this.X.GetHashCode() ^ this.Y.GetHashCode();
        }

        #endregion Comparision

        public static Vector2 Parse(string s)
        {
            var startChar = 1;
            //get first number (z)
            var endChar = s.IndexOf(",");
            var lastEnd = endChar;
            var x = float.Parse(s.Substring(startChar, endChar - 1));
            //get second number (Y)
            startChar = lastEnd + 1;
            endChar = s.IndexOf(",", lastEnd);
            var y = float.Parse(s.Substring(startChar, endChar));

            //pass back a vector2 type
            return new Vector2(x, y);
        }

        #region ToString support

        public override string ToString()
        {
            return $"{{{X}, {Y}}}";
        }

        #endregion ToString support
    }
}