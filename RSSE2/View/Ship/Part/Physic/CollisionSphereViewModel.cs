using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSE2
{
    class CollisionSphereViewModel : CollisionShapeViewModel
    {

        #region Properties

        public double Radius
        {
            get { return ((CollisionSphere)Shape).r; }
            set
            {
                ((CollisionSphere)Shape).r = value;
                OnPropertyChanged();
            }
        }

        #endregion

        public CollisionSphereViewModel(CollisionSphere sphere) : base(sphere) { }

    }
}
