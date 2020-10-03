using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathClasses
{
    public class Vector3
    {
        // store values of x y z
        public float x, y, z;

        // default constructor
        public Vector3()
        {
            // left blank intentionally
        }

        // parameters to initialize a new Vector
        public Vector3(float xVal, float yVal, float zVal)
        {
            x = xVal;
            y = yVal;
            z = zVal;
        }

        // addition operator for two Vector3
        public static Vector3 operator +(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3(lhs.x + rhs.x, lhs.y + rhs.y, lhs.z + rhs.z);
        }
        // subtraction operator for two Vector3
        public static Vector3 operator -(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3(lhs.x - rhs.x, lhs.y - rhs.y, lhs.z - rhs.z);
        }

        // defines op for multiplying the first Vector3 by a float number
        public static Vector3 operator *(Vector3 lhs, float multiplyBy)
        {
            return new Vector3(lhs.x * multiplyBy, lhs.y * multiplyBy, lhs.z * multiplyBy);
        }
        
        // defines op for multiplying the second Vector3 by a float number
        public static Vector3 operator *(float multiplyBy, Vector3 rhs)
        {
            return new Vector3(rhs.x * multiplyBy, rhs.y * multiplyBy, rhs.z * multiplyBy);
        }
        
        // defines op for dividing the first Vector3 by a float number
        public static Vector3 operator /(Vector3 lhs, float divideBy)
        {
            return new Vector3(lhs.x / divideBy, lhs.y / divideBy, lhs.z / divideBy);
        }

        // defines op for dividing the second Vector3 by a float number
        public static Vector3 operator /(float divideBy, Vector3 rhs)
        {
            return new Vector3(rhs.x / divideBy, rhs.y / divideBy, rhs.z / divideBy);
        }
        // method for getting mag of vector3
        public float Magnitude()
        {
            return (float)Math.Sqrt(x * x + y * y + z * z);
        }

        // method for normalizing the mag
        public void Normalize()
        {
            float m = Magnitude();
            this.x /= m;
            this.y /= m;
            this.z /= m;
        }

        public Vector3 GetNormalised()
        {
            return this / Magnitude();
        }


        // method to get dot prodcut of two Vector3
        public float Dot(Vector3 rhs)
        {
            return x * rhs.x + y * rhs.y + z * rhs.z;
        }

        // method to get cross product of two Vector3
        public Vector3 Cross(Vector3 rhs)
        {
            return new Vector3(y * rhs.z - z * rhs.y, z * rhs.x - x * rhs.z, x * rhs.y - y * rhs.x);
        }

    }
}
