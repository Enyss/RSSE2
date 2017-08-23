using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSE2
{
    class Material
    {
        string filename;

        int blendmode;
        int castshadows;
        int zsort;
        int cullbackfaces;
        int depthtest;
        int pickmode;
        int depthmask;
        ColorRGBA diffuse;
        ColorRGBA specular;
        int alwaysuseshader;
        double roughness;
        Vector3 mappingscale;
        int drawmode;

        string shader;
        List<string> textures;

        public Material()
        {
            diffuse = new ColorRGBA();
            specular = new ColorRGBA();
            textures = new List<string>();
        }
    }
}
