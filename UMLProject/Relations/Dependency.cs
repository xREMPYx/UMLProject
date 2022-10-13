using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMLProject.Components;
using UMLProject.Enums;

namespace UMLProject.Relations
{
    public class Dependency : Relation
    {
        public Dependency(Box from) : base(from)
        {
            capPath.AddLine(-5, -5, 0, 0);
            capPath.AddLine(0, 0, 5, -5);

            this.Type = RelationType.Dependency;

            this.Pen.DashPattern = new float[] { 3.0F, 3.0F };
        }
    }
}
