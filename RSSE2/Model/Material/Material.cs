using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSE2
{
    public class Material
    {
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                string oldname = name;
                name = value;
                MaterialManager.Instance.MaterialNameChanged(name, oldname);
            }
        }

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

        public string shader;
        public string[] textures;

        public Material(string name)
        {
            this.name = name;
            diffuse = new ColorRGBA();
            specular = new ColorRGBA();
            shader = "";
            textures = new string[7];
        }

        public void LoadFromFile(string filename)
        {
            List<string> lines = new List<string>(File.ReadAllLines(filename));

            foreach(string line in lines)
            {
                string[] s = line.Split('=');

                if (s[0].StartsWith("texture"))
                {
                    int index;
                    if (Int32.TryParse(s[0].Substring(7), out index))
                    {
                        textures[index] = s[1].Substring(1, s[1].Length - 2);
                    }
                }
                else
                {
                    switch (s[0])
                    {
                        case "shader":
                            shader = s[1].Substring(1, s[1].Length - 2);
                            break;
                        case "blendmode":
                        case "castshadows":
                        case "zsort":
                        case "cullbackfaces":
                        case "depthtest":
                        case "pickmode":
                        case "depthmask":
                        case "diffuse":
                        case "specular":
                        case "alwaysuseshader":
                        case "roughness":
                        case "mappingscale":
                        case "drawmode":
                            break;
                    }
                }
            }
        }

        internal bool Is(string shader, string[] textures)
        {
            if ( ExtractName(this.shader, ".shader") != shader )
                return false;

            for (int i=0; i < textures.Length; i++)
            {
                if (this.textures[i] != null)
                {
                    if (textures[i] != ExtractName(this.textures[i], ".tex"))
                        return false;
                }
                else if (textures[i] != null)
                {
                    return false;
                }
            }
            return true;
        }

        private string ExtractName(string filename, string extension)
        {
            string name;
            if (filename.EndsWith(extension))
            {
                name = filename.Split('\\', '/').Last();
                name = name.Substring(0, name.Length - extension.Length);

            }
            else
            {
                name = filename;
            }
            return name;
        }
    }
}
