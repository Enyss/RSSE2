using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSE2
{
    public class Model : Mod
    {
        public List<Texture> texture;
        public Shader shader;
        public Mesh mesh;

        public Model()
        {
            texture = new List<Texture>();
            shader = new Shader();
            mesh = new Mesh();
        }

        public override ModViewModel CreateViewModel()
        {
            return new ModelViewModel(this);
        }


    }
}
