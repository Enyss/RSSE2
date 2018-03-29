using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSE2
{
    public class BatteryLocationViewModel : ObservableObject
    {
        private BatteryLocation _batteryLocation;
        public BatteryLocation BatteryLocation { get { return _batteryLocation; } }

        public bool Is_SPARE
        {
            get { return BatteryLocation.is_SPARE; }
            set
            {
                BatteryLocation.is_SPARE = value;
                OnPropertyChanged();
            }
        }

        public Vector3ViewModel Position { get; }
        public Vector3ViewModel Rotation { get; }

        public BatteryLocationViewModel(BatteryLocation batteryLocation)
        {
            _batteryLocation = batteryLocation;
            Position = new Vector3ViewModel(batteryLocation.position);
            Rotation = new Vector3ViewModel(batteryLocation.rotation);
        }
    }
}
