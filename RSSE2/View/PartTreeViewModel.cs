using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RSSE2
{
    public class PartTreeViewModel : DependencyObject
    {
        public ObservableCollection<PartTreeNodeViewModel> Parts { set; get; }

        public PartTreeViewModel()
        {
            Parts = new ObservableCollection<PartTreeNodeViewModel>();
        }

    }
}
