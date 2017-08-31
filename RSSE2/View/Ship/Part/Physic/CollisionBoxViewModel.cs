using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSE2
{
    class CollisionBoxViewModel : CollisionShapeViewModel
    {

        #region Properties

        public double Length
        {
            get { return ((CollisionBox)Shape).l; }
            set
            {
                ((CollisionBox)Shape).l = value;
                OnPropertyChanged();
            }
        }

        public double Width
        {
            get { return ((CollisionBox)Shape).w; }
            set
            {
                ((CollisionBox)Shape).w = value;
                OnPropertyChanged();
            }
        }

        public double Height
        {
            get { return ((CollisionBox)Shape).h; }
            set
            {
                ((CollisionBox)Shape).h = value;
                OnPropertyChanged();
            }
        }

        #endregion

        public CollisionBoxViewModel(CollisionBox box) : base(box) { }
    }
}
