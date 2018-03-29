using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSE2
{
    public abstract class ShipSystemViewModel : ObservableObject
    {
        protected ShipSystem _shipSystem;
        public ShipSystem ShipSystem { get { return _shipSystem; } }
        public abstract string Name { get; }

        public ShipSystemViewModel( ShipSystem system )
        {
            _shipSystem = system;
        }
    }
}
