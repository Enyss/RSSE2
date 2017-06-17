using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSE2
{
    public class CollisionConvexHullViewModel : CollisionShapeViewModel
    {
        private CollisionConvexHull _convexHull;
        public CollisionConvexHull ConvexHull { get { return _convexHull; } }

        public CollisionConvexHullViewModel( CollisionConvexHull convexHull )
        {
            _convexHull = convexHull;
        }
    }
}
