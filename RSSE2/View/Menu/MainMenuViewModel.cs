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
        public ShipHullListViewModel ShipHullList { get; set;  }

        public MainMenuViewModel()
        {
            while ( !File.Exists(Application.Instance.Settings.RSFolder + @"RogueSystemSim.exe") )
            {
                global::System.Windows.Forms.MessageBox.Show("Please select your Rogue System folder");

                var dialog = new global::System.Windows.Forms.FolderBrowserDialog();
                global::System.Windows.Forms.DialogResult result = dialog.ShowDialog();

                if (result == global::System.Windows.Forms.DialogResult.OK)
                {
                    Application.Instance.Settings.SetRSFolder(dialog.SelectedPath+"\\");
                }
            }

            ShipHullList = new ShipHullListViewModel();
        }
    }
}
