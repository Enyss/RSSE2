using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSE2
{
    public class LSSSystemViewModel : ShipSystemViewModel
    {
        public override string Name { get { return "LSS"; } }

        #region Properties

        public int Mount_MAX
        {
            get { return ((LSSSystem)ShipSystem).mount_MAX; }
            set
            {
                ((LSSSystem)ShipSystem).mount_MAX = value;
                OnPropertyChanged();
            }
        }

        public int TANKAtotal
        {
            get { return ((LSSSystem)ShipSystem).TANKAtotal; }
            set
            {
                ((LSSSystem)ShipSystem).TANKAtotal = value;
                OnPropertyChanged();
            }
        }

        public int TANKBtotal
        {
            get { return ((LSSSystem)ShipSystem).TANKBtotal; }
            set
            {
                ((LSSSystem)ShipSystem).TANKBtotal = value;
                OnPropertyChanged();
            }
        }

        public int TANKCtotal
        {
            get { return ((LSSSystem)ShipSystem).TANKCtotal; }
            set
            {
                ((LSSSystem)ShipSystem).TANKCtotal = value;
                OnPropertyChanged();
            }
        }

        public double LIFESUPPORTAtankCAP
        {
            get { return ((LSSSystem)ShipSystem).LIFESUPPORTAtankCAP; }
            set
            {
                ((LSSSystem)ShipSystem).LIFESUPPORTAtankCAP = value;
                OnPropertyChanged();
            }
        }

        public double LIFESUPPORTBtankCAP
        {
            get { return ((LSSSystem)ShipSystem).LIFESUPPORTBtankCAP; }
            set
            {
                ((LSSSystem)ShipSystem).LIFESUPPORTBtankCAP = value;
                OnPropertyChanged();
            }
        }

        public double CONSUMABLEtankCAP
        {
            get { return ((LSSSystem)ShipSystem).CONSUMABLEtankCAP; }
            set
            {
                ((LSSSystem)ShipSystem).CONSUMABLEtankCAP = value;
                OnPropertyChanged();
            }
        }

        #endregion 
        public ObservableCollection<ScrubberLocationViewModel> Scrubbers { get; set; }


        public LSSSystemViewModel(LSSSystem lss) : base(lss)
        {
            Scrubbers = new ObservableCollection<ScrubberLocationViewModel>();
            foreach(ScrubberLocation scrubber in lss.scrubbers)
            {
                Scrubbers.Add(new ScrubberLocationViewModel(scrubber));
            }
        }

    }
}
