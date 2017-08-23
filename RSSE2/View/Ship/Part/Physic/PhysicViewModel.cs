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
        public Physic Physic { get { return (Physic)_component; } }

        #region Properties

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
            get { return Physic.collision; }
            set
            {
                Physic.collision = value;
                OnPropertyChanged();
            }
        }

        public double Mass
        {
            get { return Physic.mass; }
            set
            {
                Physic.mass = value;
                OnPropertyChanged();
            }
        }

        public double Friction
        {
            get { return Physic.friction; }
            set
            {
                Physic.friction = value;
                OnPropertyChanged();
            }
        }

        public CollisionShape Shape
        {
            get { return Physic.shape; }
            set
            {
                Physic.shape = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<string> ShapeList
        {
            get { return RSSE2.CollisionShape.ShapeType; }
        }
        
        public string ShapeType
        {
            get { return Physic.shape.Name; }
            set
            {
                if (value != Physic.shape.Name)
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

        #endregion

        public PhysicViewModel( Physic physic)
        {
            _component = physic;
            if (Shape != null)
            {
                CollisionShape = Shape.CreateViewModel();
            }
        }
    }
}
