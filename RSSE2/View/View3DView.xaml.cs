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

using System.Windows.Forms;
using System.Windows.Forms.Integration;

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL4;
using System.IO;

namespace RSSE2
{
    /// <summary>
    /// Logique d'interaction pour View3DView.xaml
    /// </summary>
    public partial class View3DView : global::System.Windows.Controls.UserControl
    {        
        public View3DView()
        {
            InitializeComponent();
        }

        public void HostControl_Loaded(object sender, EventArgs e)
        {
            ((WindowsFormsHost)sender).Child = RSSE2.Backend.SceneManager.Instance.Control;
            RSSE2.Backend.SceneManager.Instance.Control.MakeCurrent();
        }
    }
}
