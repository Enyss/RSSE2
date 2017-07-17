using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSE2
{
    public class ShipViewModel
    {
        private Ship ship;
        public Ship Ship { get { return ship; } }

        public PartTreeViewModel Interior { get; set; }
        public PartTreeViewModel Exterior { get; set; }

        public ShipViewModel(Ship ship)
        {
            this.ship = ship;

            Interior = new PartTreeViewModel();
            foreach (Part part in ship.interiorTree)
            {
                Interior.Parts.Add(new PartTreeNodeViewModel(part, null));
            }

            Exterior = new PartTreeViewModel();
            foreach(Part part in ship.exteriorTree)
            {
                Exterior.Parts.Add(new PartTreeNodeViewModel(part, null));
            }
        }
    }
}
