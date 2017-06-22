using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSE2
{
    public class CollisionMesh : CollisionShape
    {

        public override string Name { get { return "Static Mesh"; } }

        public override CollisionShapeViewModel CreateViewModel()
        {
            return new CollisionMeshViewModel(this);
        }
    }
}
