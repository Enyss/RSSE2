using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSE2
{
    public class Texture
    {
        public string filename;

        public Texture()
        {
            filename = "empty";
        }

        public Texture(string filename)
        {
            this.filename = filename;
        }
    }
}
