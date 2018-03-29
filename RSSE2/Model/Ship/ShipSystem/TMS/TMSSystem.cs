using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSE2
{
    public class TMSSystem : ShipSystem
    {

        public int heatpipe_TOTAL;
        public double heatpipe_SURFACEvolume;
        public int COOLloopTOTAL;
        public double COOLareaMIN;
        public double COOLareaMAX;
        public double COOLareaREFLECT;
        public double COOLlevelMAX;
        public double COOLpsiMAX;
        public string COOLcoolant;
        public double COOLtankCAP;
        public double COOLlinelength;

        public TMSSystem(Table table)
        {
            Table t = table["TMS"];

            heatpipe_TOTAL = (int)t["heatpipe_TOTAL"];
            heatpipe_SURFACEvolume = t["heatpipe_SURFACEvolume"];
            COOLloopTOTAL = (int)t["COOLloopTOTAL"];
            COOLareaMIN = t["COOLareaMIN"];
            COOLareaMAX = t["COOLareaMAX"];
            COOLareaREFLECT = t["COOLareaREFLECT"];
            COOLlevelMAX = t["COOLlevelMAX"];
            COOLpsiMAX = t["COOLpsiMAX"];
            COOLcoolant = t["COOLcoolant"];
            COOLtankCAP = t["COOLtankCAP"];
            COOLlinelength = t["COOLlinelength"];
        }

        public override ShipSystemViewModel CreateViewModel()
        {
            return new TMSSystemViewModel(this);
        }

        public override void ToTable(Table table)
        {
            Table t = new Table();
            t["heatpipe_TOTAL"] = heatpipe_TOTAL;
            t["heatpipe_SURFACEvolume"] = heatpipe_SURFACEvolume;
            t["COOLloopTOTAL"] = COOLloopTOTAL;
            t["COOLareaMIN"] = COOLareaMIN;
            t["COOLareaMAX"] = COOLareaMAX;
            t["COOLareaREFLECT"] = COOLareaREFLECT;
            t["COOLlevelMAX"] = COOLlevelMAX;
            t["COOLpsiMAX"] = COOLpsiMAX;
            t["COOLcoolant"] = COOLcoolant;
            t["COOLtankCAP"] = COOLtankCAP;
            t["COOLlinelength"] = COOLlinelength;
            table["TMS"] = t;
        }
    }
}
