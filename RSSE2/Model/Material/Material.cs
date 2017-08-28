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
        public List<string> textures;

        public Material(string name)
        {
            this.name = name;
            diffuse = new ColorRGBA();
            specular = new ColorRGBA();
            shader = "";
            textures = new List<string>();
        }

        public void LoadFromFile(string filename)
        {
            List<string> lines = new List<string>(File.ReadAllLines(filename));

            foreach(string line in lines)
            {
                string[] s = line.Split('=');

                if (s[0].StartsWith("texture"))
                {
                    textures.Add(s[1].Substring(1, s[1].Length - 2));
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

        internal bool Is(string shader, List<string> textures)
        {
            if ( ExtractName(this.shader, ".shader") != shader )
                return false;
    
            if (this.textures.Count != textures.Count)
                return false;

            for (int i = 0; i < textures.Count; i++)
            {
                if (ExtractName(this.textures[i], ".tex") != textures[i])
                    return false;
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
