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

        public override void ToTable(Table table)
        {
            Vector3 shapeSize = new Vector3(0, 0, 0);
            table.Add("CollShapeSize", shapeSize.ToTable());
            table.Add("CollisionShape", 3 + (autogen ? 0 : 100));
        }
    }
}
