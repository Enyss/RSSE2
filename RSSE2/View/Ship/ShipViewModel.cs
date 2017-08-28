using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSE2
{
    public class ShipViewModel
    {
        private Ship ship;
        public Ship Ship { get { return ship; } }

        public string Folder {  get { return Application.Instance.Settings.RSFolder + @"Mod\RogSysCM\Ships\" + ship.name + @"\"; } }
        public string Name
        {
            get { return ship.name; } 
        }

        public PartTreeViewModel Interior { get; set; }
        public PartTreeViewModel Exterior { get; set; }

        public SceneViewModel InteriorScene { get; set; }
        public SceneViewModel ExteriorScene { get; set; }

        public ShipViewModel(Ship ship)
        {
            this.ship = ship;
        }

        public void UpdateViewModel()
        {
            Interior = new PartTreeViewModel();
            foreach (Part part in ship.interior)
            {
                if (part.parent == null)
                {
                    Interior.Parts.Add(new PartTreeNodeViewModel(part, null));
                }
            }

            InteriorScene = new SceneViewModel();
            InteriorScene.SetupScene(ship.interior);

            Exterior = new PartTreeViewModel();
            foreach (Part part in ship.exterior)
            {
                if (part.parent == null)
                {
                    Exterior.Parts.Add(new PartTreeNodeViewModel(part, null));
                }
            }

            ExteriorScene = new SceneViewModel();
            ExteriorScene.SetupScene(ship.exterior);
        }
    }
}
