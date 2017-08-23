using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RSSE2
{
    public class ComponentViewModel : ObservableObject
    {
        protected Component _component;
        public Component Component { get { return _component; } }
    }
}
