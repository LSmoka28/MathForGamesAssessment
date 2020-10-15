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
        public static byte green = 255;
        public static byte blue = 255;
        public static byte alpha = 255;

        public Colour()
        {
            
        }

        public Colour(byte redV, byte greenV, byte blueV, byte alphaV)
        {
            colour = redV;
            colour = greenV;
            colour = blueV;
            colour = alphaV;
        }

        public byte GetRed()
        {
            UInt32 value = colour & 0xff000000;
            red = (byte)(value << 24);


            return (byte)((colour & 0xff000000) >> 24);           
        }

        public void SetRed(byte red)
        {           
            colour = colour & 0x00ffffff;
            colour |= (UInt32)red << 24;
        }
        
        public byte GetGreen()
        {
            return (byte)((colour & 0x00ff0000) >> 16);
        }

        public void SetGreen(byte green)
        {
            colour = colour & 0x00ffffff;
            colour |= (UInt32)green << 16;
        }

        public byte GetBlue()
        {
            return (byte)((colour & 0x0000ff00) >> 8);
        }

        public void SetBlue(byte blue)
        {
            colour = colour & 0x00ffffff;
            colour |= (UInt32)blue << 8;
        }

        public byte GetAlpha()
        {
            return (byte)((colour & 0x000000ff) >> 0);
        }

        public void SetAlpha(byte alpha)
        {
            colour = colour & 0x00ffffff;
            colour |= (UInt32)alpha << 0;
        }

    }
}
