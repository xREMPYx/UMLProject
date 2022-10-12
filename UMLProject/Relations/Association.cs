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
            this.Type = RelationType.Association;
        }

        public override void Draw(Graphics g)
        {
            this.UpdateLocationAccordingly();

            Pen pen = new Pen(Pen.Brush, Pen.Width);
            Pen pen1 = new Pen(Pen.Brush, Pen.Width);

            Pen penA = new Pen(PaintingArea.BackColorBrush, pen.Width);

            GraphicsPath capPath = new GraphicsPath();
            capPath.AddLine(-5, -5, 5, -5);
            capPath.AddLine(-5, -5, 0, 0);
            capPath.AddLine(0, 0, 5, -5);

            pen.CustomEndCap = new CustomLineCap(null, capPath);

            g.DrawLine(pen1, StartX, StartY, MidX, MidY);
            g.DrawLine(pen, MidX, MidY, EndX, EndY);

            g.DrawLine(penA, EndX - 4, EndY - 4, EndX - 1, EndY - 1);

            base.Draw(g);
        }
    }
}
