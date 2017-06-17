using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSE2
{
    public class CollisionConvexHull : CollisionShape
    {

        public override string Name { get { return "Convex Hull"; } }


        public override CollisionShapeViewModel CreateViewModel()
        {
            return new CollisionConvexHullViewModel(this);
        }
    }
}
