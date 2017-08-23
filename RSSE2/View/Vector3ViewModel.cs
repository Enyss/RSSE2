using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSE2
{
    public class Vector3ViewModel : ObservableObject
    {
        private Vector3 _vector3;
        public Vector3 Vector3 { get { return _vector3; } }

        public double X
        {
            get { return _vector3.x; }
            set
            {
                _vector3.x = value;
                OnPropertyChanged();
            }
        }

        public double Y
        {
            get { return _vector3.y; }
            set
            {
                _vector3.y = value;
                OnPropertyChanged();
            }
        }

        public double Z
        {
            get { return _vector3.z; }
            set
            {
                _vector3.z = value;
                OnPropertyChanged();
            }
        }

        public Vector3ViewModel(Vector3 vector3)
        {
            _vector3 = vector3;
        }
    }
}
