using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMLProject.Components;
using UMLProject.Enums;

namespace UMLProject.Relations
{
    public class Composition : Relation
    {
        public Composition(Box from) : base(from)
        {
            capPath.StartFigure();
            capPath.AddLine(-5, -5, 0, 0);
            capPath.AddLine(0, 0, 5, -5);
            capPath.AddLine(-5, -5, 0, -10);
            capPath.AddLine(5, -5, 0, -10);
            capPath.CloseFigure();

            this.Type = RelationType.Composition;
        }
    }
}
