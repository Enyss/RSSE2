using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSE2
{
    class Application
    {
        public PartViewModel Part { get; set; }
        public PartTreeViewModel Tree { get; set; }

        public Application()
        {
            
        }

        public void LoadShip(string filename)
        {
            RogLoader loader = new RogLoader();

            string name = filename.Split(new char[] { '\\', '/' }).Last();
            name = name.Substring(0, name.Length - 4);

            Ship ship = loader.Load(filename, name);
        }
    }
}
