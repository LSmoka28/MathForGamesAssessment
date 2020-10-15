using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathClasses
{
    public class Colour
    {
        // unassigned int for colour
        public UInt32 colour;

        // sets max values for RBG and Alpha
        public static byte red = 255;
        public static byte green = 255;
        public static byte blue = 255;
        public static byte alpha = 255;

        // empty constructor for Colour
        public Colour()
        {
            // left intentionally blank
        }

        // Colour construct to accept params for RBGA values and assigns them to their correct bit and combine to get HEXIDECIMAL
        public Colour(byte redV, byte greenV, byte blueV, byte alphaV)
        {           
            colour = (uint)(redV << 24 | greenV << 16 | blueV << 8 | alphaV);
        }

        // returns color after & bitmask and shifts to start
        public byte GetRed()
        {
            return (byte)((colour & 0xff000000) >> 24);           
        }
        
        // sets red color to red pos with shift
        public void SetRed(byte red)
        {           
            colour = colour & 0x00ffffff;
            colour |= (UInt32)red << 24;
        }

        // returns color after & bitmask and shifts to start
        public byte GetGreen()
        {
            return (byte)((colour & 0x00ff0000) >> 16);
        }
        // sets green color to green pos with shift
        public void SetGreen(byte green)
        {
            colour = colour & 0x00ffffff;
            colour |= (UInt32)green << 16;
        }

        // returns color after & bitmask and shifts to start
        public byte GetBlue()
        {

            return (byte)((colour & 0x0000ff00) >> 8);
        }
        // sets blue color to blue pos with shift
        public void SetBlue(byte blue)
        {
            colour = colour & 0x00ffffff;
            colour |= (UInt32)blue << 8;
        }

        // returns color after & bitmask and shifts to start
        public byte GetAlpha()
        {
            return (byte)(colour & 0x000000ff);
        }
        // sets alpha val to alpha
        public void SetAlpha(byte alpha)
        {
            colour = colour & 0x00ffffff;
            colour |= (UInt32)alpha;
        }

    }
}
