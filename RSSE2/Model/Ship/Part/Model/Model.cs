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
        public string subFunction;
        public double LODout;
        public bool shadowCast;
        public bool dynamicShadow;


        public override string Name { get { return "Model"; } }

        public static Model GenerateComponent(Table table)
        {
            if (table.ContainsKey("Material") || table.ContainsKey("Shader"))
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
                mesh = table["Model"] == "NONE" ? table["Name"] : table["Model"];
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
                string[] textures = new string[7];
                for (int i = 1; i < textures.Count(); i++)
                {
                    if (table["Texture"].ContainsKey("T" + i))
                    {
                        textures[i - 1] = table["Texture"]["T" + i];
                    }
                }

                material = MaterialManager.Instance.CreateMaterial(shader, textures);
            }

            subFunction = table.ContainsKey("SUBfunction") ? table["SUBfunction"] : "0";
            shadowCast = table.ContainsKey("ShadowCast") ? table["ShadowCast"] == 1 : false;
            dynamicShadow = table.ContainsKey("DynamicShadow") ? table["DynamicShadow"] == 1 : false;
            LODout = table["LODout"];
        }

        override public void ToTable(Table table)
        {
            table.Add("Model", mesh);
            table.Add("SUBfunction", subFunction);
            table.Add("LODout", LODout);
            table.Add("ShadowCast", shadowCast ? 1 : 0);
            table.Add("DynamicShadow", dynamicShadow ? 1 : 0);

            table.Add("Material", material.Name);
            //material.ToTable(table);
        }


        public override ComponentViewModel CreateViewModel()
        {
            return new ModelViewModel(this);
        }


    }
}
