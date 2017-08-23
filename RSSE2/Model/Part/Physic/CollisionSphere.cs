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
        public override string Name { get { return "Sphere"; } }

        public CollisionSphere()
        {
            r = 1.0;
        }

        public CollisionSphere( Table table )
        {
            r = table["x"];
        }

        public CollisionSphere(double radius)
        {
            r = radius;
        }

        public override CollisionShapeViewModel CreateViewModel()
        {
            return new CollisionSphereViewModel(this);
        }
    }
}
