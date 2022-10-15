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
            //Point[] points = { new Point(0, 0), new Point(5, -5), new Point(0, -10), new Point(-5, -5) };
            //Point[] points1 = { new Point(0, -1), new Point(4, -5), new Point(0, -9), new Point(-4, -5) };
            Point[] points2 = { new Point(0, 0), new Point(3, -3), new Point(0, -6), new Point(-3, -3) };                        
            Point[] points3 = { new Point(0, -1), new Point(2, -3), new Point(0, -5), new Point(-2, -3) };
            Point[] points4 = { new Point(0, -2), new Point(1, -3), new Point(0, -4), new Point(-1, -3) };

            //capPath.AddPolygon(points);
            //capPath.AddPolygon(points1);
            capPath.AddPolygon(points2);
            capPath.AddPolygon(points3);
            capPath.AddPolygon(points4);

            this.Type = RelationType.Composition;
        }
    }
}
