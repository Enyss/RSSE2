using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSE2
{
    public class ShipViewModel
    {
        public PartTreeViewModel Interior { get; set; }
        public PartTreeViewModel Exterior { get; set; }

        public ShipViewModel(Ship ship)
        {

            Interior = new PartTreeViewModel();

            foreach (Part part in ship.interior)
            {
                Interior.Parts.Add(new PartTreeNodeViewModel(part, null));
            }

            Exterior = new PartTreeViewModel();

            foreach(Part part in ship.exterior)
            {
                Exterior.Parts.Add(new PartTreeNodeViewModel(part, null));
            }
        }
    }
}
