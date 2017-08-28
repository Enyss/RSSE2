using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSE2
{
    public abstract class Component
    {
        public abstract ComponentViewModel CreateViewModel();
        public abstract void ToTable(Table table);
    }
}
