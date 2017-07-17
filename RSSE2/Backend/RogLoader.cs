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

        public Ship Load(string name)
        {
            Ship ship = new Ship();

            string filename = Application.Instance.Settings.RSFolder 
                + @"Mod\RogSysCM\Ships\" + name + ".rog";

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

            ship.interior = tableToPartList(interiorTable);
            ship.exterior = tableToPartList(exteriorTable);
            ship.name = name;

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

        public List<Part> tableToPartList(Table table)
        {
            List<Part> list = new List<Part>();
            table.Remove("Total");

            foreach( KeyValuePair<string,dynamic> e in table)
            {
                int id = Int32.Parse(e.Key.Substring(4));  //start at the end of Mesh
                list.Add( new Part( e.Value, id)  );
            }

            List<Part> toRemove = new List<Part>();
            foreach( Part part in list)
            {
                if (part.parentName != "NONE")
                {
                    Part parent = list.Find(x => x.rogName == part.parentName );
                    if (parent != null)
                    {
                        toRemove.Add(part);
                        parent.children.Add(part);
                        part.parent = parent;
                    }
                }
            }
            list.RemoveAll(x => toRemove.Contains(x));

            return list;
        }        
    }
}
