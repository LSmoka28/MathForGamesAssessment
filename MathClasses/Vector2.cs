using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathClasses
{
    public class Vector2
    {
        //store x and y
        public float x, y;

        //default construct
        public Vector2()
        {
            //left blank
        }

        // convert from MathCal
        // convert from MathClasses.Vector to System Vector
        public static implicit operator System.Numerics.Vector2(Vector2 source)
        {
            return new System.Numerics.Vector2(source.x, source.y);
        }

        // convert from System.Numerics to math type
        public static implicit operator Vector2(System.Numerics.Vector2 source)
        {
            return new Vector2(source.X, source.Y);
        }

        // parameters to initialize a new Vector
        public Vector2(float xVal, float yVal)
        {
            x = xVal;
            y = yVal;           
        }
    }
}
