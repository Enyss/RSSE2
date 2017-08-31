using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSE2
{
    public class DynamicViewModel : ComponentViewModel
    {
        public Dynamic Model {  get { return (Dynamic)_component; } }

        public ObservableCollection<StateViewModel> States { get; set; }

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

        public DynamicViewModel(Dynamic dynamic)
        {
            _component = dynamic;

            States = new ObservableCollection<StateViewModel>();
            foreach(State state in Model.states)
            {
                States.Add(new StateViewModel(state));
            }
        }
    }
}
