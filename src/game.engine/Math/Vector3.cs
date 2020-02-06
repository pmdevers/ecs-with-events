﻿using System;

namespace Game.Engine
{
    /// <summary>
    /// Represents a three dimensional vector.
    /// </summary>
    public struct Vector3
    {
        public float x;
        public float y;
        public float z;
        
        public float X
        {
            get => x;
            set => x = value;
        }

        public float this[int index]
        {
            get
            {
                if (index == 0) return x;
                else if (index == 1) return y;
                else if (index == 2) return z;
                else throw new Exception("Out of range.");
            }
            set
            {
                if (index == 0) x = value;
                else if (index == 1) y = value;
                else if (index == 2) z = value;
                else throw new Exception("Out of range.");
            }
        }

        public Vector3(float s)
        {
            x = y = z = s;
        }

        public Vector3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public Vector3(Vector3 v)
        {
            this.x = v.x;
            this.y = v.y;
            this.z = v.z;
        }

        public Vector3(Vector4 v)
        {
            this.x = v.x;
            this.y = v.y;
            this.z = v.z;
        }

        public Vector3(Vector2 xy, float z)
        {
            this.x = xy.x;
            this.y = xy.y;
            this.z = z;
        }

        public static Vector3 operator +(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3(lhs.x + rhs.x, lhs.y + rhs.y, lhs.z + rhs.z);
        }

        public static Vector3 operator +(Vector3 lhs, float rhs)
        {
            return new Vector3(lhs.x + rhs, lhs.y + rhs, lhs.z + rhs);
        }

        public static Vector3 operator -(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3(lhs.x - rhs.x, lhs.y - rhs.y, lhs.z - rhs.z);
        }

        public static Vector3 operator -(Vector3 lhs, float rhs)
        {
            return new Vector3(lhs.x - rhs, lhs.y - rhs, lhs.z - rhs);
        }

        public static Vector3 operator *(Vector3 self, float s)
        {
            return new Vector3(self.x * s, self.y * s, self.z * s);
        }

        public static Vector3 operator *(float lhs, Vector3 rhs)
        {
            return new Vector3(rhs.x * lhs, rhs.y * lhs, rhs.z * lhs);
        }

        public static Vector3 operator /(Vector3 lhs, float rhs)
        {
            return new Vector3(lhs.x / rhs, lhs.y / rhs, lhs.z / rhs);
        }

        public static Vector3 operator *(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3(rhs.x * lhs.x, rhs.y * lhs.y, rhs.z * lhs.z);
        }

        public float[] ToArray()
        {
            return new[] { x, y, z };
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
            if (obj.GetType() == typeof(Vector3))
            {
                var vec = (Vector3)obj;
                if (this.x == vec.x && this.y == vec.y && this.z == vec.z)
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
        public static bool operator ==(Vector3 v1, Vector3 v2)
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
        public static bool operator !=(Vector3 v1, Vector3 v2)
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
            return this.x.GetHashCode() ^ this.y.GetHashCode() ^ this.z.GetHashCode();
        }

        #endregion Comparision

        #region ToString support

        public override string ToString()
        {
            return String.Format("[{0}, {1}, {2}]", x, y, z);
        }

        #endregion ToString support
    }
}