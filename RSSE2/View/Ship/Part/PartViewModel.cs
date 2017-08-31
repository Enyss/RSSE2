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

        public ObservableCollection<ComponentViewModel> Components { get; set; }

        public PartViewModel(Part part)
        {
            /* set the Properties */
            _part = part;
            position = new Vector3ViewModel(_part.position);
            rotation = new Vector3ViewModel(_part.rotation);

            /* Setup the update the 3D view on position/rotation change */
            position.PropertyChanged += (sender, args) => { Backend.SceneManager.Instance.Paint(); };
            rotation.PropertyChanged += (sender, args) => { Backend.SceneManager.Instance.Paint(); };

            /* Create the ComponentViewModels */
            Components = new ObservableCollection<ComponentViewModel>();
            foreach (Component component in _part.components.Values)
            {
                Components.Add(component.CreateViewModel());
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
            Components.Remove(component);

            // find the key
            string key = Part.components.FirstOrDefault(x => x.Value == component.Component).Key;
            // remove
            Part.components.Remove(key);
        }

        #endregion

    }
}
