using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathClasses
{
    public class Vector4
    {
        public float x, y, z, w;

        // default constructor
        public Vector4()
        {
            // left intentionally blank            
        }

        // Vector4 that accepts four values for new pos
        public Vector4(float xVal, float yVal, float zVal, float wVal)
        {
            x = xVal;
            y = yVal;
            z = zVal;
            w = wVal;
        }

        // operator for adding two Vector4 
        public static Vector4 operator +(Vector4 lhs, Vector4 rhs)
        {
            return new Vector4(lhs.x + rhs.x, 
                               lhs.y + rhs.y, 
                               lhs.z + rhs.z, 
                               lhs.w + rhs.w);
        }
        
        // operator for subtracting two Vector4 
        public static Vector4 operator -(Vector4 lhs, Vector4 rhs)
        {
            return new Vector4(lhs.x - rhs.x, 
                               lhs.y - rhs.y, 
                               lhs.z - rhs.z, 
                               lhs.w - rhs.w);
        }
       
        // defines op for multiplying the first Vector4 by a float number
        public static Vector4 operator *(Vector4 lhs, float multiplyBy)
        {
            return new Vector4(lhs.x * multiplyBy, 
                               lhs.y * multiplyBy, 
                               lhs.z * multiplyBy, 
                               lhs.w * multiplyBy);
        }

        // defines op for multiplying the first Vector4 by a float number
        public static Vector4 operator *(float multiplyBy, Vector4 rhs)
        {
            return new Vector4(rhs.x * multiplyBy, 
                               rhs.y * multiplyBy, 
                               rhs.z * multiplyBy, 
                               rhs.w * multiplyBy);
        }

        // defines op for dividing the first Vector4 by a float number
        public static Vector4 operator /(Vector4 lhs, float divideBy)
        {
            return new Vector4(lhs.x / divideBy, 
                               lhs.y / divideBy, 
                               lhs.z / divideBy, 
                               lhs.w / divideBy);
        }

        // defines op for dividing the second Vector4 by a float number
        public static Vector4 operator /(float divideBy, Vector4 rhs)
        {
            return new Vector4(rhs.x / divideBy, 
                               rhs.y / divideBy, 
                               rhs.z / divideBy, 
                               rhs.w / divideBy);
        }

        // defines op for multiplying vector by matrix
        public static Vector4 operator *(Matrix4 lhs, Vector4 rhs)
        {
            return new Vector4((lhs.m1 * rhs.x) + (lhs.m2 * rhs.y) + (lhs.m3 * rhs.z) + (lhs.m4 * rhs.w),
                               (lhs.m5 * rhs.x) + (lhs.m6 * rhs.y) + (lhs.m7 * rhs.z) + (lhs.m8 * rhs.w),
                               (lhs.m9 * rhs.x) + (lhs.m10 * rhs.y) + (lhs.m11 * rhs.z) + (lhs.m12 * rhs.w),
                               (lhs.m13 * rhs.x) + (lhs.m14 * rhs.y) + (lhs.m15 * rhs.z) + (lhs.m16 * rhs.w));
        }
        // method for getting mag of vector4
        public float Magnitude()
        {
            return (float)Math.Sqrt(x * x + y * y + z * z + w * w);
        }

        // method for normalizing the mag
        public void Normalize()
        {
            float m = Magnitude();
            this.x /= m;
            this.y /= m;
            this.z /= m;
            this.w /= m;
        }
        public Vector4 GetNormalised()
        {
            return this / Magnitude();
        }


        public float Dot(Vector4 rhs)
        {
            return x * rhs.x + y * rhs.y + z * rhs.z + w * rhs.w;
        }

        // method to get cross product of two Vector4
        public Vector4 Cross(Vector4 rhs)
        {
            return new Vector4(
                y * rhs.z - z * rhs.y,
                z * rhs.x - x * rhs.z,
                x * rhs.y - y * rhs.x, 
                0f);
        }
    }
}
