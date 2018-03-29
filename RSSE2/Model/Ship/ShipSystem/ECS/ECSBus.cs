using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSE2
{
    public class ECSBus
    {
        public string name;
        public int count;
        public double ampsMax;

        public ECSBus( string name, int count, double ampsMax)
        {
            this.name = name;
            this.count = count;
            this.ampsMax = ampsMax;
        }
    }
}
