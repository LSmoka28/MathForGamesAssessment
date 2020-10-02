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

    }
}
