using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSE2
{
    class CollisionDynamicMeshViewModel : CollisionShapeViewModel
    {

        private CollisionDynamicMesh _dynamicMesh;
        public CollisionDynamicMesh DynamicMesh { get { return _dynamicMesh; } }

        public CollisionDynamicMeshViewModel(CollisionDynamicMesh dynamicMesh)
        {
            _dynamicMesh = dynamicMesh;
        }
    }
}