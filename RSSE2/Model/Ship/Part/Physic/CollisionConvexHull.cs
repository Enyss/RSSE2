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

        public override void ToTable(Table table)
        {
            Vector3 shapeSize = new Vector3(0, 0, 0);
            table.Add("CollShapeSize", shapeSize.ToTable());
            table.Add("CollisionShape", 2 + (autogen ? 0 : 100));
        }
    }
}
