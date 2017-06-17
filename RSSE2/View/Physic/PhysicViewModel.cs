using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSE2
{
    public class PhysicViewModel : ModViewModel
    {
        private Physic _physic;
        public Physic Physic { get { return _physic; } }

        public bool Collision
        {
            get { return _physic.collision; }
            set
            {
                _physic.collision = value;
                OnPropertyChanged();
            }
        }

        public double Mass
        {
            get { return _physic.mass; }
            set
            {
                _physic.mass = value;
                OnPropertyChanged();
            }
        }

        public double Friction
        {
            get { return _physic.friction; }
            set
            {
                _physic.friction = value;
                OnPropertyChanged();
            }
        }

        public CollisionShape Shape
        {
            get { return _physic.shape; }
            set
            {
                _physic.shape = value;
                OnPropertyChanged();
            }
        }

        public PhysicViewModel( Physic physic)
        {
            _physic = physic;
        }
    }
}
