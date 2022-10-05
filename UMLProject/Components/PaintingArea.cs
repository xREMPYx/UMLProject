using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMLProject.Enums;

namespace UMLProject.Components
{
    public class PaintingArea : Resizable
    {
        private SolidBrush backColorBrush = new SolidBrush(Color.FromArgb(224, 224, 224));

        public PaintingArea()
        {
            this.X = 5;
            this.Y = 5;
            this.Width = 480;
            this.Height = 270;
            this.MinWidth = 160;
            this.MinHeight = 90;

            UpdateResizeArrows();
        }

        public override void Draw(Graphics g)
        {
            g.FillRectangle(this.backColorBrush, this.X, this.Y, this.Width, this.Height);
            base.Draw(g);
        }

        public override void MouseDown(int x, int y)
        {
            base.MouseDown(x, y);
        }

        public override void MouseMove(int x, int y)
        {
            base.MouseMove(x, y);
        }

        public override void MouseUp(int x, int y)
        {
            base.MouseUp(x, y);
        }
    }
}
