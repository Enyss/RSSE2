using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSE2
{
    public class Physic : Component
    {

        public bool collision;
        public CollisionShape shape;
        public double mass;
        public double friction;

        public Physic()
        {
            shape = null;
        }

        public Physic(Table table)
        {
            collision = table["useCollision"] > 0.5;

            if (collision)
            {
                int s = (int)table["CollisionShape"];
                /* --1=Dynamic Convex Decomp Mesh, 2 = Convex Hull, 3=Static Mesh, 4=Box, 5=Cone, 6=Cylinder, 7=Sphere, +100-do not autogen collision */
                switch (s % 100)
                {
                    case 1:
                        shape = new CollisionDynamicMesh();
                        break;
                    case 2:
                        shape = new CollisionConvexHull();
                        break;
                    case 3:
                        shape = new CollisionMesh();
                        break;
                    case 4:
                        shape = new CollisionBox(table["CollShapeSize"]);
                        break;
                    case 5:
                        shape = new CollisionCone(table["CollShapeSize"]);
                        break;
                    case 6:
                        shape = new CollisionCylinder(table["CollShapeSize"]);
                        break;
                    case 7:
                        shape = new CollisionSphere(table["CollShapeSize"]);
                        break;
                }
                shape.autogen = s < 100;
            }
            else
            {
                shape = new CollisionBox();
                shape.autogen = false;
            }

            mass = table["Mass"];
            friction = table["Friction"];
        }

        internal static Physic GenerateComponent(Table table)
        {
            if ( table.ContainsKey("Mass") )
            {
                return new Physic(table);
            }
            return null;
        }

        public override void ToTable(Table table)
        {
            shape.ToTable(table);
            table.Add("useCollision", collision ? 1 : 0);
            table.Add("Mass", mass);
            table.Add("Friction", friction);
        }

        public override ComponentViewModel CreateViewModel()
        {
            return new PhysicViewModel(this);
        }


    }
}
