using MoonSharp.Interpreter;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSE2
{
    public class NewHull
    {

        private void AddHullToList(string shipname)
        {

            string filename = Application.Instance.Settings.RSFolder + @"Mod\RogSysCM\Ships\ShipHullList.ROG";

            string luaTable = File.ReadAllText(filename);

            DynValue dv = Application.Instance.Lua.DoString(luaTable + "\n return " + "ShipHull;");

            Table shipHullTable = new Table(dv.Table);


            bool isAlreadyPresent = false;
            foreach( KeyValuePair<string,dynamic> value in shipHullTable)
            {
                if (value.Value is Table && ((Table)value.Value).ContainsValue(shipname))
                {
                    isAlreadyPresent = true;
                    break;
                }
            }

            if (!isAlreadyPresent)
            {
                int count = shipHullTable["Total"];
                count++;
                shipHullTable["Total"] = count;
                shipHullTable["ship" + count]["Name"] = shipname;

                string s = shipHullTable.ToLuaString(0);

                File.WriteAllText(Application.Instance.Settings.RSFolder + @"Mod\RogSysCM\Ships\ShipHullList.ROG", s);
            }

        }

    }
}
