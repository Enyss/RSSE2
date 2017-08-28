using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MoonSharp.Interpreter;
using System.Windows.Input;

namespace RSSE2
{
    public class MainMenuViewModel
    {
        public ObservableCollection<string> ShipList { get; set; }

        public MainMenuViewModel()
        {
            while ( !File.Exists(Application.Instance.Settings.RSFolder + @"RogueSystemSim.exe") )
            {
                System.Windows.Forms.MessageBox.Show("Please select your Rogue System folder");

                var dialog = new System.Windows.Forms.FolderBrowserDialog();
                System.Windows.Forms.DialogResult result = dialog.ShowDialog();

                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    Application.Instance.Settings.SetRSFolder(dialog.SelectedPath+"\\");
                }
            }

            RefreshShipList();
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
                        param => param!=null
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

        #endregion

        public void RefreshShipList()
        {
            // Clear ship list 
            ShipList = new ObservableCollection<string>();

            // Get ship list   
            string luaTable = File.ReadAllText(Application.Instance.Settings.RSFolder + @"Mod\RogSysCM\Ships\ShipHullList.ROG");

            DynValue dv = Application.Instance.Lua.DoString(luaTable + "\nreturn ShipHull");
            Table shipList = new Table(dv.Table);

            for (int i = 1; i <= shipList["Total"]; i++)
            {
                ShipList.Add(shipList["Ship" + i]["Name"]);
            }
        }
    }
}
