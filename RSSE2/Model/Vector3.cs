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


        public static Vector3 operator +(Vector3 a, Vector3 b)
        {
            return new Vector3(a.x + b.x, a.y + b.y, a.z + b.z);
        }

        public static Vector3 operator -(Vector3 a, Vector3 b)
        {
            return new Vector3(a.x - b.x, a.y - b.y, a.z - b.z);
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

        public Table ToTable()
        {
            Table table = new Table();
            table.Add("x", x);
            table.Add("y", y);
            table.Add("z", z);
            return table;

        }
    }
}
