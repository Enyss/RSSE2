using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSE2
{
    class CollisionConeViewModel : CollisionShapeViewModel
    {
        private CollisionCone _cone;
        public CollisionCone Cone { get { return _cone; } }

        #region Properties

        public double Radius
        {
            get { return _cone.r; }
            set
            {
                _cone.r = value;
                OnPropertyChanged();
            }
        }

        public double Height
        {
            get { return _cone.h; }
            set
            {
                _cone.h = value;
                OnPropertyChanged();
            }
        }

        #endregion

        public CollisionConeViewModel(CollisionCone cone)
        {
            _cone = cone;
        }

    }
}
