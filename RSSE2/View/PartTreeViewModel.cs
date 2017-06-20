using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace RSSE2
{
    public class PartTreeViewModel : DependencyObject
    {
        public ObservableCollection<PartTreeNodeViewModel> Parts { set; get; }
        private ICommand _addCommand;


        public PartTreeViewModel()
        {
            Parts = new ObservableCollection<PartTreeNodeViewModel>();
        }

        #region AddPart Command

        public void AddPart()
        {
            Part part = new Part();
            Parts.Add(new PartTreeNodeViewModel(part, null));
        }

        public ICommand AddCommand
        {
            get
            {
                if (_addCommand == null)
                {
                    _addCommand = new RelayCommand(
                        param => this.AddPart(),
                        param => this.CanAdd()
                    );
                }
                return _addCommand;
            }
        }

        private bool CanAdd()
        {
            // Verify command can be executed here
            return true;
        }

#endregion

    }
}
