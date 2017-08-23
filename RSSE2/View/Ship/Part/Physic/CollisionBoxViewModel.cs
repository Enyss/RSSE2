using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSE2
{
    class CollisionBoxViewModel : CollisionShapeViewModel
    {
        private CollisionBox _box;
        public CollisionBox Box { get { return _box; } }

        #region Properties

        public double Length
        {
            get { return _box.l; }
            set
            {
                _box.l = value;
                OnPropertyChanged();
            }
        }

        public double Width
        {
            get { return _box.w; }
            set
            {
                _box.w = value;
                OnPropertyChanged();
            }
        }

        public double Height
        {
            get { return _box.h; }
            set
            {
                _box.h = value;
                OnPropertyChanged();
            }
        }

        #endregion

        public CollisionBoxViewModel( CollisionBox box )
        {
            _box = box;
        }

    }
}
