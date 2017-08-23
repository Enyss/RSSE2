using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoonSharp.Interpreter;

namespace RSSE2
{
    public class Table : Dictionary<string, dynamic>
    {
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
    }
}
