using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSE2
{
    public class MaterialManager
    {
        #region Singleton pattern

        private static readonly Lazy<MaterialManager> lazy = new Lazy<MaterialManager>(() => new MaterialManager());

        public static MaterialManager Instance { get { return lazy.Value; } }

        #endregion

        public Dictionary<string, Material> materials;

        public List<Material> MaterialList { get { return materials.Values.ToList(); } }

        private MaterialManager()
        {
            materials = new Dictionary<string, Material>();
        }

        public Material GetMaterial( string name )
        {
            if ( !materials.ContainsKey(name) )
            {
                materials.Add(name, new Material(name));
                materials[name].Name = name;
                if (File.Exists(Application.Instance.CurrentlyLoaded.Folder + name + ".mat"))
                {
                    materials[name].LoadFromFile(Application.Instance.CurrentlyLoaded.Folder + name + ".mat");
                }
                else if (File.Exists(Application.Instance.Settings.RSFolder + @"Mod\RogSysCM\Shared\Art\Materials\" + name + ".mat"))
                {
                    materials[name].LoadFromFile(Application.Instance.Settings.RSFolder + @"Mod\RogSysCM\Shared\Art\Materials\" + name + ".mat");
                }
            }
            return materials[name];

            
        }

        internal Material CreateMaterial(string shader, List<string> textures)
        {
            Material material;

            // Test if a similar material doesn't already exists
            foreach(KeyValuePair<string,Material> mat in materials)
            {
                if (mat.Value.Is(shader, textures))
                {
                    return mat.Value;
                }
            }

            // Create the material
            material = new Material("Material_" + materials.Count);

            material.shader = @"Shaders/rsGeneral/" + shader + ".shader";
            foreach( string tex in textures )
            {
                /* Temporary until the Symbology textures are better understood */
                if (tex.Contains("Symbology"))
                {
                    if (!File.Exists(Application.Instance.Settings.RSFolder + @"mod/rogsyscm/ships/" + Application.Instance.CurrentlyLoaded.Name + @"/" + tex + ".tex"))
                    {
                        File.Copy(Application.Instance.Settings.RSFolder + @"mod/rogsyscm/shared/art/maps/pink.tex",
                                  Application.Instance.Settings.RSFolder + @"mod/rogsyscm/ships/" + Application.Instance.CurrentlyLoaded.Name + @"/" + tex + ".tex");
                    }
                }
                /*   */

                if (File.Exists(Application.Instance.CurrentlyLoaded.Folder + tex + ".tex" ))
                {
                    material.textures.Add(@"mod/rogsyscm/ships/" + Application.Instance.CurrentlyLoaded.Name + @"/" + tex + ".tex");
                }
                else if (File.Exists(Application.Instance.Settings.RSFolder + @"mod/rogsyscm/shared/art/maps/" + tex + ".tex"))
                {
                    material.textures.Add(@"mod/rogsyscm/shared/art/maps/" + tex + ".tex");
                }
                else
                {
                    material.textures.Add(@"mod/rogsyscm/shared/art/maps/pink.tex");
                }
            }

            materials.Add(material.Name, material);

            return material;
        }

        internal void MaterialNameChanged(string name, string oldname)
        {
            Material mat = materials[oldname];
            materials.Remove(oldname);
            materials.Add(name, mat);
        }

    }
}
