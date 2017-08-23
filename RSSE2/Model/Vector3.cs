using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSE2
{
    public class Vector3
    {
        public double x;
        public double y;
        public double z;

        public Vector3()
        {

        }

        public Vector3(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        internal float[] ToArray()
        {
            return new float[3]{ (float)x, (float)y, (float)z };
        }

        public Vector3(Table table)
        {
            x = table["x"];
            y = table["y"];
            z = table["z"];
        }
    }
}
