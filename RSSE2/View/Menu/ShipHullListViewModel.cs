using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.IO;

using MoonSharp.Interpreter;
using System.Windows.Input;
using System.Windows;

namespace RSSE2
{
    public class ShipHullListViewModel : ObservableObject
    {
        private ShipHullList _shipHullList;
        public ObservableCollection<string> ShipHullList { get; set; }


        public ShipHullListViewModel()
        {
            _shipHullList = new ShipHullList(Application.Instance.Settings.RSFolder + @"Mod\RogSysCM\Ships\ShipHullList.ROG");
            ShipHullList = new ObservableCollection<string>();

            foreach (string hull in _shipHullList.shipHullFile)
            {
                ShipHullList.Add(hull);
            }
        }

        #region Commands
        private ICommand _loadShipHullCommand;
        public ICommand LoadShipHullCommand
        {
            get
            {
                if (_loadShipHullCommand == null)
                {
                    _loadShipHullCommand = new RelayCommand(
                        param => this.LoadShipHull(param as string),
                        param => param != null
                    );
                }
                return _loadShipHullCommand;
            }
        }

        private void LoadShipHull(string shipHullName)
        {
            Ship s = new Ship(shipHullName);
            ShipViewModel ship = new ShipViewModel(s);
            Application.Instance.CurrentlyLoaded = ship;

            s.LoadFromFile(Application.Instance.Settings.RSFolder + @"Mod\RogSysCM\Ships\" + shipHullName + ".rog");
            ship.UpdateViewModel();
        }

        private ICommand _createNewHullCommand;
        public ICommand CreateNewHullCommand
        {
            get
            {
                if (_createNewHullCommand == null)
                {
                    _createNewHullCommand = new RelayCommand(
                        param => this.CreateNewHull(),
                        param => true
                    );
                }
                return _createNewHullCommand;
            }
        }

        private void CreateNewHull()
        {
            NewHullPopup popup = new NewHullPopup();
            if (popup.ShowDialog() == true)
            {
                string name = popup.Name;
                if (ShipHullList.Contains(name))
                {
                    MessageBox.Show("This ship hull already exists", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    _shipHullList.AddNewShipHull(name);
                    this.ShipHullList.Add(name);

                    _shipHullList.SaveToFile(Application.Instance.Settings.RSFolder + @"Mod\RogSysCM\Ships\ShipHullList.ROG");
                    Directory.CreateDirectory(Application.Instance.Settings.RSFolder + @"Mod\RogSysCM\Ships\" + name);
                    File.Create(Application.Instance.Settings.RSFolder + @"Mod\RogSysCM\Ships\" + name + ".ROG");
                }
            }
        }

        #endregion
    }
}
