using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSE2
{
    public class Settings
    {
        private string rsFolder;
        public string RSFolder { get { return rsFolder; } }

        public Settings()
        {
        }

        public void SetRSFolder( string path )
        {
            rsFolder = path;
        }


    }
}
