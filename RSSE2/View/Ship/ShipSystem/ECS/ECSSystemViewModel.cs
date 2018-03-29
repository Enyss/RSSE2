using System.Collections.ObjectModel;

namespace RSSE2
{
    public class ECSSystemViewModel : ShipSystemViewModel
    {
        
        public ObservableCollection<ECSBusViewModel> Buses { get; set; }

        public override string Name { get { return "ECS"; } }

        public double PWRpercent
        {
            get { return ((ECSSystem)ShipSystem).PWRpercent; }
            set
            {
                ((ECSSystem)ShipSystem).PWRpercent = value;
                OnPropertyChanged();
            }
        }
        public double MASSpercent
        {
            get { return ((ECSSystem)ShipSystem).MASSpercent; }
            set
            {
                ((ECSSystem)ShipSystem).MASSpercent = value;
                OnPropertyChanged();
            }
        }

        public ECSSystemViewModel(ECSSystem ecs) : base(ecs)
        {
            Buses = new ObservableCollection<ECSBusViewModel>();
            foreach(ECSBus bus in ecs.Buses)
            {
                Buses.Add(new ECSBusViewModel(bus));
            }
        }
    }
}