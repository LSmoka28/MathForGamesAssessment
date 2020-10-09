using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathClasses
{
    public class Colour
    {
        public UInt32 colour;
        public static byte red = 255;
        public static byte green = 128;
        public static byte blue = 255;

        public Colour()
        {
            
        }

        public Colour(byte red, byte green, byte blue, byte alpha)
        {

        }

        public byte GetRed()
        {
            return (byte)((colour & 0xff000000) >> 24);
            //UInt32 value = colour & 0xff000000;

            //colour = colour & 0x00ffffff;
            //byte red = 255;
            //UInt32 rValue = (UInt32)red << 24;

            //colour |= rValue;
        }

        public void SetRed(byte red)
        {
            colour = colour & 0x00ffffff;
            colour |= (UInt32)red << 24;
        }
        
        public byte GetGreen()
        {
            return (byte)((colour & 0xff000000) >> 24);
        }

        public void SetGreen(byte green)
        {

        }

        public byte GetBlue()
        {
            return (byte)((colour & 0xff000000) >> 24);
        }

        public void SetBlue(byte blue)
        {

        }

        public byte GetAlpha()
        {
            return (byte)((colour & 0xff000000) >> 24);
        }

        public void SetAlpha(byte alpha)
        {

        }

    }
}
