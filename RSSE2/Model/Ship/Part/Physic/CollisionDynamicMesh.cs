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

        public override void ToTable(Table table)
        {
            Vector3 shapeSize = new Vector3(0, 0, 0);
            table.Add("CollShapeSize", shapeSize.ToTable());
            table.Add("CollisionShape", 1 + (autogen ? 0 : 100));
        }
    }
}
