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
            return new Vector4(lhs.x + rhs.x, lhs.y + rhs.y, lhs.z + rhs.z, lhs.w + rhs.w);
        }
        
        // operator for subtracting two Vector4 
        public static Vector4 operator -(Vector4 lhs, Vector4 rhs)
        {
            return new Vector4(lhs.x - rhs.x, lhs.y - rhs.y, lhs.z - rhs.z, lhs.w - rhs.w);
        }
       
        // defines op for multiplying the first Vector4 by a float number
        public static Vector4 operator *(Vector4 lhs, float multiplyBy)
        {
            return new Vector4(lhs.x * multiplyBy, lhs.y * multiplyBy, lhs.z * multiplyBy, lhs.w * multiplyBy);
        }

        // defines op for multiplying the first Vector4 by a float number
        public static Vector4 operator *(float multiplyBy, Vector4 rhs)
        {
            return new Vector4(rhs.x * multiplyBy, rhs.y * multiplyBy, rhs.z * multiplyBy, rhs.w * multiplyBy);
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

    }
}
