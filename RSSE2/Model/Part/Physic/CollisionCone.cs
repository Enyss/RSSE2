﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSE2
{
    public class CollisionCone : CollisionShape
    {
        public double h;
        public double r;
        public override string Name { get { return "Cone"; } }

        public CollisionCone()
        {
            r = 1.0;
            h = 1.0;
        }

        public CollisionCone(double radius, double height)
        {
            r = radius;
            h = height;
        }

        public CollisionCone(Table table)
        {
            h = table["x"];
            r = table["y"];
        }

        public override CollisionShapeViewModel CreateViewModel()
        {
            return new CollisionConeViewModel(this);
        }
    }
}
