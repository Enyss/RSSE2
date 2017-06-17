using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace RSSE2
{
    public class TexturesViewModel
    {
        private List<Texture> _textures;

        private ICommand _addCommand;
        private ICommand _deleteCommand;
        private ICommand _editCommand;
        private ICommand _upCommand;
        private ICommand _downCommand;


        public ObservableCollection<TextureViewModel> Textures { get; }

        public TexturesViewModel(List<Texture> textures)
        {
            _textures = textures;
            Textures = new ObservableCollection<TextureViewModel>();
            foreach (Texture tex in _textures)
            {
                Textures.Add(new TextureViewModel(tex));
            }
        }

        #region AddCommand

        public void AddTexture()
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            // Set filter for file extension and default file extension 
            dlg.DefaultExt = ".tex";
            dlg.Filter = "Texture file (*.tex)|*.tex";


            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();


            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Open document 
                string filename = dlg.FileName;
                Texture tex = new Texture(filename);
                _textures.Add(tex);
                Textures.Add(new TextureViewModel(tex));
            }
        }

        public ICommand AddCommand
        {
            get
            {
                if (_addCommand == null)
                {
                    _addCommand = new RelayCommand(
                        param => this.AddTexture(),
                        param => this.CanAdd()
                    );
                }
                return _addCommand;
            }
        }

        private bool CanAdd()
        {
            // Verify command can be executed here
            return true;
        }

        #endregion

        #region DeleteCommand

        public void DeleteTexture(TextureViewModel tex)
        {
            _textures.Remove(tex.Texture);
            Textures.Remove(tex);
        }

        public ICommand DeleteCommand
        {
            get
            {
                if (_deleteCommand == null)
                {
                    _deleteCommand = new RelayCommand(
                        param => this.DeleteTexture(param as TextureViewModel),
                        param => this.CanDelete(param)
                    );
                }
                return _deleteCommand;
            }
        }

        private bool CanDelete(object selection)
        {
            // Verify command can be executed here
            return (selection == null) ? false : true;
        }

        #endregion

        #region EditCommand

        public void EditTexture(TextureViewModel tex)
        {

            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            // Set filter for file extension and default file extension 
            dlg.DefaultExt = ".tex";
            dlg.Filter = "Texture file (*.tex)|*.tex";


            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();


            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Open document 
                string filename = dlg.FileName;
                tex.Filename = filename;
            }
        }

        public ICommand EditCommand
        {
            get
            {
                if (_editCommand == null)
                {
                    _editCommand = new RelayCommand(
                        param => this.EditTexture(param as TextureViewModel),
                        param => this.CanEdit(param)
                    );
                }
                return _editCommand;
            }
        }

        private bool CanEdit(object selection)
        {
            // Verify command can be executed here
            return (selection == null) ? false : true;
        }

        #endregion

        #region UpCommand

        public void UpTexture(int selected)
        {
            TextureViewModel tmp = Textures[selected];
            Texture _tmp = _textures[selected];
            Textures[selected] = Textures[selected - 1];
            _textures[selected] = _textures[selected - 1];
            Textures[selected - 1] = tmp;
            _textures[selected - 1] = _tmp;
        }


        public ICommand UpCommand
        {
            get
            {
                if (_upCommand == null)
                {
                _upCommand = new RelayCommand(
                        param => this.UpTexture((int)param),
                        param => this.CanUp((int)param)
                    );
                }
                return _upCommand;
            }
        }

        private bool CanUp(int index)
        {
            return index>0;
        }


        #endregion

        #region DownCommand

        public void DownTexture(int selected)
        {
            TextureViewModel tmp = Textures[selected+1];
            Texture _tmp = _textures[selected+1];
            Textures[selected+1] = Textures[selected];
            _textures[selected+1] = _textures[selected];
            Textures[selected] = tmp;
            _textures[selected] = _tmp;
        }


        public ICommand DownCommand
        {
            get
            {
                if (_downCommand == null)
                {
                    _downCommand = new RelayCommand(
                            param => this.DownTexture((int)param),
                            param => this.CanDown((int)param)
                        );
                }
                return _downCommand;
            }
        }

        private bool CanDown(int index)
        {
            return (index >= 0 && index < Textures.Count-1);
        }

#endregion
    }
}
