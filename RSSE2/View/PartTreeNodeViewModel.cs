using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSE2
{
    public class PartTreeNodeViewModel
    {
        private Part _part;
        public Part Part { get { return _part; } }

        public PartTreeNodeViewModel Parent { get; set; }
        public PartViewModel Current { get; set; }
        public ObservableCollection<PartTreeNodeViewModel> Children { get; set; }

        public string Name { get { return _part.name; } }
        
        public PartTreeNodeViewModel(Part part, PartTreeNodeViewModel parent)
        {
            _part = part;
            Parent = parent;

            Current = new PartViewModel(_part);

            Children = new ObservableCollection<PartTreeNodeViewModel>();
            foreach (Part child in _part.children)
            {
                Children.Add(new PartTreeNodeViewModel(child, this));
            }

        }
    }
}
