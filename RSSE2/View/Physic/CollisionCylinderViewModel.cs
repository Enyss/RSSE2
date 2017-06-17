using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSE2
{
    class CollisionCylinderViewModel : CollisionShapeViewModel
    {


        private CollisionCylinder _cylinder;
        public CollisionCylinder Cylinder { get { return _cylinder; } }

        public double Radius
        {
            get { return _cylinder.r; }
            set
            {
                _cylinder.r = value;
                OnPropertyChanged();
            }
        }


        public double Height
        {
            get { return _cylinder.h; }
            set
            {
                _cylinder.h = value;
                OnPropertyChanged();
            }
        }

        public CollisionCylinderViewModel(CollisionCylinder cylinder)
        {
            _cylinder = cylinder;
        }

    }
}
