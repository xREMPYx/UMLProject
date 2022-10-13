using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMLProject.Components;
using UMLProject.Enums;

namespace UMLProject.Relations
{
    public class Implementaion : Relation
    {
        public Implementaion(Box from) : base(from)
        {
            capPath.AddLine(-5, -5, 5, -5);
            capPath.AddLine(-5, -5, 0, 0);
            capPath.AddLine(0, 0, 5, -5);

            this.Type = RelationType.Implementation;

            this.Pen.DashPattern = new float[] { 3.0F, 3.0F };
        }
    }
}
