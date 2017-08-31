using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSE2
{
    public abstract class CollisionShape
    {
        public bool autogen;
        public abstract string Name { get; }

        private static ObservableCollection<string> shapeType = new ObservableCollection<string> {
            "Box",
            "Cone",
            "Convex Hull",
            "Cylinder",
            "Dynamic Convex Decomp Mesh",
            "Static Mesh",
            "Sphere" };
        public static ObservableCollection<string> ShapeType { get { return shapeType; } }

        public abstract CollisionShapeViewModel CreateViewModel();
        public abstract void ToTable( Table table );
    }
}
