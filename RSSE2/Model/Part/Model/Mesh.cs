using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSE2
{
    public class Mesh
    {
        public string filename;

        public Mesh()
        {
            filename = "empty";
        }

        public Mesh( string filename)
        {
            this.filename = filename;
        }

    }
}
