using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMLProject.Components;
using UMLProject.Enums;

namespace UMLProject.Models.DataModels
{
    public class BoxData
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Name { get; set; }
        public AccessModifier Modifier { get; set; }
        public BoxType Type { get; set; }
        public List<Method> Methods { get; set; } = new List<Method>();
        public List<Property> Properties { get; set; } = new List<Property>();

        public BoxData()
        {

        }

        public BoxData(Box box)
        {
            this.X = box.X;
            this.Y = box.Y;
            this.Width = box.Width;
            this.Height = box.Height;
            this.Name = box.Name;
            this.Modifier = box.Modifier;
            this.Type = box.Type;
            this.Methods = box.Methods;
            this.Properties = box.Properties;
        }
    }
}
