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
        public List<ShipSystem> shipSystems;
        public string name;

        public bool interiorAvailable;
        public ColorRGB color_EMERlight;
        public Vector3 playerSTART;

        public string pilot_CONTROLS;
        public string pilot_INSTRUMENTS;
        public string pilot_VMS;
        public string pilot_MFD;
        public string pilot_CAW;

        private Table baseTable;
        private Table exteriorTable;
        private Table interiorTable;
        private Table camerasTable;
        private Table coordsTable;

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

            baseTable = new Table(dv.Tuple[0].Table);
            exteriorTable = new Table(dv.Tuple[1].Table);
            interiorTable = new Table(dv.Tuple[2].Table);
            camerasTable = new Table(dv.Tuple[3].Table);
            coordsTable = new Table(dv.Tuple[4].Table);

            interior = tableToPartList(interiorTable);
            exterior = tableToPartList(exteriorTable);
            shipSystems = tableToSystemList(baseTable);

            interiorAvailable = (int)baseTable["InteriorAvailable"] == 1;
            color_EMERlight = new ColorRGB(baseTable["color_EMERlight"]);
            playerSTART = new Vector3(baseTable["playerSTART"]);

            pilot_CONTROLS = baseTable["pilot_CONTROLS"];
            pilot_INSTRUMENTS = baseTable["pilot_INSTRUMENTS"];
            pilot_VMS = baseTable["pilot_VMS"];
            pilot_MFD = baseTable["pilot_MFD"];
            pilot_CAW = baseTable["pilot_CAW"];
        }

        private List<ShipSystem> tableToSystemList(Table table)
        {
            List<ShipSystem> systems = new List<ShipSystem>();
            systems.Add(new BMSSystem(table));
            systems.Add(new ECSSystem(table));
            systems.Add(new LSSSystem(table));
            systems.Add(new TMSSystem(table));
            return systems;
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
            Table ship = new Table();
            ship.Add(name, baseTable);

            exteriorTable = new Table();
            for (int i = 1; i<= exterior.Count; i++)
            {
                exteriorTable.Add("Mesh" + i, exterior[i-1].ToTable() );
            }

            ship.Add(name + "Exterior", exteriorTable);
            ship.Add(name + "Interior", interiorTable);
            ship.Add(name + "Cameras", camerasTable);
            ship.Add(name + "Coords", coordsTable);
            string s = ship.ToLuaString(0);

            File.WriteAllText(Application.Instance.Settings.RSFolder + @"Mod\RogSysCM\Ships\" + name + ".ROG", s);

            foreach(Material mat in MaterialManager.Instance.MaterialList)
            {
                mat.ToFile(Application.Instance.Settings.RSFolder + @"Mod\RogSysCM\Ships\" + name + @"\");
            }
        }
    }
}
