using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSE2
{
    public class Model : Component
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

        public Model(Table table)
        {

            mesh = new Mesh(table["Name"] + ".mdl");
            if (table.ContainsKey("Material"))
            {
                texture = new List<Texture>();
                shader = new Shader();
            }
            else
            {
                texture = new List<Texture>();
                shader = new Shader(table["Shader"] + ".shader");
                foreach (KeyValuePair<string, dynamic> e in table["Texture"])
                {
                    texture.Add(new Texture(e.Value + ".tex"));
                }
            }
        }

        override public void ToTable(Table table)
        {
            table["Name"] = "NYI";
            table["Shader"] = "NYI";
            table["Textures"] = texture.Count;
            table["Texture"] = new Table();
            for(int i=0; i<texture.Count; i++)
            {
                table["Texture"]["T"+(i+1)] = "NYI";
            }
        }

        public override ComponentViewModel CreateViewModel()
        {
            return new ModelViewModel(this);
        }


    }
}
