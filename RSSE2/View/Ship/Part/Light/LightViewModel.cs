using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSE2
{
    class LightViewModel : ComponentViewModel
    {
        public Light Model { get { return (Light)_component; } }
        
        #region Properties

        public dynamic SelectedColor
        {
            get
            {
                return "#FF" + Model.color.ToRGBhex();
            }
            set
            {
                Model.color = new ColorRGB( value.R, value.G, value.B );
                OnPropertyChanged();
            }
        }

        public int LightType
        {
            get { return (int)Model.type; }
            set
            {
                Model.type = (LightType)value;
                OnPropertyChanged();
            }
        }

        public double Range
        {
            get { return Model.range; }
            set
            {
                Model.range = value;
                OnPropertyChanged();
            }
        }

        public double Intensity
        {
            get { return Model.intensity; }
            set
            {
                Model.intensity = value;
                OnPropertyChanged();
            }
        }
        public double SpotCone
        {
            get { return Model.spotCone; }
            set
            {
                Model.spotCone = value;
                OnPropertyChanged();
            }
        }
        
        public int ShadowType
        {
            get { return (int)Model.shadowType; }
            set
            {
                Model.shadowType = (ShadowType)value;
                OnPropertyChanged();
            }
        }

        #endregion

        public LightViewModel( Light light )
        {
            _component = light;
        }

    }
}
