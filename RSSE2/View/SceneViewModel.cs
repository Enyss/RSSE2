using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSE2
{
    public class SceneViewModel
    {
        public ObservableDictionnary<Part, RSSE2.Backend.Model> scene;
        public bool IsLoaded {
            get;
            set;
        }

        public SceneViewModel()
        {
            IsLoaded = false;
        }

        public void SetupScene( List<Part> parts )
        {
            scene = new ObservableDictionnary<Part, RSSE2.Backend.Model>();
            foreach (Part part in parts)
            {
                if (part.components.ContainsKey("Model"))
                {
                    scene.Add( part, new RSSE2.Backend.Model((Model)part.components["Model"]) );
                }
            }
        }

        public void LoadScene()
        {
            IsLoaded = Loading();
        }

        public bool Loading()
        {
            foreach (KeyValuePair<Part, RSSE2.Backend.Model> pair in scene)
            {
                pair.Value.Load();
            }
            return true;
        }
    }
}
