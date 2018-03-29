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
    DependencyProperty.Register("SelectedPart", typeof(PartTreeNodeViewModel), typeof(PartTreeView));

        public PartTreeNodeViewModel SelectedPart
        {
            get { return (PartTreeNodeViewModel)GetValue(SelectedPartProperty); }
            set
            {
                if (SelectedPart != null)
                {
                    SelectedPart.Current.selected = false;
                }
                if (value != null)
                {
                    value.Current.selected = true;
                }
                SetValue(SelectedPartProperty, value);
                Backend.SceneManager.Instance.Paint();
            }
        }

        private void Tree_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            SelectedPart = (PartTreeNodeViewModel)e.NewValue;
        }
    }
}
