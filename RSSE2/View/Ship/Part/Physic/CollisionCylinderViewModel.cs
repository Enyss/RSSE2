using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSE2
{
    public class CollisionCylinderViewModel : CollisionShapeViewModel
    {
        public CollisionCylinderViewModel(CollisionShape shape) : base(shape)
        {
        }
        #region Properties

        public double Radius
        {
            get { return ((CollisionCylinder)Shape).r; }
            set
            {
                ((CollisionCylinder)Shape).r = value;
                OnPropertyChanged();
            }
        }


        public double Height
        {
            get { return ((CollisionCylinder)Shape).h; }
            set
            {
                ((CollisionCylinder)Shape).h = value;
                OnPropertyChanged();
            }
        }

        #endregion
    }
}
