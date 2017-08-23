using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSE2
{
    public class ModelViewModel : ComponentViewModel
    {
        public Model Model { get { return (Model)_component; } }

        #region Properties

        public TexturesViewModel Textures { get; set; }
        public ShaderViewModel Shader { get; set; }
        public MeshViewModel Mesh { get; set; }

        #endregion

        public ModelViewModel(Model model)
        {
            _component = model;
            Textures = new TexturesViewModel(model.texture);
            Shader = new ShaderViewModel(model.shader);
            Mesh = new MeshViewModel(model.mesh);
        }
    }
}
