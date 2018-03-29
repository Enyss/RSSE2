using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RSSE2
{
    public class PartViewModel : ObservableObject
    {
        private Part _part;
        public Part Part { get { return _part; } }

        public PartTreeNodeViewModel Node { get; }
        public bool selected;

        public string Name
        {
            get { return _part.name; }
            set
            {
                Part.name = value;
                OnPropertyChanged();
            }
        }

        public string Type
        {
            get { return Part.Type.GetValueByKey1(Part.type); }
            set
            {
                Part.type = Part.Type.GetValueByKey2(value);
                OnPropertyChanged();
            }
        }

        public List<string> TypeList
        {
            get { return Part.Type.Key2s.ToList(); }
        }

        private Vector3ViewModel position;
        public Vector3ViewModel Position
        {
            get { return position; }
            set
            {
                position = value;
                OnPropertyChanged();
            }
        }

        private Vector3ViewModel rotation;
        public Vector3ViewModel Rotation
        {
            get { return rotation; }
            set
            {
                rotation = value;
                OnPropertyChanged();
            }
        }

        public ObservableDictionnary<string, ComponentViewModel> Components { get; set; }

        public PartViewModel(Part part, PartTreeNodeViewModel node)
        {
            /* set the Properties */
            _part = part;
            Node = node;
            position = new Vector3ViewModel(_part.position);
            rotation = new Vector3ViewModel(_part.rotation);

            /* Setup the update the 3D view on position/rotation change */
            position.PropertyChanged += (sender, args) => { Backend.SceneManager.Instance.Paint(); };
            rotation.PropertyChanged += (sender, args) => { Backend.SceneManager.Instance.Paint(); };

            /* Create the ComponentViewModels */
            Components = new ObservableDictionnary<string, ComponentViewModel>();
            foreach (KeyValuePair<string,Component> pair in _part.components)
            {
                Components.Add(pair.Key, pair.Value.CreateViewModel());
            }

        }

        private ICommand _removeComponentCommand;
        #region RemoveComponentCommand 

        public ICommand RemoveComponentCommand
        {
            get
            {
                if (_removeComponentCommand == null)
                {
                    _removeComponentCommand = new RelayCommand(
                        param => this.RemoveComponent(param as ComponentViewModel),
                        param => this.CanRemoveComponent()
                    );
                }
                return _removeComponentCommand;
            }
        }

        public bool CanRemoveComponent()
        {
            return true;
        }

        public void RemoveComponent(ComponentViewModel component)
        {
            Components.Remove( component.Name );
            Part.components.Remove( component.Name );
        }

        #endregion

    }
}
