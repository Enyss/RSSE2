using MoonSharp.Interpreter;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSE2
{
    public class ShipHullList
    {
        public List<string> shipHullFile;

        public ShipHullList(string filename)
        {
            Load(filename);
        }

        public void Load(string filename)
        {
            shipHullFile = new List<string>();

            string luaTable = File.ReadAllText(filename);
            DynValue dv = Application.Instance.Lua.DoString(luaTable + "\n return " + "ShipHull;");
            Table shipHullTable = new Table(dv.Table);

            for(int i=1; i<= shipHullTable["Total"]; i++)
            {
                shipHullFile.Add(shipHullTable["Ship" + i]["Name"]);
            }
        }
        

        public void SaveToFile(string filename)
        {
            Table hullList = new Table();
            hullList["Total"] = shipHullFile.Count();

            for(int i=1; i<= shipHullFile.Count(); i++)
            {
                Table ship = new Table();
                ship["Name"] = shipHullFile[i - 1];
                hullList["Ship" + i] = ship;
            }

            Table t = new Table();
            t["ShipHull"] = hullList;

            string s = t.ToLuaString(0);
            File.WriteAllText(filename, s);
        }

        public void AddNewShipHull(string filename)
        {
            if (shipHullFile.Contains(filename))
                return;

            shipHullFile.Add(filename);
        }
    }
}
