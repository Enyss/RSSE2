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



namespace RSSE2
{
    /// <summary>

    /// Interaction logic for MainWindow.xaml

    /// </summary>

    public partial class MainWindow : Window

    {
        public PartViewModel Part { get; set; }
        public ObservableCollection<PartTreeViewModel> Tree { get; set; }

        public MainWindow()
        {

            InitializeComponent();
            this.DataContext = this;

            Part part1 = new Part();

            part1.name = "Test Part 1";

            Model model1 = new Model();
            model1.texture.Add(new Texture("yala"));
            model1.texture.Add(new Texture("yele"));
            model1.texture.Add(new Texture("yili"));
            model1.texture.Add(new Texture("yolo"));

            Physic physic1 = new Physic();
            physic1.collision = true;
            physic1.mass = 10.0;
            physic1.friction = 0.0;
            physic1.shape = new CollisionSphere(10.0);
            physic1.shape.autogen = false;

            part1.components.Add(model1);
            part1.components.Add(physic1);

            Part part11 = new Part();

            part11.name = "Test Part 1.1";
            part11.parent = part1;
            part1.children.Add(part11);

            Model model11 = new Model();
            model11.texture.Add(new Texture("yala"));
            model11.texture.Add(new Texture("yele"));
            model11.texture.Add(new Texture("yili"));
            model11.texture.Add(new Texture("yolo"));

            Physic physic11 = new Physic();
            physic11.collision = true;
            physic11.mass = 10.0;
            physic11.friction = 0.0;
            physic11.shape = new CollisionSphere(10.0);
            physic11.shape.autogen = false;

            part11.components.Add(model11);
            part11.components.Add(physic11);

            Part part2 = new Part();

            part2.name = "Test Part 2";

            Model model2 = new Model();
            model2.texture.Add(new Texture("yala"));
            model2.texture.Add(new Texture("yele"));
            model2.texture.Add(new Texture("yili"));
            model2.texture.Add(new Texture("yolo"));

            part2.components.Add(model2);

            Tree = new ObservableCollection<PartTreeViewModel>();
            Tree.Add(new PartTreeViewModel(part1, null));
            Tree.Add(new PartTreeViewModel(part2, null));
        }

    }

}