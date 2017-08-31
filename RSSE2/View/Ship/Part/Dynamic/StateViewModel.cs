using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSE2
{
    public class StateViewModel : ObservableObject
    {
        private State state;
        public State State { get { return state; } }

        public Vector3ViewModel Position { get; set; }
        public Vector3ViewModel Rotation { get; set; }
        public Vector3ViewModel Scale { get; set; }

        public List<string> MotionTypeList { get { return State.MotionTypeList.Key1s.ToList(); } }

        public string MotionType
        {
            get { return State.MotionTypeList.GetValueByKey2(State.motionType); }
            set
            {
                State.motionType = State.MotionTypeList.GetValueByKey1(value);
                OnPropertyChanged();
            }
        }

        public int StartPause
        {
            get { return State.startPause; }
            set
            {
                State.startPause = value;
                OnPropertyChanged();
            }
        }

        public int Rate
        {
            get { return State.rate; }
            set
            {
                State.rate = value;
                OnPropertyChanged();
            }
        }

        public bool Visible
        {
            get { return State.visible; }
            set
            {
                State.visible = value;
                OnPropertyChanged();
            }
        }

        public bool CollisionEnabled
        {
            get { return State.collisionEnabled; }
            set
            {
                State.collisionEnabled = value;
                OnPropertyChanged();
            }
        }
        
        public string TriggerFunction
        {
            get { return State.triggerFunction; }
            set
            {
                State.triggerFunction = value;
                OnPropertyChanged();
            }
        }
        
        public StateViewModel(State state)
        {
            this.state = state;
            Position = new Vector3ViewModel(State.position);
            Rotation = new Vector3ViewModel(State.rotation);
            Scale = new Vector3ViewModel(State.scale);
        }

    }
}
