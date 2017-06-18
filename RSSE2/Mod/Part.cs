using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSE2
{
    public class Part
    {
        public List<Mod> mod;
        public string name;

        public Part()
        {
            mod = new List<Mod>();
        }
    }
}
