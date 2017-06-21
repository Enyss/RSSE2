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
        private Part _part;
        public Part Part { get { return _part; } }

        public PartTreeNodeViewModel Parent { get; set; }
        public PartViewModel Current { get; set; }
        public ObservableCollection<PartTreeNodeViewModel> Children { get; set; }

        public string Name
        {
            get { return _part.name; }
            set
            {
                _part.name = value;
                OnPropertyChanged();
            }
        }

        private ICommand _renamePartCommand;

        public PartTreeNodeViewModel(Part part, PartTreeNodeViewModel parent)
        {
            _part = part;
            Parent = parent;

            Current = new PartViewModel(_part);

            Children = new ObservableCollection<PartTreeNodeViewModel>();
            foreach (Part child in _part.children)
            {
                Children.Add(new PartTreeNodeViewModel(child, this));
            }

        }

        #region RenamePart Command

        public void RenamePart()
        {
            /* Not MVVM ! */
            PartNameEditorViewModel windowViewModel= new PartNameEditorViewModel();
            windowViewModel.NewName = Name;
            PartNameEditorView window = new PartNameEditorView();
            window.DataContext = windowViewModel;
            bool result = (bool)window.ShowDialog();

            if (result)
            {
                Name = windowViewModel.NewName;
            }
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
