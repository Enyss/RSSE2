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
    /// Logique d'interaction pour PartTreeView.xaml
    /// </summary>
    public partial class PartTreeView : UserControl
    {
        public PartTreeView()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty SelectedPartProperty =
    DependencyProperty.Register("SelectedPart", typeof(PartViewModel), typeof(PartTreeView));

        public PartViewModel SelectedPart
        {
            get { return (PartViewModel)GetValue(SelectedPartProperty); }
            set { SetValue(SelectedPartProperty, value); }
        }

        private void Tree_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            SelectedPart = new PartViewModel( ((PartTreeNodeViewModel)e.NewValue).Part );
        }
    }
}
