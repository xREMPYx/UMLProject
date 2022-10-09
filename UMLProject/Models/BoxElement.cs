using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMLProject.Enums;

namespace UMLProject.Models
{
    public abstract class BoxElement
    {
        public string Name { get; set; }
        public AccessModifier Modifier { get; set; }
        public string ReturnType { get; set; }
    }
}
