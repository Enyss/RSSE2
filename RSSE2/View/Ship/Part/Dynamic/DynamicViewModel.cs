using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RSSE2
{
    public class DynamicViewModel : ComponentViewModel
    {
        public Dynamic Model {  get { return (Dynamic)_component; } }

        public ObservableDictionnary<int, StateViewModel> States { get; set; }

        public string Function
        {
            get { return Model.function; }
            set
            {
                Model.function = value;
                OnPropertyChanged();
            }
        }

        public int FunctionID
        {
            get { return Model.functionID; }
            set
            {
                Model.functionID = value;
                OnPropertyChanged();
            }
        }

        private StateViewModel activeState;
        public StateViewModel ActiveState
        {
            get { return activeState; }
            set
            {
                activeState = value;
                OnPropertyChanged();
            }
        }

        private ICommand _setActiveStateCommand;
        public ICommand SetActiveStateCommand
        {
            get
            {
                if (_setActiveStateCommand == null)
                {
                    _setActiveStateCommand = new RelayCommand(
                        param => this.SetActiveState(param as StateViewModel),
                        param => true
                    );
                }
                return _setActiveStateCommand;
            }
        }

        private void SetActiveState(StateViewModel state)
        {
            if (state.Active)
            {
                if (ActiveState != null)
                {
                    ActiveState.Active = false;
                }
                ActiveState = state;
            }
            else
            {
                ActiveState = null;
            }
        }

        public DynamicViewModel(Dynamic dynamic)
        {
            _component = dynamic;

            States = new ObservableDictionnary<int, StateViewModel>();
            int i = 1;
            foreach(State state in Model.states)
            {
                States.Add(i,new StateViewModel(state));
                i++;
            }
        }
    }
}
