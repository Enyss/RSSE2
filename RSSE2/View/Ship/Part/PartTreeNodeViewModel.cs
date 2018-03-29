using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RSSE2
{
    public class PartTreeNodeViewModel : ObservableObject
    {
        public PartTreeNodeViewModel Parent { get; set; }
        public PartViewModel Current { get; set; }
        public ObservableCollection<PartTreeNodeViewModel> Children { get; set; }

        public string Name
        {
            get { return Current.Name; }
            set
            {
                Current.Name = value;
                OnPropertyChanged();
            }
        }

        private ICommand _renamePartCommand;

        public PartTreeNodeViewModel(Part part, PartTreeNodeViewModel parent, PartTreeViewModel tree)
        {
            tree.PartsFlat.Add(this);

            Current = new PartViewModel(part, this);

            Parent = parent;

            Children = new ObservableCollection<PartTreeNodeViewModel>();
            foreach (Part child in Current.Part.children)
            {
                Children.Add(new PartTreeNodeViewModel(child, this, tree));
            }
        }

        #region RenamePart Command

        public void RenamePart()
        {

        }

        public ICommand RenamePartCommand
        {
            get
            {
                if (_renamePartCommand == null)
                {
                    _renamePartCommand = new RelayCommand(
                        param => this.RenamePart(),
                        param => this.CanRename()
                    );
                }
                return _renamePartCommand;
            }
        }

        private bool CanRename()
        {
            // Verify command can be executed here
            return true;
        }

        #endregion

    }
}
