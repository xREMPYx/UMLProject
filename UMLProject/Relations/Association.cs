﻿using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMLProject.Relations
{
    public class Association : Relation
    {
        public Association(int sX, int sY) : base(sX, sY)
        {
            this.Type = Enums.RelationType.Association;
        }

        public override void Draw(Graphics g)
        {
            using (GraphicsPath capPath = new GraphicsPath())
            {
                // A triangle
                //capPath.AddLine(-10, 0, 10, 0);
                capPath.AddLine(-10, 0, 0, 10);
                capPath.AddLine(0, 10, 10, 0);

                Pen p = Relation.GetPen();

                p.CustomEndCap = new CustomLineCap(null, capPath);

                g.DrawLine(p, StartX, StartY, EndX, EndY);
            };

            g.DrawLine(Relation.GetPen(), StartX, StartY, EndX, EndY);
        }
    }
}