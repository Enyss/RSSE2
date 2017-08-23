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
            if (table.ContainsKey("Model"))
            {
                mesh = new Mesh(table["Model"]);
            }
            else
            {
                mesh = new Mesh(table["Name"]);
            }

            if (table.ContainsKey("Material"))
            {
                texture = new List<Texture>();
                shader = new Shader();
            }
            else
            {
                texture = new List<Texture>();
                shader = new Shader(table["Shader"]);
                foreach (KeyValuePair<string, dynamic> e in table["Texture"])
                {
                    texture.Add(new Texture(e.Value));
                }
            }
        }

        override public void ToTable(Table table)
        {
            table["Name"] = "NYI";
            table["Shader"] = "NYI";
            table["Textures"] = texture.Count;
            /*table["Texture"] = new Table();
            for(int i=0; i<texture.Count; i++)
            {
                table["Texture"]["T"+(i+1)] = "NYI";
            }*/
        }

        public override ComponentViewModel CreateViewModel()
        {
            return new ModelViewModel(this);
        }


    }
}
