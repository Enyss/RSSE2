using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSE2
{
    public class Part
    {
        public Dictionary<string, Component> components;
        public string name;
        public string rogName;

        public string parentName;
        public Part parent;
        public List<Part> children;
        
        public Vector3 position;
        public Vector3 rotation;

        public Part()
        {
            components = new Dictionary<string, Component>();
            children = new List<Part>();

            name = "New part";
            rogName = "default";
            parentName = "NONE";
            position = new Vector3();
            rotation = new Vector3();

        }

        public Part( Table table, int id )
        {
            components = new Dictionary<string, Component>();
            children = new List<Part>();

            name = table["Name"];
            rogName = table["Name"];
            parentName = table["ParentTo"];
            position = new Vector3(table["Position"]);
            rotation = new Vector3(table["Rotation"]);


            components.Add("Model", new Model(table));
            components.Add("Physic", new Physic(table));
            if (table["SpecialObjectName"] == "LIGHT")
            {
                components.Add("Light", new Light(table));
            }
        }
    }
}
