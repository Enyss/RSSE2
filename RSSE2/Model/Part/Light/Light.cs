using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSE2
{
    public enum LightType { Point, Spot, Directional }
    public enum ShadowType { None, Static, Dynamic, StaticDynamic, StaticDynamicBuffered }

    public class Light : Component
    {
        public ColorRGB color;
        public LightType type;
        public double range;
        public double intensity;
        public double spotCone;
        public ShadowType shadowType;
        
        public Light( Table table )
        {
            type = (LightType)table["LightData"]["Type"];
            range = table["LightData"]["x"];
            intensity = table["LightData"]["y"];
            spotCone = table["LightData"]["z"];
            color = new ColorRGB(table["LightData"]["color"]);
            shadowType = (ShadowType)table["ShadowType"];
        }

        public override ComponentViewModel CreateViewModel()
        {
            return new LightViewModel(this);
        }

        public override void ToTable(Table table)
        {
            throw new NotImplementedException();
        }

    }
}
