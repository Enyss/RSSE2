using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

    using MoonSharp.Interpreter;

namespace RSSE2
{
    class RogLoader
    {
        private Script script;

        public RogLoader()
        {
            script = new Script(CoreModules.Preset_Complete);
        }

        public Ship Load(string filename, string name)
        {
            Ship ship = new Ship();

            string luaTable = File.ReadAllText(filename);

            DynValue dv = script.DoString(luaTable + "\nreturn "
                + name + ","
                + name + "Exterior,"
                + name + "Interior,"
                + name + "Cameras,"
                + name + "Coords;");

            Table baseTable = ToTable(dv.Tuple[0].Table);
            Table exteriorTable = ToTable(dv.Tuple[1].Table);
            Table interiorTable = ToTable(dv.Tuple[2].Table);
            Table camerasTable = ToTable(dv.Tuple[3].Table);
            Table coordsTable = ToTable(dv.Tuple[4].Table);

            AddExteriorTableToShip(interiorTable, ship);

            return ship;
        }

        public Table ToTable(MoonSharp.Interpreter.Table luaTable)
        {
            Table table = new Table();
            
            IEnumerable<DynValue> keys = luaTable.Keys.AsEnumerable();

            foreach ( DynValue key in keys )
            {
                DynValue value = luaTable.Get(key);

                switch(value.Type)
                {
                    case DataType.Table:
                        table[key.String] = ToTable(value.Table);
                        break;
                    case DataType.String:
                        table[key.String] = value.String;
                        break;
                    case DataType.Number:
                        table[key.String] = value.Number;
                        break;
                }
            }

            return table;
        }

        public void AddExteriorTableToShip(Table table, Ship ship)
        {
            table.Remove("Total");
            foreach( KeyValuePair<string,dynamic> e in table)
            {
                int id = Int32.Parse(e.Key.Substring(4));  //start at the end of Mesh
                ship.parts.Add( new Part( e.Value, id)  );
            }

            List<Part> toRemove = new List<Part>();
            foreach( Part part in ship.parts)
            {
                if (part.parentName != "NONE")
                {
                    Part parent = ship.parts.Find(x => x.rogName == part.parentName );
                    if (parent != null)
                    {
                        toRemove.Add(part);
                        parent.children.Add(part);
                        part.parent = parent;
                    }
                }
            }
            ship.parts.RemoveAll(x => toRemove.Contains(x));

        }        
    }
}
