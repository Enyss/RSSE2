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
        public List<Part> interiorTree;
        public List<Part> exteriorTree;
        public string name;
        public string Folder;

        public Ship(string name)
        {
            interior = new List<Part>();
            exterior = new List<Part>();
            interiorTree = new List<Part>();
            exteriorTree = new List<Part>();
            this.name = name;
            Folder = Application.Instance.Settings.RSFolder +
                @"Mod\RogSysCM\Ships\" + name + @"\";

        }
    }
}
