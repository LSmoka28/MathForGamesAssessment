using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathClasses
{
    public class Matrix4
    {
        
        public float m1, m2, m3, m4, m5, m6, m7, m8, m9, m10, m11, m12, m13, m14, m15, m16;

        // set scale as 1 refernce
        public readonly static Matrix4 identity = new Matrix4(1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1);


        public Matrix4()
        {
            m1 = 1; m5 = 0; m9 = 0; m13 = 0;
            m2 = 0; m6 = 1; m10 = 0; m14 = 0;
            m3 = 0; m7= 0; m11= 1; m15= 0;
            m4= 0; m8= 0; m12= 0; m16= 1;
        }
     
        // accept parameters for all Matrix4 value
        public Matrix4(float m1, float m2, float m3, float m4, float m5, float m6, float m7, float m8, float m9, float m10, float m11, float m12, float m13, float m14, float m15, float m16)
        {
            this.m1 = m1;
            this.m2 = m2;
            this.m3 = m3;
            this.m4 = m4;
            this.m5 = m5;
            this.m6 = m6;
            this.m7 = m7;
            this.m8 = m8;
            this.m9 = m9;
            this.m10 = m10;
            this.m11 = m11;
            this.m12 = m12;
            this.m13 = m13;
            this.m14 = m14;
            this.m15 = m15;
            this.m16 = m16;

        }
        // set value of Matrix4
        public void Set(float m1, float m2, float m3, float m4, float m5, float m6, float m7, float m8, float m9, float m10, float m11, float m12, float m13, float m14, float m15, float m16)
        {
            this.m1 = m1;
            this.m2 = m2;
            this.m3 = m3;
            this.m4 = m4;
            this.m5 = m5;
            this.m6 = m6;
            this.m7 = m7;
            this.m8 = m8;
            this.m9 = m9;
            this.m10 = m10;
            this.m11 = m11;
            this.m12 = m12;
            this.m13 = m13;
            this.m14 = m14;
            this.m15 = m15;
            this.m16 = m16;
        }

        // Set methods that accepts Matrix4 param
        public void Set(Matrix4 other)
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
            this.m10 = other.m10;
            this.m11 = other.m11;
            this.m12 = other.m12;
            this.m13 = other.m13;
            this.m14 = other.m14;
            this.m15 = other.m15;
            this.m16 = other.m16;
        }

        // swap value places to reflect row major
        public Matrix4 GetTransposed()
        {
            return new Matrix4(m1, m5, m9, m13, m2, m6, m10, m14, m3, m7, m11, m15, m4, m8, m12, m16);
        }

        // method for scaling Matrix4 XYZ by param, w does not get scaled
        public void Scale(float x, float y, float z)
        {
            Matrix4 m = new Matrix4();
            m.SetScaled(x, y, z);
            Set(this * m);
        }

        // method for scaling that accepts Vector4, w does not get scaled
        public void Scale(Vector4 v)
        {
            Matrix4 m = new Matrix4();
            m.SetScaled(v.x, v.y, v.z);
            Set(this * m);
        }

        // sets scaled values to correct place in matrix
        public void SetScaled(float x, float y, float z)
        {
            m1 = x; m2 = 0; m3 = 0; m4 = 0;
            m5 = 0; m6 = y; m7 = 0; m8 = 0;
            m9 = 0; m10 = 0; m11 = z; m12 = 0;
            m13 = 0; m14 = 0; m15 = 0; m16 = 1;
        }

        // scaling by Vector4, setting correct value
        public void SetScaled(Vector4 v)
        {
            m1 = v.x; m2 = 0; m3 = 0; m4 = 0;
            m5 = 0; m6 = v.y; m7 = 0; m8 = 0;
            m9 = 0; m10 = 0; m11 = v.z; m12 = 0;
            m13 = 0; m14 = 0; m15 = 0; m16 = 1;
        }

        // Rotates counter-clockwise on the x-axis
        public void SetRotateX(double radians)
        {
            m1 = 1; m2 = 0; m3 = 0; m4 = 0;
            m5 = 0; m6 = (float)Math.Cos(radians); m7 = (float)Math.Sin(radians); m8 = 0;
            m9 = 0; m10 = (float)-Math.Sin(radians); m11 = (float)Math.Cos(radians); m12 = 0;
            m13 = 0; m14 = 0; m15 = 0; m16 = 1;
        }
        // rotates y and z according to the Sin and Cos of the radian specified
        public void RotateX(double xRads)
        {
            Matrix4 rot = new Matrix4();
            rot.SetRotateX(xRads);
            Set(this * rot);
        }

        // Rotates counter-clockwise on the y-axis
        public void SetRotateY(double radians)
        {
            Set((float)Math.Cos(radians), 0, (float)-Math.Sin(radians), 0,
                0, 1, 0, 0,
                (float)Math.Sin(radians), 0, (float)Math.Cos(radians), 0,
                0, 0, 0, 1);
        }
        // rotates x and z according to the Sin and Cos of the radian specified
        public void RotateY(double yRads)
        {
            Matrix4 rot = new Matrix4();
            rot.SetRotateY(yRads);
            Set(this * rot);
        }

        // Rotates counter-clockwise on the z-axis
        public void SetRotateZ(double radians)
        {
            Set((float)Math.Cos(radians), (float)Math.Sin(radians), 0, 0,
                (float)-Math.Sin(radians), (float)Math.Cos(radians), 0, 0,
                0, 0, 1, 0,
                0, 0, 0, 1);
        }
        // rotates x and y according to the Sin and Cos of the radian specified
        public void RotateZ(double zRads)
        {
            Matrix4 rot = new Matrix4();
            rot.SetRotateZ(zRads);
            Set(this * rot);
        }

        // TODO: figure out what Euler is for and how it implements
        public void SetEuler(float pitch, float yaw, float roll)
        {
            Matrix4 x = new Matrix4();
            Matrix4 y = new Matrix4();
            Matrix4 z = new Matrix4();
            x.SetRotateX(pitch);
            y.SetRotateY(yaw);
            z.SetRotateZ(roll);

            // rotate in a certain order
            Set(z * y * x);
        }

        

        // Matrix4 multiplication op, column major
        public static Matrix4 operator *(Matrix4 lhs, Matrix4 rhs)
        {
            return new Matrix4(lhs.m1 * rhs.m1 + lhs.m5 * rhs.m2 + lhs.m9 * rhs.m3 + lhs.m13 * rhs.m4,
                               lhs.m2 * rhs.m1 + lhs.m6 * rhs.m2 + lhs.m10 * rhs.m3 + lhs.m14 * rhs.m4,
                               lhs.m3 * rhs.m1 + lhs.m7 * rhs.m2 + lhs.m11 * rhs.m3 + lhs.m15 * rhs.m4,
                               lhs.m4 * rhs.m1 + lhs.m8 * rhs.m2 + lhs.m12 * rhs.m3 + lhs.m16 * rhs.m4,

                               lhs.m1 * rhs.m5 + lhs.m5 * rhs.m6 + lhs.m9 * rhs.m7 + lhs.m13 * rhs.m8,
                               lhs.m2 * rhs.m5 + lhs.m6 * rhs.m6 + lhs.m10 * rhs.m7 + lhs.m14 * rhs.m8,
                               lhs.m3 * rhs.m5 + lhs.m7 * rhs.m6 + lhs.m11 * rhs.m7 + lhs.m15 * rhs.m8,
                               lhs.m4 * rhs.m5 + lhs.m8 * rhs.m6 + lhs.m12 * rhs.m7 + lhs.m16 * rhs.m8,

                               lhs.m1 * rhs.m9 + lhs.m5 * rhs.m10 + lhs.m9 * rhs.m11 + lhs.m13 * rhs.m12,
                               lhs.m2 * rhs.m9 + lhs.m6 * rhs.m10 + lhs.m10 * rhs.m11 + lhs.m14 * rhs.m12,
                               lhs.m3 * rhs.m9 + lhs.m7 * rhs.m10 + lhs.m11 * rhs.m11 + lhs.m15 * rhs.m12,
                               lhs.m4 * rhs.m9 + lhs.m8 * rhs.m10 + lhs.m12 * rhs.m11 + lhs.m16 * rhs.m12,

                               lhs.m1 * rhs.m13 + lhs.m5 * rhs.m14 + lhs.m9 * rhs.m15 + lhs.m13 * rhs.m16,
                               lhs.m2 * rhs.m13 + lhs.m6 * rhs.m14 + lhs.m10 * rhs.m15 + lhs.m14 * rhs.m16,
                               lhs.m3 * rhs.m13 + lhs.m7 * rhs.m14 + lhs.m11 * rhs.m15 + lhs.m15 * rhs.m16,
                               lhs.m4 * rhs.m13 + lhs.m8 * rhs.m14 + lhs.m12 * rhs.m15 + lhs.m16 * rhs.m16);
        }
    }

}
