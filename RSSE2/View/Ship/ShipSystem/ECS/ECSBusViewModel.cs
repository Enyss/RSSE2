using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSE2
{ 
    public class ECSBusViewModel : ObservableObject
    {
        private ECSBus bus;
        public ECSBus Bus { get { return bus; } }

        public string Name
        {
            get { return Bus.name; }
            set
            {
                Bus.name = value;
                OnPropertyChanged();
            }
        }

        public int Count
        {
            get { return Bus.count; }
            set
            {
                Bus.count = value;
                OnPropertyChanged();
            }
        }

        public double AmpsMax
        {
            get { return Bus.ampsMax; }
            set
            {
                Bus.ampsMax = value;
                OnPropertyChanged();
            }
        }

        public ECSBusViewModel( ECSBus bus )
        {
            this.bus = bus;
        }
    }
}
