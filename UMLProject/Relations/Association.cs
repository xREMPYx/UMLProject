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

            using (GraphicsPath capPath = new GraphicsPath())
            {
                // A triangle
                capPath.AddLine(-5, 0, 5, 0);
                capPath.AddLine(-5, 0, 0, 5);
                capPath.AddLine(0, 5, 5, 0);

                Pen p = Pen;

                p.CustomEndCap = new CustomLineCap(null, capPath);

                g.DrawLine(p, StartX, StartY, EndX, EndY);
            };
        }
    }
}
