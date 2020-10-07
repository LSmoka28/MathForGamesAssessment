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

        
        

        public Colour()
        {
            
        }

        public Colour(byte red, byte green, byte blue, byte alpha)
        {

        }

        public byte GetRed()
        {
            colour = colour & 0x00ffffff;
            byte red = 255;
            UInt32 rValue = (UInt32)red << 24;

            colour |= rValue;
        }

        public void SetRed(byte red)
        {
            colour = colour & 0x00ffffff;
            colour |= (UInt32)red << 24;
        }
        
        public byte GetGreen()
        {

        }

        public void SetGreen(byte green)
        {

        }

        public byte GetBlue()
        {

        }

        public void SetBlue(byte blue)
        {

        }

        public byte GetAlpha()
        {

        }

        public void SetAlpha(byte alpha)
        {

        }

    }
}
