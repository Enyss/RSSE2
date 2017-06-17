using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSE2
{
    class CollisionMeshViewModel: CollisionShapeViewModel
    {

        private CollisionMesh _mesh;
        public CollisionMesh Mesh { get { return _mesh; } }

        public CollisionMeshViewModel(CollisionMesh mesh)
        {
            _mesh = mesh;
        }

    }
}
