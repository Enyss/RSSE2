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
        public Dictionary<string, Component> components;
        public string name;
        public string rogName;

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
        }

        private ObjectType GetObjectType(Table table)
        {
            switch (table["SpecialObjectName"])
            {
                case "HATCH":
                    return ObjectType.HATCH;
                case "HULLexterior":
                    return ObjectType.HULLexterior;
                case "HULLinterior":
                    return ObjectType.HULLinterior;
                case "INSTALL":
                    return type = ObjectType.INSTALL;
                case "LIGHT":
                    return ObjectType.LIGHT;
                case "NONE":
                    return ObjectType.NONE;
                case "PIVOT":
                    return ObjectType.PIVOT;
                case "SEAT":
                    return ObjectType.SEAT;
                case "SEATrestraint":
                    return ObjectType.SEATrestraint;
                case "SWITCH":
                    return ObjectType.SWITCH;
                case "TRIGGER":
                    return ObjectType.TRIGGER;
            }

            return ObjectType.NONE;
        }
    }
}
