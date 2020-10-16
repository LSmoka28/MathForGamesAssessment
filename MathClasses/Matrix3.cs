using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathClasses
{
    public class Matrix3
    {
        public float m1, m2, m3, m4, m5, m6, m7, m8, m9;

        // set Matrix3 values and show desired column layout
        public Matrix3()
        {
            m1 = 1; m4 = 0; m7 = 0;
            m2 = 0; m5 = 1; m8 = 0;
            m3 = 0; m6 = 0; m9 = 1;
        }

        // set scale as 1 reference
        public readonly static Matrix3 identity = new Matrix3(1, 0, 0, 0, 1, 0, 0, 0, 1);

        // accepts value in parameters when initializing Matrix3
        public Matrix3(float mVal1, float mVal2, float mVal3, float mVal4, float mVal5, float mVal6, float mVal7, float mVal8, float mVal9)
        {
            this.m1 = mVal1;
            this.m2 = mVal2;
            this.m3 = mVal3;
            this.m4 = mVal4;
            this.m5 = mVal5;
            this.m6 = mVal6;
            this.m7 = mVal7;
            this.m8 = mVal8;
            this.m9 = mVal9;
        }

        // set value of Matrix3
        public void Set(float mVal1, float mVal2, float mVal3, float mVal4, float mVal5, float mVal6, float mVal7, float mVal8, float mVal9)
        {
            this.m1 = mVal1;
            this.m2 = mVal2;
            this.m3 = mVal3;
            this.m4 = mVal4;
            this.m5 = mVal5;
            this.m6 = mVal6;
            this.m7 = mVal7;
            this.m8 = mVal8;
            this.m9 = mVal9;
        }

        // Set methods that accepts Matrix3 param, mainly for multipling by scaling
        public void Set(Matrix3 other)
        {
            this.m1 = other.m1;
            this.m2 = other.m2;
            this.m3 = other.m3;
            this.m4 = other.m4;
            this.m5 = other.m5;
            this.m6 = other.m6;
            this.m7 = other.m7;
            this.m8 = other.m8;
            this.m9 = other.m9;
        }

        // swap values of Matrix3 to relay Row Major
        public Matrix3 GetTransposed()
        {
            return new Matrix3(m1, m4, m7, m2, m5, m8, m3, m6, m9);
        }

        // method for scaling Matrix3 XYZ by param
        public void Scale(float x, float y, float z)
        {
            Matrix3 m = new Matrix3();
            m.SetScaled(x, y, z);

            Set(this * m);
        }

        // scaling method that accepts Vector3 scaling
        public void Scale(Vector3 v)
        {
            Matrix3 m = new Matrix3();
            m.SetScaled(v.x, v.y, v.z);
            Set(this * m);
        }

        // sets scaled values to correct place in matrix
        public void SetScaled(float x, float y, float z)
        {
            m1 = x; m4 = 0; m7 = 0;
            m2 = 0; m5 = y; m8 = 0;
            m3 = 0; m6 = 0; m9 = z;
        }

        // scaling by Vector3, setting correct value
        public void SetScaled(Vector3 v)
        {
            m1 = v.x; m4 = 0; m7 = 0;
            m2 = 0; m5 = v.y; m8 = 0;
            m3 = 0; m6 = 0; m9 = v.z;
        }
        
        // Rotates counter-clockwise on the x-axis
        public void SetRotateX(double radians)
        {
            Set(1, 0, 0,
            0, (float)Math.Cos(radians), (float)Math.Sin(radians),
            0, (float)-Math.Sin(radians), (float)Math.Cos(radians));
        }
        // rotates y and z according to the Sin and Cos of the radian specified 
        public void RotateX(double xRadians)
        {
            Matrix3 rot = new Matrix3();
            rot.SetRotateX(xRadians);
            Set(this * rot);
        }

        // Rotates counter-clockwise on the y-axis
        public void SetRotateY(double radians)
        {
            Set((float)Math.Cos(radians), 0, (float)-Math.Sin(radians),
            0, 1, 0,
            (float)Math.Sin(radians), 0, (float)Math.Cos(radians));
        }
        // rotates x and z according to the Sin and Cos of the radian specified 
        public void RotateY(double yRadians)
        {
            Matrix3 rot = new Matrix3();
            rot.SetRotateY(yRadians);
            Set(this * rot);
        }

        // Rotates counter-clockwise on the Z-axis
        public void SetRotateZ(double radians)
        {
            Set((float)Math.Cos(radians),(float)Math.Sin(radians), 0,
            (float)-Math.Sin(radians), (float)Math.Cos(radians), 0,
            0, 0, 1);
        }       
        // rotates x and y according to the Sin and Cos of the radian specified 
        public void RotateZ(double zRadians)
        {
            Matrix3 rot = new Matrix3();
            rot.SetRotateZ(zRadians);
            Set(this * rot);
        }

        // TODO: figure out what Euler is for and how it implements
        public void SetEuler(float pitch, float yaw, float roll)
        {
            Matrix3 x = new Matrix3();
            Matrix3 y = new Matrix3();
            Matrix3 z = new Matrix3();
            x.SetRotateX(pitch);
            y.SetRotateY(yaw);
            z.SetRotateZ(roll);

            // rotate in a certain order
            Set(z * y * x);
        }

        // set translation 
        public void SetTranslation(float x, float y)
        {
            m7 = x;
            m8 = y;            
            m9 = 1;
        }

        public void Translate(float x, float y)
        {
            // apply vector offset
            m7 += x;
            m8 += y;            
        }





        //Matrix3 multiplication operator for two matrices
        public static Matrix3 operator *(Matrix3 lhs, Matrix3 rhs)
        {
            return new Matrix3(lhs.m1 * rhs.m1 + lhs.m4 * rhs.m2 + lhs.m7 * rhs.m3,
                               lhs.m2 * rhs.m1 + lhs.m5 * rhs.m2 + lhs.m8 * rhs.m3,
                               lhs.m3 * rhs.m1 + lhs.m6 * rhs.m2 + lhs.m9 * rhs.m3,

                               lhs.m1 * rhs.m4 + lhs.m4 * rhs.m5 + lhs.m7 * rhs.m6,
                               lhs.m2 * rhs.m4 + lhs.m5 * rhs.m5 + lhs.m8 * rhs.m6,
                               lhs.m3 * rhs.m4 + lhs.m6 * rhs.m5 + lhs.m9 * rhs.m6,

                               lhs.m1 * rhs.m7 + lhs.m4 * rhs.m8 + lhs.m7 * rhs.m9,
                               lhs.m2 * rhs.m7 + lhs.m5 * rhs.m8 + lhs.m8 * rhs.m9,
                               lhs.m3 * rhs.m7 + lhs.m6 * rhs.m8 + lhs.m9 * rhs.m9);
        }
    }
}