using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSE2
{
    public class ScrubberLocation
    {
        public bool is_SPARE;
        public Vector3 position;
        public Vector3 rotation;
        public int equipBay;
	    public int quad;

        public ScrubberLocation(Table table)
        {
            is_SPARE = (int)table["is_SPARE"] == 1;
            position = new Vector3(table["position"]);
            rotation = new Vector3(table["rotation"]);
            equipBay = (int)table["EquipBay"];
            quad = (int)table["Quad"];
        }
    }
}
