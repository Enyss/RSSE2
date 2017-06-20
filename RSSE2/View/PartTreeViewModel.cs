using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSE2
{
    public class PartTreeViewModel
    {
        private Part _part;
        public Part Part { get { return _part; } }

        public PartTreeViewModel Parent { get; set; }
        public PartViewModel Current { get; set; }
        public ObservableCollection<PartTreeViewModel> Children { get; set; }

        public string Name { get { return _part.name; } }
        
        public PartTreeViewModel(Part part, PartTreeViewModel parent)
        {
            _part = part;
            Parent = parent;

            Current = new PartViewModel(_part);

            Children = new ObservableCollection<PartTreeViewModel>();
            foreach (Part child in _part.children)
            {
                Children.Add(new PartTreeViewModel(child, this));
            }

        }
    }
}
