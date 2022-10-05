using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMLProject.Enums;

namespace UMLProject.Models
{
    public class Method
    {
        public string Name { get; set; }
        public AccessModifier Access { get; set; }
        public string ReturnType { get; set; }

        public override string ToString()
        {
            string s = Access == AccessModifier.Private 
                ? "-" 
                : Access == AccessModifier.Public 
                ? "+" : "#";

            return $"{Name}() : {s}";
        }
    }
}
