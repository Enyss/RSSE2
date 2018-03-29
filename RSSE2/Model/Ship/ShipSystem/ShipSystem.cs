using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSE2
{
    public abstract class ShipSystem
    {
        public abstract ShipSystemViewModel CreateViewModel();
        public abstract void ToTable(Table table);
    }
}
