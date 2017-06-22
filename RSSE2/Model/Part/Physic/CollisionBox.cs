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

        public override CollisionShapeViewModel CreateViewModel()
        {
            return new CollisionBoxViewModel(this);
        }
    }
}
