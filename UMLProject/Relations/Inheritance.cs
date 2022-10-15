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
            Point[] points = { new Point(-5, -5), new Point(5, -5), new Point(0, 0) };

            capPath.AddPolygon(points);

            this.Type = RelationType.Inheritance;
        }
    }
}
