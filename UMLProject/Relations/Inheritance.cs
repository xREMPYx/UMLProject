using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMLProject.Components;
using UMLProject.Enums;

namespace UMLProject.Relations
{
    public class Inheritance : Relation
    {
        public Inheritance(Box from) : base(from)
        {
            this.Type = RelationType.Inheritance;
        }

        public override void Draw(Graphics g)
        {
            throw new NotImplementedException();
        }
    }
}
