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
        public ObservableDictionnary<PartViewModel, RSSE2.Backend.Model> scene;
        public bool IsLoaded {
            get;
            set;
        }

        public SceneViewModel()
        {
            IsLoaded = false;
        }

        public void SetupScene( List<PartViewModel> parts )
        {
            scene = new ObservableDictionnary<PartViewModel, RSSE2.Backend.Model>();
            foreach (PartViewModel part in parts)
            {
                if (part.Part.components.ContainsKey("Model"))
                {
                    scene.Add( part, new RSSE2.Backend.Model((Model)part.Part.components["Model"]) );
                }
            }
        }

        public void LoadScene()
        {
            IsLoaded = Loading();
        }

        public bool Loading()
        {
            foreach (KeyValuePair<PartViewModel, RSSE2.Backend.Model> pair in scene)
            {
                pair.Value.Load();
            }
            return true;
        }
    }
}
