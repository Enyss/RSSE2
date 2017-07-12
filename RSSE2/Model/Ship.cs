using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSE2
{
    public class Ship
    {
        public List<Part> interior;
        public List<Part> exterior;
        public string name;

        public Ship()
        {
            interior = new List<Part>();
            exterior = new List<Part>();
        }
    }
}
