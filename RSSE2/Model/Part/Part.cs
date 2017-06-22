using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSE2
{
    public class Part
    {
        public List<Component> components;
        public string name;

        public Part parent;
        public List<Part> children;

        public Part()
        {
            name = "empty";
            components = new List<Component>();
            children = new List<Part>();
        }
    }
}
