using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMLProject.Enums;

namespace UMLProject.Models
{
    public class Method : BoxElement
    {
        public override string ToString()
        {
            string modifier = Access == AccessModifier.Private 
                ? "-" 
                : Access == AccessModifier.Public 
                ? "+" : "#";


            return $"{modifier}{Name}() : {ReturnType}";
        }
    }
}
