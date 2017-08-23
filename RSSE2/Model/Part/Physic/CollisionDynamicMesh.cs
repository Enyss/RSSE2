using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSE2
{
    public class CollisionDynamicMesh : CollisionShape
    {

        public override string Name { get { return "Dynamic Convex Decomp Mesh"; } }

        public CollisionDynamicMesh()
        {
        }

        public override CollisionShapeViewModel CreateViewModel()
        {
            return new CollisionDynamicMeshViewModel(this);
        }
    }
}
