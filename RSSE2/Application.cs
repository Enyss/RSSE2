using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MoonSharp.Interpreter;
using System.IO;

namespace RSSE2
{
    public class Application : ObservableObject
    {
        #region Singleton pattern

        private static readonly Lazy<Application> lazy = new Lazy<Application>(() => new Application());

        public static Application Instance { get { return lazy.Value; } }

        #endregion

        public Script Lua { get; }

        private dynamic currentlyLoaded;
        public dynamic CurrentlyLoaded
        {
            get
            {
                return currentlyLoaded;
            }
            set
            {
                currentlyLoaded = value;
                OnPropertyChanged();
            }
        }

        public Settings Settings { get; }

        private Application()
        {
            // Load the application settings
            Settings = new Settings();
            Settings.SetRSFolder(@"C:\Program Files (x86)\Steam\steamapps\common\Rogue System\");

            // Setup the lua engine
            Lua = new Script(CoreModules.Preset_Complete);
        }
    }
}
