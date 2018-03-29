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
        public ObservableCollection<PartTreeNodeViewModel> Parts { get; }
        public ObservableCollection<PartTreeNodeViewModel> PartsFlat { get; }
        private ICommand _addPartCommand;
        private ICommand _removePartCommand;

        public View3DViewModel Scene { get; set; }

        public PartTreeViewModel()
        {
            Parts = new ObservableCollection<PartTreeNodeViewModel>();
            PartsFlat = new ObservableCollection<PartTreeNodeViewModel>();
            Scene = new View3DViewModel();
        }

        #region AddPart Command

        public void AddPart()
        {
            PartTreeNodeViewModel part = new PartTreeNodeViewModel(new Part(), null, this);
            Parts.Add(part);
        }

        public ICommand AddPartCommand
        {
            get
            {
                if (_addPartCommand == null)
                {
                    _addPartCommand = new RelayCommand(
                        param => this.AddPart(),
                        param => this.CanAddPart()
                    );
                }
                return _addPartCommand;
            }
        }

        private bool CanAddPart()
        {
            // Verify command can be executed here
            return true;
        }

        #endregion

        #region RemovePart Command

        public void RemovePart( PartTreeNodeViewModel part )
        {
            PartsFlat.Remove(part);
            if (part.Parent == null)
            {
                Parts.Remove(part);
            }
            else
            {
                part.Parent.Children.Remove(part);
                part.Parent = null;
            }
        }

        public ICommand RemovePartCommand
        {
            get
            {
                if (_removePartCommand == null)
                {
                    _removePartCommand = new RelayCommand(
                        param => this.RemovePart(param as PartTreeNodeViewModel),
                        param => this.CanRemove()
                    );
                }
                return _removePartCommand;
            }
        }

        private bool CanRemove()
        {
            // Verify command can be executed here
            return true;
        }

        #endregion


    }
}
