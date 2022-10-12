using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMLProject.Components;
using UMLProject.Enums;

namespace UMLProject.Relations
{
    public class Association : Relation
    {
        public Association(Box from) : base(from)
        {
            capPath.AddLine(-5, -5, 5, -5);
            capPath.AddLine(-5, -5, 0, 0);
            capPath.AddLine(0, 0, 5, -5);

            this.Type = RelationType.Association;
        }
    }
}
