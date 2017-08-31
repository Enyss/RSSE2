using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RSSE2
{
    public class MaterialViewModel : ObservableObject
    {
        private Material _material;
        public Material Material { get { return _material; } }

        public ObservableDictionnary<int,string> Textures { get; set; }

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

        #region Commands

        private ICommand _setTextureCommand;
        public ICommand SetTextureCommand
        {
            get
            {
                if (_setTextureCommand == null)
                {
                    _setTextureCommand = new RelayCommand(
                        param => this.SetTexture((int)param),
                        param => true
                    );
                }
                return _setTextureCommand;
            }
        }

        private void SetTexture(int textureIndex)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Texture Files (*.tex)|*.tex";
            openFileDialog.InitialDirectory = Application.Instance.CurrentlyLoaded.Folder;

            if (openFileDialog.ShowDialog() == true)
            {
                string s = openFileDialog.FileName;
                if (s.StartsWith(Application.Instance.Settings.RSFolder))
                {
                    string texture = s.Substring(Application.Instance.Settings.RSFolder.Length);
                    Textures[textureIndex] = texture;
                    Material.textures[textureIndex] = texture;
                }

            }
        }

        #endregion

        public MaterialViewModel(Material material)
        {
            _material = material;
            Textures = new ObservableDictionnary<int, string>();
            for ( int i = 0; i < material.textures.Count(); i++)
            {
                Textures.Add( i, material.textures[i] );
            }
        }
    }
}
