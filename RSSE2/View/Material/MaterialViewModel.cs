using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSE2
{
    public class MaterialViewModel : ObservableObject
    {
        private Material _material;
        public Material Material { get { return _material; } }

        public ObservableCollection<Tuple<int, string>> Textures { get; set; }

        public string Name
        {
            get { return Material.Name; }
            set
            {
                Material.Name = value;
                OnPropertyChanged();
            }
        }

        public string Shader
        {
            get { return Material.shader; }
            set
            {
                Material.shader = value;
                OnPropertyChanged();
            }
        }

        public MaterialViewModel(Material material)
        {
            _material = material;
            Textures = new ObservableCollection<Tuple<int,string>>();
            for ( int i = 0; i < material.textures.Count; i++)
            {
                Textures.Add(new Tuple<int, string>(i, material.textures[i]) );
            }
        }

        public void AddTexture(string texture)
        {
            //textures.Add(texture);
            Material.textures.Add(texture);
        }

        public void RemoveTexture(string texture)
        {
            //textures.Remove(texture);
            Material.textures.Remove(texture);
        }

        public void EditTexture(int index, string newTexture)
        {
            //textures[index] = newTexture;
            Material.textures[index] = newTexture;
        }


    }
}
