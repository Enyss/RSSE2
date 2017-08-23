using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSE2
{
    public class ColorRGBA
    {
        public int r;
        public int g;
        public int b;
        public int a;

        public ColorRGBA()
        {
            this.r = 0;
            this.g = 0;
            this.b = 0;
            this.a = 255;
        }

        // integer values between 0 and 255
        public ColorRGBA( int r, int g, int b, int a)
        {
            this.r = r;
            this.g = g;
            this.b = b;
            this.a = a;
        }

        // double values between 0.0 and 1.0
        public ColorRGBA(double r, double g, double b, double a)
        {
            this.r = (int)(r * 255);
            this.g = (int)(g * 255);
            this.b = (int)(b * 255);
            this.a = (int)(a * 255);
        }

        // number of the color, in hex. rrggbbaa
        public ColorRGBA(string RGBA)
        {
            r = (RGBA[0] - 48) * 16 + RGBA[1] - 48;
            g = (RGBA[2] - 48) * 16 + RGBA[3] - 48;
            b = (RGBA[4] - 48) * 16 + RGBA[5] - 48;
            a = (RGBA[6] - 48) * 16 + RGBA[7] - 48;
        }
    }
}
