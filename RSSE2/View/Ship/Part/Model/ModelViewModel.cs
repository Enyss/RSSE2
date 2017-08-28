using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RSSE2
{
    public class ModelViewModel : ComponentViewModel
    {
        public Model Model { get { return (Model)_component; } }

        #region Properties

        public string Mesh
        {
            get
            {
                return Model.mesh;
            }
            set
            {
                Model.mesh = value;
                RSSE2.Backend.SceneManager.Instance.Paint();
                OnPropertyChanged();
            }
        }

        public Material Material
        {
            get
            {
                return Model.material;
            }
            set
            {
                Model.material = value;
                RSSE2.Backend.SceneManager.Instance.Paint();
                OnPropertyChanged();
            }
        }

        public List<Material> MaterialList
        {
            get { return MaterialManager.Instance.MaterialList; }
        }

        #endregion

        #region Commands

        private ICommand _selectMeshCommand;
        public ICommand SelectMeshCommand
        {
            get
            {
                if (_selectMeshCommand == null)
                {
                    _selectMeshCommand = new RelayCommand(
                        param => this.SelectMesh(),
                        param => true
                    );
                }
                return _selectMeshCommand;
            }
        }

        private void SelectMesh()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Model Files (*.mdl)|*.mdl";
            openFileDialog.InitialDirectory = Application.Instance.CurrentlyLoaded.Folder;

            if (openFileDialog.ShowDialog() == true)
            {
                string s = openFileDialog.FileName.Substring(Application.Instance.CurrentlyLoaded.Folder.Length);
                s = s.Substring(0, s.Length - 4);
                Mesh = s;
            }
        }

        private ICommand _openMaterialEditorCommand;
        public ICommand OpenMaterialEditorCommand
        {
            get
            {
                if (_openMaterialEditorCommand == null)
                {
                    _openMaterialEditorCommand = new RelayCommand(
                        param => this.OpenMaterialEditor(),
                        param => true
                    );
                }
                return _openMaterialEditorCommand;
            }
        }

        private void OpenMaterialEditor()
        {
            MaterialEditorWindow materialEditor = new MaterialEditorWindow();
            materialEditor.DataContext = new MaterialEditorViewModel();
            materialEditor.Show();
        }


        #endregion


        public ModelViewModel(Model model)
        {
            _component = model;
        }
    }
}
