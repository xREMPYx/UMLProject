using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMLProject.Enums;
using UMLProject.Models;

namespace UMLProject.Components
{
    public class Box : Resizable
    {
        public string Name { get; set; }
        public AccessModifier Access { get; set; }
        public BoxType Type { get; set; }
        public List<Method> Methods { get; set; }
        public List<Property> Properties { get; set; }
    }
}
