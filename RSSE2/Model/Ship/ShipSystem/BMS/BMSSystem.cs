using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSE2
{
    public class BMSSystem : ShipSystem
    {
        public int mount_MAX;
        public int total_ALLOWED;
        public List<BatteryLocation> batteryLocations;


        public BMSSystem(Table table)
        {
            Table t = table["BMS"];

            mount_MAX = (int)t["mount_MAX"];
            total_ALLOWED = (int)t["total_ALLOWED"];

            batteryLocations = new List<BatteryLocation>();
            int i = 1;
            while (t.ContainsKey("scrubber" + i + "_LOC"))
            {
                batteryLocations.Add(new BatteryLocation(t["battery" + i + "_LOC"]));
                i++;
            }

        }

        public override ShipSystemViewModel CreateViewModel()
        {
            return new BMSSystemViewModel(this);
        }

        public override void ToTable(Table table)
        {
            Table t = new Table();

            table["BMS"] = t;
        }
    }
}
