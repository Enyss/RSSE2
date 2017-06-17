using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSE2
{
    public class ModelViewModel : ModViewModel
    {
        private Model _model;
        public Model Model { get { return _model; } }

        public TexturesViewModel Textures { get; set; }
        public ShaderViewModel Shader { get; set; }
        public MeshViewModel Mesh { get; set; }

        public ModelViewModel(Model model)
        {
            _model = model;
            Textures = new TexturesViewModel(model.texture);
            Shader = new ShaderViewModel(model.shader);
            Mesh = new MeshViewModel(model.mesh);
        }
    }
}
