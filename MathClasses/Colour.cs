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
        public static byte red;
        public static byte green;
        public static byte blue;
        public static byte alpha;

        public Colour()
        {
            
        }

        public Colour(byte redV, byte greenV, byte blueV, byte alphaV)
        {
            red = redV;
            green = greenV;
            blue = blueV;
            alpha = alphaV;
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
            colour = colour & 0x00ffffff;
            colour |= (UInt32)green << 12;
        }

        public byte GetBlue()
        {
            return (byte)((colour & 0xff000000) >> 24);
        }

        public void SetBlue(byte blue)
        {
            colour = colour & 0x00ffffff;
            colour |= (UInt32)blue << 24;
        }

        public byte GetAlpha()
        {
            return (byte)((colour & 0xff000000) >> 24);
        }

        public void SetAlpha(byte alpha)
        {
            colour = colour & 0x00ffffff;
            colour |= (UInt32)alpha << 24;
        }

    }
}
