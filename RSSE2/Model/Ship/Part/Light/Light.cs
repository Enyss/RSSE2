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

        public override string Name { get { return "Light"; } }

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
            Table lightData = new Table();
            lightData.Add("Type", (double)type);
            lightData.Add("x", range);
            lightData.Add("y", intensity);
            lightData.Add("z", spotCone);
            lightData.Add("color", color.ToTable());
            
            table.Add("LightData", lightData);
            table.Add("ShadowType", (double)shadowType);
        }

        internal static Light GenerateComponent(Table table)
        {
            if (table.ContainsKey("LightData"))
            {
                return new Light(table);
            }
            return null;
        }
    }
}
