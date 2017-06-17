using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSE2
{
    public class Shader
    {
        public string filename;

        public Shader()
        {
            filename = "empty";
        }

        public Shader(string filename)
        {
            this.filename = filename;
        }
    }
}
