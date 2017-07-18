using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RSSE2
{

    public enum Translation { Up, Down, Right, Left, Forward, Backward };
    public enum Rotation { PitchUp, PitchDown, YawRight, YawLeft, RollRight, RollLeft };

    public class View3DViewModel
    {
        #region TranslateCommand 
        private Backend.SceneManager scene = Backend.SceneManager.Instance;

        private ICommand _translateCommand;
        public ICommand TranslateCommand
        {
            get
            {
                if (_translateCommand == null)
                {
                    _translateCommand = new RelayCommand(
                        param => scene.TranslateCamera(0.1f,(Translation)param),
                        param => true
                    );
                }
                return _translateCommand;
            }
        }
        #endregion

        #region RotateCommand 

        private ICommand _rotateCommand;
        public ICommand RotateCommand
        {
            get
            {
                if (_rotateCommand == null)
                {
                    _rotateCommand = new RelayCommand(
                        param => scene.RotateCamera(1,(Rotation)param),
                        param => true
                    );
                }
                return _rotateCommand;
            }
        }

        #endregion

    }
}
