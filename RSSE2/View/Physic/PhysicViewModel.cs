using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSE2
{
    public class PhysicViewModel : ComponentViewModel
    {
        private Physic _physic;
        public Physic Physic { get { return _physic; } }

        private CollisionShapeViewModel collisionShape;
        public CollisionShapeViewModel CollisionShape
        {
            get { return collisionShape;  }
            set
            {
                collisionShape = value;
                OnPropertyChanged();
            }
        }

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

        public ObservableCollection<string> ShapeList
        {
            get { return RSSE2.CollisionShape.ShapeType; }
        }
        
        public string ShapeType
        {
            get { return _physic.shape.Name; }
            set
            {
                if (value != _physic.shape.Name)
                {

                    /* Use an item factory? */
                    switch(value)
                    {
                        case "Box":
                            Shape = new CollisionBox();
                            break;
                        case "Cone":
                            Shape = new CollisionCone();
                            break;
                        case "Convex Hull":
                            Shape = new CollisionConvexHull();
                            break;
                        case "Cylinder":
                            Shape = new CollisionCylinder();
                            break; 
                        case "Dynamic Convex Decomp Mesh":
                            Shape = new CollisionDynamicMesh();
                            break;
                        case "Static Mesh":
                            Shape = new CollisionMesh();
                            break;
                        case "Sphere":
                            Shape = new CollisionSphere();
                            break;
                    }
                    CollisionShape = Shape.CreateViewModel();
                    OnPropertyChanged();
                }
            }
        }

        public PhysicViewModel( Physic physic)
        {
            _physic = physic;
            if (Shape != null)
            {
                CollisionShape = Shape.CreateViewModel();
            }
        }
    }
}
