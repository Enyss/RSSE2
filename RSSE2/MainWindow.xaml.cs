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

    /// Interaction logic for MainWindow.xaml

    /// </summary>

    public partial class MainWindow : Window

    {
        public PartViewModel Part { get; set; }

        public MainWindow()
        {

            InitializeComponent();
            this.DataContext = this;

            Part part = new Part();

            part.name = "Test Part";

            Model model = new Model();
            model.texture.Add(new Texture("yala"));
            model.texture.Add(new Texture("yele"));
            model.texture.Add(new Texture("yili"));
            model.texture.Add(new Texture("yolo"));

            Physic physic = new Physic();
            physic.collision = true;
            physic.mass = 10.0;
            physic.friction = 0.0;
            physic.shape = new CollisionSphere(10.0);
            physic.shape.autogen = false;

            part.mod.Add(model);
            part.mod.Add(physic);

            Part = new PartViewModel(part);
        }

    }

}