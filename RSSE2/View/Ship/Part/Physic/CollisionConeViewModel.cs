using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSE2
{
    class CollisionConeViewModel : CollisionShapeViewModel
    {

        #region Properties

        public double Radius
        {
            get { return ((CollisionCone)Shape).r; }
            set
            {
                ((CollisionCone)Shape).r = value;
                OnPropertyChanged();
            }
        }

        public double Height
        {
            get { return ((CollisionCone)Shape).h; }
            set
            {
                ((CollisionCone)Shape).h = value;
                OnPropertyChanged();
            }
        }

        #endregion

        public CollisionConeViewModel(CollisionCone cone) : base(cone) { }
    }
}
