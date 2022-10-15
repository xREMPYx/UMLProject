using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMLProject.Components;
using UMLProject.Enums;

namespace UMLProject.Relations
{
    public class Aggregation : Relation
    {
        public Aggregation(Box from) : base(from)
        {
            Point[] points = { new Point(0, 6), new Point(3, 3), new Point(0, 0), new Point(-3, 3) };

            capPath.AddPolygon(points);

            this.Type = RelationType.Aggregation;
        }
    }
}
