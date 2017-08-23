using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RSSE2
{
    /// <summary>
    /// Logique d'interaction pour ShipView.xaml
    /// </summary>
    public partial class ShipView : UserControl
    {
        public ShipView()
        {
            InitializeComponent();
        }

        private void InteriorTab_GotFocus(object sender, RoutedEventArgs e)
        {
            if ( !((ShipViewModel)DataContext).InteriorScene.IsLoaded )
            {
                ((ShipViewModel)DataContext).InteriorScene.LoadScene();
            }
            RSSE2.Backend.SceneManager.Instance.CurrentScene = ((ShipViewModel)DataContext).InteriorScene;
        }

        private void ExteriorTab_GotFocus(object sender, RoutedEventArgs e)
        {
            if ( !((ShipViewModel)DataContext).ExteriorScene.IsLoaded)
            {
                ((ShipViewModel)DataContext).ExteriorScene.LoadScene();
            }
            RSSE2.Backend.SceneManager.Instance.CurrentScene = ((ShipViewModel)DataContext).ExteriorScene;
        }
    }
}
