using System;

namespace Game.Engine
{
    /// <summary>
    /// Represents a two dimensional vector.
    /// </summary>
    public struct Vector2
    {
        public float x;
        public float y;

        public float this[int index]
        {
            get
            {
                if (index == 0) return x;
                else if (index == 1) return y;
                else throw new Exception("Out of range.");
            }
            set
            {
                if (index == 0) x = value;
                else if (index == 1) y = value;
                else throw new Exception("Out of range.");
            }
        }

        public Vector2(float s)
        {
            x = y = s;
        }

        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public Vector2(Vector2 v)
        {
            this.x = v.x;
            this.y = v.y;
        }

        public Vector2(Vector3 v)
        {
            this.x = v.x;
            this.y = v.y;
        }

        public static Vector2 operator +(Vector2 lhs, Vector2 rhs)
        {
            return new Vector2(lhs.x + rhs.x, lhs.y + rhs.y);
        }

        public static Vector2 operator +(Vector2 lhs, float rhs)
        {
            return new Vector2(lhs.x + rhs, lhs.y + rhs);
        }

        public static Vector2 operator -(Vector2 lhs, Vector2 rhs)
        {
            return new Vector2(lhs.x - rhs.x, lhs.y - rhs.y);
        }

        public static Vector2 operator -(Vector2 lhs, float rhs)
        {
            return new Vector2(lhs.x - rhs, lhs.y - rhs);
        }

        public static Vector2 operator *(Vector2 self, float s)
        {
            return new Vector2(self.x * s, self.y * s);
        }

        public static Vector2 operator *(float lhs, Vector2 rhs)
        {
            return new Vector2(rhs.x * lhs, rhs.y * lhs);
        }

        public static Vector2 operator *(Vector2 lhs, Vector2 rhs)
        {
            return new Vector2(rhs.x * lhs.x, rhs.y * lhs.y);
        }

        public static Vector2 operator /(Vector2 lhs, float rhs)
        {
            return new Vector2(lhs.x / rhs, lhs.y / rhs);
        }

        public float[] ToArray()
        {
            return new[] { x, y };
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
                if (this.x == vec.x && this.y == vec.y)
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
            return this.x.GetHashCode() ^ this.y.GetHashCode();
        }

        #endregion Comparision

        public static Vector2 Parse(string vector2string)
        {
            var startChar = 1;
            //get first number (z)
            var endChar = vector2string.IndexOf(",");
            var lastEnd = endChar;
            var x = float.Parse(vector2string.Substring(startChar, endChar - 1));
            //get second number (y)
            startChar = lastEnd + 1;
            endChar = vector2string.IndexOf(",", lastEnd);
            var y = float.Parse(vector2string.Substring(startChar, endChar));

            //pass back a vector2 type
            return new Vector2(x, y);
        }

        #region ToString support

        public override string ToString()
        {
            return $"{{{x}, {y}}}";
        }

        #endregion ToString support
    }
}