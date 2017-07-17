using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSE2
{
    public class Application
    {
        #region Singleton pattern

        private static readonly Lazy<Application> lazy = new Lazy<Application>(() => new Application());

        public static Application Instance { get { return lazy.Value; } }

        #endregion

        private Ship currentShip;
        public Ship CurrentShip { get { return currentShip; } }
        public Settings Settings { get; }

        private Application()
        {
            Settings = new Settings();
            Settings.SetRSFolder(@"C:\Program Files (x86)\Steam\steamapps\common\Rogue System\");
            Backend.SceneManager scene = Backend.SceneManager.Instance;
        }

        public void LoadShip(string name)
        {
            RogLoader loader = new RogLoader();
            currentShip = loader.Load(name);
        }
    }
}
