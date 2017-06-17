using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RSSE2
{
    public class MeshViewModel : ObservableObject
    {
        private Mesh _mesh;
        public Mesh Mesh { get { return _mesh; } }

        public string Filename
        {
            get { return _mesh.filename; }
            set
            {
                _mesh.filename = value;
                OnPropertyChanged();
                OnPropertyChanged("Name");
            }
        }
        public string Name
        {
            get
            {
                string name = _mesh.filename.Split(new char[] { '\\', '/' }).Last();
                return name;
            }
        }

        public ICommand _editCommand;

        public MeshViewModel(Mesh mesh)
        {
            _mesh = mesh;
        }

        public void EditMesh()
        {

            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            // Set filter for file extension and default file extension 
            dlg.DefaultExt = ".mdl";
            dlg.Filter = "Mesh file (*.mdl)|*.mdl";


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
                        param => this.EditMesh(),
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
