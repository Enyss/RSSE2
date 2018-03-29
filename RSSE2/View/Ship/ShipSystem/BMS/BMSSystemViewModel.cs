using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace RSSE2
{
    public class BMSSystemViewModel : ShipSystemViewModel
    {

        public override string Name { get { return "BMS"; } }

        #region Properties

        public int Mount_MAX
        {
            get { return ((BMSSystem)ShipSystem).mount_MAX; }
            set
            {
                ((BMSSystem)ShipSystem).mount_MAX = value;
                OnPropertyChanged();
            }
        }

        public int Total_ALLOWED
        {
            get { return ((BMSSystem)ShipSystem).total_ALLOWED; }
            set
            {
                ((BMSSystem)ShipSystem).total_ALLOWED = value;
                OnPropertyChanged();
            }
        }


        #endregion
        public ObservableCollection<BatteryLocationViewModel> BatteryLocations { get; set; }


        public BMSSystemViewModel(BMSSystem bms) : base(bms)
        {
            BatteryLocations = new ObservableCollection<BatteryLocationViewModel>();
            foreach (BatteryLocation batteryLocation in bms.batteryLocations)
            {
                BatteryLocations.Add(new BatteryLocationViewModel(batteryLocation));
            }
        }
    }
}
