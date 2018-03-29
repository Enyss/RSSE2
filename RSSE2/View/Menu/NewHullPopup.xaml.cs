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
using System.Windows.Shapes;

namespace RSSE2
{
    /// <summary>
    /// Logique d'interaction pour NewHullPopup.xaml
    /// </summary>
    public partial class NewHullPopup : Window
    {
        public NewHullPopup()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private string _filename;
        public string Filename
        {
            get { return _filename; }
            set { _filename = value; }
        }

        private ICommand _create;
        public ICommand CreateCommand
        {
            get
            {
                if (_create == null)
                {
                    _create = new RelayCommand(
                        param => this.Create(),
                        param => _filename != ""
                    );
                }
                return _create;
            }
        }

        private void Create()
        {
            this.DialogResult = true;
            this.Close();
        }

        private ICommand _cancel;
        public ICommand CancelCommand
        {
            get
            {
                if (_cancel == null)
                {
                    _cancel = new RelayCommand(
                        param => this.Cancel(),
                        param => true
                    );
                }
                return _cancel;
            }
        }

        private void Cancel()
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}
