using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSE2
{
    public class Model : Component
    {
        public Material material;
        public string mesh;

        public static Model GenerateComponent(Table table)
        {
            if (table.ContainsKey("Material") || table.ContainsKey("Shader") )
            {
                return new Model(table);
            }
            return null;
        }

        public Model()
        {
        }

        public Model(Table table)
        {
            if (table.ContainsKey("Model"))
            {
                mesh = table["Model"]=="NONE"? table["Name"] : table["Model"];
            }
            else
            {
                mesh = table["Name"];
            }

            if (table.ContainsKey("Material"))
            {
                material = MaterialManager.Instance.GetMaterial(table["Material"]);

            }
            else
            {
                string shader = table["Shader"];
                List<string> textures = new List<string>();
                foreach (KeyValuePair<string, dynamic> e in table["Texture"])
                {
                    textures.Add(e.Value);
                }

                if (textures.Count == 0)
                {

                }

                material = MaterialManager.Instance.CreateMaterial(shader, textures);
            }
        }

        override public void ToTable(Table table)
        {
        }

        public override ComponentViewModel CreateViewModel()
        {
            return new ModelViewModel(this);
        }


    }
}
