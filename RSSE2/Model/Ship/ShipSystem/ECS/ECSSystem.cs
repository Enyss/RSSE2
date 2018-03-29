using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSE2
{
    public class ECSSystem : ShipSystem
    {
        public double PWRpercent;
        public double MASSpercent;
        public List<ECSBus> Buses;

        public ECSSystem(Table table)
        {
            PWRpercent = table["ECS_PWRpercent"];
            MASSpercent = table["ECS_MASSpercent"];

            Buses = new List<ECSBus>();
            Buses.Add(new ECSBus("SYS", (int)table["ECS_SYStotal"], table["ECS_SYSAMPSmax"]));
            Buses.Add(new ECSBus("HV", (int)table["ECS_HVtotal"], table["ECS_HVAMPSmax"]));
            Buses.Add(new ECSBus("WPN", (int)table["ECS_WPNtotal"], table["ECS_WPNAMPSmax"]));
            Buses.Add(new ECSBus("RSRV", 1, table["ECS_RSRVAMPSmax"]));
            Buses.Add(new ECSBus("EMRG", 1, table["ECS_EMRGAMPSmax"]));
        }

        public override ShipSystemViewModel CreateViewModel()
        {
            return new ECSSystemViewModel(this);
        }

        public override void ToTable(Table table)
        {
            table.Add("ECS_PWRpercent", PWRpercent);
            table.Add("ECS_MASSpercent", MASSpercent);

            foreach(ECSBus bus in Buses)
            {
                table.Add("ECS_" + bus.name + "total", bus.count);
                table.Add("ECS_" + bus.name + "AMPSmax", bus.ampsMax);
            }
        }
    }
}
