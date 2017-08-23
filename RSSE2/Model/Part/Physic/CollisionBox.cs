using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSE2
{ 
    public class CollisionBox : CollisionShape
    {
        public double l;
        public double h;
        public double w;

        public override string Name { get { return "Box"; } }

        public CollisionBox(Table table)
        {
            l = table["x"];
            h = table["y"];
            w = table["z"];
        }

        public CollisionBox()
        {
            l = 1;
            h = 1;
            w = 1;
        }

        public override CollisionShapeViewModel CreateViewModel()
        {
            return new CollisionBoxViewModel(this);
        }
    }
}
