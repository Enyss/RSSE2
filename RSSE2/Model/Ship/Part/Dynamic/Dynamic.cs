using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSE2
{
    public class Dynamic : Component
    {
        public List<State> states;
        public string function;
        public int functionID;

        public Dynamic( Table table )
        {
            states = new List<State>();

            function = table["Function"];
            functionID = (int)table["FunctionID"];

            int i = 1;
            while( table.ContainsKey("State"+i))
            {
                states.Add(new State(table["State" + i]));
                i++;
            }
        }


        internal static Dynamic GenerateComponent(Table table)
        {
            if (table.ContainsKey("Function"))
            {
                return new Dynamic(table);
            }
            return null;
        }

        public override ComponentViewModel CreateViewModel()
        {
            return new DynamicViewModel(this);
        }

        public override void ToTable(Table table)
        {
            throw new NotImplementedException();
        }
    }
}
