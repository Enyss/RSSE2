using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSE2
{
    public class CollisionSphere : CollisionShape
    {
        public double r;

        public CollisionSphere(double radius)
        {
            r = radius;
        }
    }
}
