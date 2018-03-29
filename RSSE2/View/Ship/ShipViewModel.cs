using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

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
        public List<PartViewModel> InteriorParts;
        public PartTreeViewModel Exterior { get; set; }
        public List<PartViewModel> ExteriorParts;

        public SceneViewModel InteriorScene { get; set; }
        public SceneViewModel ExteriorScene { get; set; }

        public ObservableCollection<ShipSystemViewModel> ShipSystems { get; set; }

        #region Commands

        private ICommand _saveShipCommand;
        public ICommand SaveShipCommand
        {
            get
            {
                if (_saveShipCommand == null)
                {
                    _saveShipCommand = new RelayCommand(
                        param => SaveShip(),
                        param => true
                    );
                }
                return _saveShipCommand;
            }
        }

        #endregion

        public ShipViewModel(Ship ship)
        {
            this.ship = ship;
        }

        public void UpdateViewModel()
        {
            Interior = new PartTreeViewModel();
            InteriorParts = new List<PartViewModel>();

            foreach (Part part in ship.interior)
            {
                if (part.parent == null)
                {
                    PartTreeNodeViewModel node = new PartTreeNodeViewModel(part, null, Interior);
                    Interior.Parts.Add(node);
                    FlatPartsList(InteriorParts,node);
                }
            }

            InteriorScene = new SceneViewModel();
            InteriorScene.SetupScene(InteriorParts);

            Exterior = new PartTreeViewModel();
            ExteriorParts = new List<PartViewModel>();
            foreach (Part part in ship.exterior)
            {
                if (part.parent == null)
                {
                    PartTreeNodeViewModel node = new PartTreeNodeViewModel(part, null, Exterior);
                    Exterior.Parts.Add(node);
                    FlatPartsList(ExteriorParts, node);
                }
            }

            ExteriorScene = new SceneViewModel();
            ExteriorScene.SetupScene(ExteriorParts);

            ShipSystems = new ObservableCollection<ShipSystemViewModel>();
            foreach (ShipSystem system in ship.shipSystems)
            {
                ShipSystems.Add(system.CreateViewModel());
            }
        }

        private void FlatPartsList(List<PartViewModel> list, PartTreeNodeViewModel node)
        {
            list.Add(node.Current);
            foreach( PartTreeNodeViewModel child in node.Children)
            {
                FlatPartsList(list, child);
            }
        }

        private void SaveShip()
        {
            Ship.SaveToFile();
        }
    }
}
