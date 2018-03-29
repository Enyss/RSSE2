using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSE2
{
    public class LSSSystem : ShipSystem
    {

        public int mount_MAX;
		public int TANKAtotal;
        public int TANKBtotal;
        public int TANKCtotal;
        public double LIFESUPPORTAtankCAP;
        public double LIFESUPPORTBtankCAP;
        public double CONSUMABLEtankCAP;
        public List<ScrubberLocation> scrubbers;


        public LSSSystem(Table table)
        {
            Table t = table["LSS"];
            mount_MAX = (int)t["mount_MAX"];
            TANKAtotal = (int)t["TANKAtotal"];
            TANKBtotal = (int)t["TANKBtotal"];
            TANKCtotal = (int)t["TANKCtotal"];
            LIFESUPPORTAtankCAP = t["LIFESUPPORTAtankCAP"];
            LIFESUPPORTBtankCAP = t["LIFESUPPORTBtankCAP"];
            CONSUMABLEtankCAP = t["CONSUMABLEtankCAP"];

            scrubbers = new List<ScrubberLocation>();
            int i = 1;
            while(t.ContainsKey("scrubber"+i+"_LOC") )
            {
                scrubbers.Add(new ScrubberLocation(t["scrubber" + i + "_LOC"]));
                i++;
            }
        }

        public override ShipSystemViewModel CreateViewModel()
        {
            return new LSSSystemViewModel(this);
        }

        public override void ToTable(Table table)
        {
            throw new NotImplementedException();
        }
    }
}
