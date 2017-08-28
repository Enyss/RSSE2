using MoonSharp.Interpreter;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSE2
{
    public class Ship
    {
        public List<Part> interior;
        public List<Part> exterior;
        public string name;

        public Ship(string name)
        {
            interior = new List<Part>();
            exterior = new List<Part>();
            this.name = name;
        }

        public void LoadFromFile(string filename)
        {

            string luaTable = File.ReadAllText(filename);

            DynValue dv = Application.Instance.Lua.DoString(luaTable + "\nreturn "
                + name + ","
                + name + "Exterior,"
                + name + "Interior,"
                + name + "Cameras,"
                + name + "Coords;");

            Table baseTable = new Table(dv.Tuple[0].Table);
            Table exteriorTable = new Table(dv.Tuple[1].Table);
            Table interiorTable = new Table(dv.Tuple[2].Table);
            Table camerasTable = new Table(dv.Tuple[3].Table);
            Table coordsTable = new Table(dv.Tuple[4].Table);

            /* Test stuff */
            Table ship = new Table();
            ship.Add(name, baseTable);
            ship.Add(name + "Exterior", exteriorTable);
            ship.Add(name + "Interior", interiorTable);
            ship.Add(name + "Cameras", camerasTable);
            ship.Add(name + "Coords", coordsTable);
            string s = ship.ToLuaString(0);

            File.WriteAllText(name + "Test.ROG", s);

            /* End Test Stuff */

            interior = tableToPartList(interiorTable);
            exterior = tableToPartList(exteriorTable);
        }

        public List<Part> tableToPartList(Table table)
        {
            List<Part> list = new List<Part>();
            table.Remove("Total");

            foreach (KeyValuePair<string, dynamic> e in table)
            {
                int id = Int32.Parse(e.Key.Substring(4));  // get the mesh number
                list.Add(new Part(e.Value, id));
            }

            // link the parent/children
            foreach (Part part in list)
            {
                if (part.parentName != "NONE")
                {
                    Part parent = list.Find(p => p.name == part.parentName);

                    parent.children.Add(part);
                    part.parent = parent;
                }
            }

            return list;
        }

        public void SaveToFile()
        {
        }
    }
}
