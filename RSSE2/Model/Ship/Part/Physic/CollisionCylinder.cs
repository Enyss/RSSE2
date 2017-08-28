using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSE2
{
    public class CollisionCylinder : CollisionShape
    {
        public double h;
        public double r;

        public override string Name { get { return "Cylinder"; } }

        public CollisionCylinder()
        {
            h = 1;
            r = 1;
        }

        public CollisionCylinder(Table table)
        {
            h = table["x"];
            r = table["y"];
        }

        public override CollisionShapeViewModel CreateViewModel()
        {
            return new CollisionCylinderViewModel(this);
        }

        public override void ToTable(Table table)
        {
            Vector3 shapeSize = new Vector3(h, r, 0);
            table.Add("CollShapeSize", shapeSize.ToTable());
            table.Add("CollisionShape", 6 + (autogen ? 0 : 100));
        }
    }
}
