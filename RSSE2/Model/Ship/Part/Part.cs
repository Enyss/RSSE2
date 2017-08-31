using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace RSSE2
{
    public enum ObjectType { HATCH, HULLexterior, HULLinterior, INSTALL, LIGHT, NONE, PIVOT, SEAT, SEATrestraint, SWITCH, TRIGGER }

    public class Part
    {
        public static BiDictionary<ObjectType, string> Type = new BiDictionary<RSSE2.ObjectType, string>
        {
            { ObjectType.HATCH, "HATCH" }, { ObjectType.HULLexterior,"HULLexterior" }, { ObjectType.HULLinterior,"HULLinterior" },
            { ObjectType.INSTALL,"INSTALL" }, { ObjectType.LIGHT,"LIGHT" }, { ObjectType.NONE,"NONE" },
            { ObjectType.PIVOT,"PIVOT" }, { ObjectType.SEAT,"SEAT" }, { ObjectType.SEATrestraint,"SEATrestraint" },
            { ObjectType.SWITCH,"SWITCH" }, { ObjectType.TRIGGER, "TRIGGER" }
        };

        public Dictionary<string, Component> components;
        public string name;

        public string parentName;
        public Part parent;
        public List<Part> children;

        public ObjectType type;

        public Vector3 position;
        public Vector3 rotation;

        public Part()
        {
            components = new Dictionary<string, Component>();
            children = new List<Part>();

            name = "default";
            parentName = "NONE";
            position = new Vector3();
            rotation = new Vector3();

        }

        public Part(Table table, int id)
        {
            components = new Dictionary<string, Component>();
            children = new List<Part>();

            name = table["Name"];
            parentName = table["ParentTo"];

            type = GetObjectType(table);

            position = new Vector3(table["Position"]);
            rotation = new Vector3(table["Rotation"]);

            GenerateComponents(table);
        }

        private void GenerateComponents(Table table)
        {
            Light light = Light.GenerateComponent(table);
            if (light != null)
            {
                components.Add("Light", light);
            }

            Model model = Model.GenerateComponent(table);
            if (model != null)
            {
                components.Add("Model", model);
            }

            Physic physic = Physic.GenerateComponent(table);
            if (physic != null)
            {
                components.Add("Physic", physic);
            }

            Dynamic dynamic = Dynamic.GenerateComponent(table);
            if (dynamic != null)
            {
                components.Add("Dynamic", dynamic);
            }
        }

        private ObjectType GetObjectType(Table table)
        {
            if (Type.ContainsKey2(table["SpecialObjectName"]))
            {
                return Type.GetValueByKey2(table["SpecialObjectName"]);
            }
            return ObjectType.NONE;
        }

        internal Table ToTable()
        {
            Table table = new Table();

            table.Add("Name", name);
            table.Add("ParentTo", parent == null ? "NONE" : parent.name);
            table.Add("Position", position.ToTable());
            table.Add("Rotation", rotation.ToTable());
            table.Add("SpecialObjectName", Type.GetValueByKey1(type));

            foreach (KeyValuePair<string, Component> pair in components)
            {
                pair.Value.ToTable(table);
            }

            return table;
        }
    }
}
