using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

using OpenTK;
using OpenTK.Graphics.OpenGL4;
using System.IO;

namespace RSSE2
{
    /// <summary>

    /// Interaction logic for MainWindow.xaml

    /// </summary>

    public partial class MainWindow : Window
    { 
        public ShipViewModel Ship { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;

            Application app = Application.Instance;
            app.LoadShip("Archelion_SV_46_II");
            Ship = new ShipViewModel(app.CurrentShip);

            Backend.SceneManager scene = Backend.SceneManager.Instance;
            foreach( Part part in Ship.Ship.exterior )
            {
                    scene.LoadPart(part);
            }
        }
    }
}