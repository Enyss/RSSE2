using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSE2.Backend
{
    public class MdlManager
    {
        public Dictionary<string, Mdl> models;

        public MdlManager()
        {
            models = new Dictionary<string, Mdl>();
        }

        public void Load(string name)
        {
            if (!models.ContainsKey(name))
            {
                models.Add(name, new Mdl(name));
            }
        }
    }
}
