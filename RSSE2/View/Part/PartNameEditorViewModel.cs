using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RSSE2
{
    class PartNameEditorViewModel : ObservableObject
    {

        public string NewName { get; set; }
        private ICommand _saveCommand;

        private bool? _dialogResult;
        public bool? DialogResult
        {
            get { return _dialogResult; }
            set
            {
                _dialogResult = value;
                OnPropertyChanged();
            }
        }

        public void Save()
        {
            DialogResult = true;
        }

        public ICommand SaveCommand
        {
            get
            {
                if (_saveCommand == null)
                {
                    _saveCommand = new RelayCommand(
                            param => this.Save(),
                            param => this.CanSave()
                        );
                }
                return _saveCommand;
            }
        }

        public bool CanSave()
        {
            return NewName != "";
        }

    }
}
