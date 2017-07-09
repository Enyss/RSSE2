using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSE2
{
    public class Color
    {
        int r;
        int g;
        int b;

        public Color( Table table)
        {
            r = (int)(table["r"]*255);
            g = (int)(table["g"]*255);
            b = (int)(table["b"]*255);
        }

        public Color(string RGBhex)
        {
            r = (RGBhex[0] - 48) * 16 + RGBhex[1] - 48;
            g = (RGBhex[2] - 48) * 16 + RGBhex[3] - 48;
            b = (RGBhex[4] - 48) * 16 + RGBhex[5] - 48;
        }

        public string ToRGBhex()
        {
            return ((int)r).ToString("X2") + ((int)g).ToString("X2") + ((int)b).ToString("X2");
        }

        public Color(int r, int g, int b)
        {
            this.r = r;
            this.g = g;
            this.b = b;
        }
    }
}
