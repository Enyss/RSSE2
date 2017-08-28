using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSE2
{
    class ColorRGBAViewModel : ObservableObject
    {
        private ColorRGBA color;

        public dynamic Color
        {
            get
            {
                return "#" + color.a.ToString("X2") + color.r.ToString("X2") + color.g.ToString("X2") + color.b.ToString("X2");
            }
            set
            {
                color.r = value.R;
                color.g = value.G;
                color.b = value.B;
                color.a = value.A;
                OnPropertyChanged();
            }
        }
    }
}
