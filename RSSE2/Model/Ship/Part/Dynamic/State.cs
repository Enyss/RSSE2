using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSE2
{
    public enum MotionType { alt_LINEAR, EVENTDRIVEN, LINEAR, STEP }

    public class State
    {
        public static BiDictionary<string, MotionType> MotionTypeList = new BiDictionary<string, MotionType>
        {
            { "alt_LINEAR", MotionType.alt_LINEAR }, {"EVENTDRIVEN", MotionType.EVENTDRIVEN },
            { "LINEAR",MotionType.LINEAR }, {"STEP", MotionType.STEP }
        };

        public MotionType motionType;
	    public Vector3 position;
        public Vector3 rotation;
        public Vector3 scale;
        public int startPause;
        public int rate;
        public bool visible;
        public bool collisionEnabled;
        public string triggerFunction;

        public State(Table table)
        {
            motionType = MotionTypeList.GetValueByKey1(table["MotionType"]);
            position = new Vector3(table["Position"]);
            rotation = new Vector3(table["Rotation"]);
            scale = new Vector3(table["Scale"]);
            startPause = (int)table["StartPause"];
            rate = (int)table["Rate"];
            visible = table["Visible"] == 1;
            collisionEnabled = table["CollisionEnabled"] == 1;
            triggerFunction = table["TriggerFunction"];

        }
    }
}
