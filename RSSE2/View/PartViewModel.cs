using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public ObservableCollection<ComponentViewModel> Components { get; set; }

        public PartViewModel( Part part )
        {
            _part = part;
            Components = new ObservableCollection<ComponentViewModel>();
            foreach ( Component component in _part.components )
            {
                Components.Add(component.CreateViewModel());
            }
        }
    }
}
