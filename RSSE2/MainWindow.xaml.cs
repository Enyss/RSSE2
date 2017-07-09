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
        public PartTreeViewModel Tree { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;


            RogLoader loader = new RogLoader();

            Ship ship = loader.Load("test2.rog", "Archelion_SV_46_II"); // "VoidComm_OPS4_sat", "Archelion_SV_46_II"

            Tree = new PartTreeViewModel();

            foreach (Part part in ship.parts)
            {
                Tree.Parts.Add(new PartTreeNodeViewModel(part, null));
            }
        }

    }

}