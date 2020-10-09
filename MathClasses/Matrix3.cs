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

        public Matrix3()
        {
            m1 = 1; m2 = 0; m3 = 0;
            m4 = 0; m5 = 1; m6 = 0;
            m7 = 0; m8 = 0; m9 = 1;
        }

        public readonly static Matrix3 identity = new Matrix3(1, 0, 0, 0, 1, 0, 0, 0, 1);

        public Matrix3(float mVal1, float mVal2, float mVal3, float mVal4, float mVal5, float mVal6, float mVal7, float mVal8, float mVal9)
        {
            
        }

        public Matrix3 GetTransposed()
        {
            return new Matrix3(m1, m4, m7, m2, m5, m8, m3, m6, m9);
        }

        public Matrix3 Set(Matrix3 m)
        {
            return new Matrix3(m1,m2,m3,m4,m5,m6,m7,m8,m9);
        }
        public Matrix3 Set(float mVal1, float mVal2, float mVal3, float mVal4, float mVal5, float mVal6, float mVal7, float mVal8, float mVal9)
        {
            return new Matrix3(mVal1, mVal2, mVal3, mVal4, mVal5, mVal6, mVal7, mVal8, mVal9);
        }

        public void Scale(float x, float y, float z)
        {
            Matrix3 m = new Matrix3();
            m.SetScaled(x, y, z);

            Set(this * m);
        }

        public void Scale(Vector3 v)
        {
            Matrix3 m = new Matrix3();
            m.SetScaled(v.x, v.y, v.z);
            Set(this * m);
        }

        public void SetScaled(float x, float y, float z)
        {
            m1 = x; m2 = 0; m3 = 0;
            m4 = 0; m5 = y; m6 = 0;
            m7 = 0; m8 = 0; m9 = z;
        }
        public void SetScaled(Vector3 v)
        {
            m1 = v.x; m2 = 0; m3 = 0;
            m4 = 0; m5 = v.y; m6 = 0;
            m7 = 0; m8 = 0; m9 = v.z;
        }

        public void SetRotateX(double radians)
        {
            Set(1, 0, 0,
            0, (float)Math.Cos(radians), (float)Math.Sin(radians),
            0, (float)-Math.Sin(radians), (float)Math.Cos(radians));
        }
        public void RotateX(double radians)
        {
            Matrix3 m = new Matrix3();
            m.SetRotateX(radians);
            Set(this * m);
        }

        public void SetRotateY(double radians)
        {

        }

        public void SetRotateZ(double radians)
        {

        }

        public static Matrix3 operator *(Matrix3 lhs, Matrix3 rhs)
        {
            return new Matrix3(lhs.m1*rhs.m1 + lhs.m4*rhs.m2 + lhs.m7*rhs.m3, 
                               lhs.m1*rhs.m4 + lhs.m4*rhs.m5 + lhs.m7*rhs.m6, 
                               lhs.m1*rhs.m7 + lhs.m4*rhs.m8 + lhs.m7*rhs.m9,
                               lhs.m2*rhs.m1 + lhs.m5*rhs.m2 + lhs.m8*rhs.m3, 
                               lhs.m2*rhs.m4 + lhs.m5*rhs.m5 + lhs.m8*rhs.m6, 
                               lhs.m2*rhs.m7 + lhs.m5*rhs.m8 + lhs.m8*rhs.m9,
                               lhs.m3*rhs.m1 + lhs.m6*rhs.m2 + lhs.m9*rhs.m3, 
                               lhs.m3*rhs.m4 + lhs.m6*rhs.m5 + lhs.m9*rhs.m6, 
                               lhs.m3*rhs.m7 + lhs.m6*rhs.m8 + lhs.m9*rhs.m9);
        }
    }
}