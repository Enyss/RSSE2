using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSE2
{
    public class TextureViewModel : ObservableObject
    {
        private Texture _texture;
        public Texture Texture { get { return _texture; } }

        #region Properties

        public string Filename
        {
            get { return _texture.filename; }
            set
            {
                _texture.filename = value;
                OnPropertyChanged();
                OnPropertyChanged("Name");
            }
        }

        public string Name
        {
            get
            {
                string name = _texture.filename.Split(new char[] { '\\', '/' }).Last();
                return name;
            }
        }

        #endregion

        public TextureViewModel()
        {
            _texture = new Texture();
        }

        public TextureViewModel(Texture texture)
        {
            _texture = texture;
        }

    }
}
