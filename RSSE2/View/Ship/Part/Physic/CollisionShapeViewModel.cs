using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSE2
{
    public abstract class CollisionShapeViewModel : ObservableObject
    {
        private CollisionShape _shape;
        public CollisionShape Shape { get { return _shape; } }

        public bool Autogen
        {
            get { return Shape.autogen; }
            set
            {
                Shape.autogen = value;
                OnPropertyChanged();
            }
        }

        public CollisionShapeViewModel(CollisionShape shape)
        {
            _shape = shape;
        }
    }
}
