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
            Point[] points = { new Point(-3, 0), new Point(3, 0), new Point(0, 3) };

            capPath.AddPolygon(points);

            this.Type = RelationType.Implementation;

            this.Pen.DashPattern = new float[] { 3.0F, 3.0F };
        }
    }
}
