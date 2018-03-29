using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSE2
{
    public class ScrubberLocationViewModel : ObservableObject
    {
        private ScrubberLocation _scrubber;
        public ScrubberLocation Scrubber { get { return _scrubber; } }

        public bool Is_SPARE
        {
            get { return Scrubber.is_SPARE; }
            set
            {
                Scrubber.is_SPARE = value;
                OnPropertyChanged();
            }
        }

        public Vector3ViewModel Position { get; }
        public Vector3ViewModel Rotation { get; }

        public ScrubberLocationViewModel( ScrubberLocation scrubber )
        {
            _scrubber = scrubber;
            Position = new Vector3ViewModel(scrubber.position);
            Rotation = new Vector3ViewModel(scrubber.rotation);
        }
    }
}
