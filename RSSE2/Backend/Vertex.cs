using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL4;

namespace RSSE2.Backend
{
    struct Vertex
    {
        public const int Size = (3 + 4) * 4; // size of struct in bytes

        private readonly float[] position;

        public Vertex(Vector3 position)
        {
            this.position = position.ToArray();
        }
    }
}
