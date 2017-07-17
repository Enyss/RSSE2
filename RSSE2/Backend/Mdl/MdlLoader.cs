using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSE2.Backend
{
    public class MdlLoader
    {
        private Dictionary<string, Mdl> models;

        public MdlLoader()
        {
            models = new Dictionary<string, Mdl>();
        }

        public void AddMdl(string filename)
        {
            if (!models.ContainsKey(filename))
            {
                models.Add(filename, new Mdl(filename));
            }
        }
    }
}
