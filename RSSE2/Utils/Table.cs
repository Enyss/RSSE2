using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoonSharp.Interpreter;
using System.Globalization;

namespace RSSE2
{
    public class Table : Dictionary<string, dynamic>
    {
        public Table() : base() { }

        public Table(MoonSharp.Interpreter.Table luaTable) : base()
        {
            IEnumerable<DynValue> keys = luaTable.Keys.AsEnumerable();

            foreach (DynValue key in keys)
            {
                DynValue value = luaTable.Get(key);

                switch (value.Type)
                {
                    case DataType.Table:
                        this.Add( key.String, new Table(value.Table) );
                        break;
                    case DataType.String:
                        this.Add(key.String, value.String);
                        break;
                    case DataType.Number:
                        this.Add(key.String, value.Number);
                        break;
                }
            }
        }

        public string ToLuaString(int lvl)
        {
            string s = "";

            foreach( KeyValuePair<string, dynamic> pair in this)
            {
                s += tab(lvl) + pair.Key + " = ";

                if( pair.Value is Table)
                {
                    s += "{\n";
                    s += pair.Value.ToLuaString(lvl + 1);
                    s += tab(lvl) + (lvl==0? "}\n" : "},\n");
                }
                else if ( pair.Value is string)
                {
                    s += "\"" + pair.Value + "\",\n";
                }
                else
                {
                    s += pair.Value.ToString("G", CultureInfo.InvariantCulture) + ",\n";
                }
            }

            return s;
        }

        private string tab(int n)
        {
            string s = "";
            for (int i = 0; i < n; i++)
            {
                s += "    ";
            }
            return s;
        }
    }
}
