using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSE2
{
    public class TMSSystemViewModel : ShipSystemViewModel
    {
        public TMSSystem TMS { get { return (TMSSystem)ShipSystem; } }


        #region Properties

        public int Heatpipe_TOTAL
        {
            get { return TMS.heatpipe_TOTAL; }
            set
            {
                TMS.heatpipe_TOTAL = value;
                OnPropertyChanged();
            }
        }

        public double Heatpipe_SURFACEvolume
        {
            get { return TMS.heatpipe_SURFACEvolume; }
            set
            {
                TMS.heatpipe_SURFACEvolume = value;
                OnPropertyChanged();
            }
        }

        public int COOLloopTOTAL
        {
            get { return TMS.COOLloopTOTAL; }
            set
            {
                TMS.COOLloopTOTAL = value;
                OnPropertyChanged();
            }
        }

        public double COOLareaMIN
        {
            get { return TMS.COOLareaMIN; }
            set
            {
                TMS.COOLareaMIN = value;
                OnPropertyChanged();
            }
        }

        public double COOLareaMAX
        {
            get { return TMS.COOLareaMAX; }
            set
            {
                TMS.COOLareaMAX = value;
                OnPropertyChanged();
            }
        }

        public double COOLareaREFLECT
        {
            get { return TMS.COOLareaREFLECT; }
            set
            {
                TMS.COOLareaREFLECT = value;
                OnPropertyChanged();
            }
        }

        public double COOLlevelMAX
        {
            get { return TMS.COOLlevelMAX; }
            set
            {
                TMS.COOLlevelMAX = value;
                OnPropertyChanged();
            }
        }

        public double COOLpsiMAX
        {
            get { return TMS.COOLpsiMAX; }
            set
            {
                TMS.COOLpsiMAX = value;
                OnPropertyChanged();
            }
        }

        public string COOLcoolant
        {
            get { return TMS.COOLcoolant; }
            set
            {
                TMS.COOLcoolant = value;
                OnPropertyChanged();
            }
        }

        public double COOLtankCAP
        {
            get { return TMS.COOLtankCAP; }
            set
            {
                TMS.COOLtankCAP = value;
                OnPropertyChanged();
            }
        }

        public double COOLlinelength
        {
            get { return TMS.COOLlinelength; }
            set
            {
                TMS.COOLlinelength = value;
                OnPropertyChanged();
            }
        }

        public override string Name { get { return "TMS"; } }

        #endregion

        public TMSSystemViewModel(TMSSystem tms) : base(tms)
        {

        }
    }
}
