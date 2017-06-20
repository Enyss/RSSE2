using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RSSE2
{
    public class ShaderViewModel : ObservableObject
    {
        private Shader _shader;
        public Shader Shader { get { return _shader; } }

        public string Filename
        {
            get { return _shader.filename; }
            set
            {
                _shader.filename = value;
                OnPropertyChanged();
                OnPropertyChanged("Name");
            }
        }

        public string Name
        {
            get
            {
                string name = _shader.filename.Split(new char[] { '\\', '/' }).Last();
                return name;
            }
        }

        public ICommand _editCommand;

        public ShaderViewModel(Shader shader)
        {
            _shader = shader;
        }

        public void EditShader()
        {

            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            // Set filter for file extension and default file extension 
            dlg.DefaultExt = ".shader";
            dlg.Filter = "Shader file (*.shader)|*.shader";


            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();


            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Open document 
                string filename = dlg.FileName;
                Filename = filename;
            }
        }

        public ICommand EditCommand
        {
            get
            {
                if (_editCommand == null)
                {
                    _editCommand = new RelayCommand(
                        param => this.EditShader(),
                        param => this.CanEdit()
                    );
                }
                return _editCommand;
            }
        }

        private bool CanEdit()
        {
            // Verify command can be executed here
            return true;
        }
    }
}
