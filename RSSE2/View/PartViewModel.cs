using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSE2
{
    public class PartViewModel
    {
        private Part _part;
        public Part Part { get { return _part; } }

        public ObservableCollection<ModViewModel> Mods { get; set; } 

        public PartViewModel( Part part )
        {
            _part = part;
            Mods = new ObservableCollection<ModViewModel>();
            foreach ( Mod mod in _part.mod )
            {
                Mods.Add(mod.CreateViewModel());
            }
        }
    }
}
