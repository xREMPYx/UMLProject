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
            this.Width = 400;
            this.Height = 250;

            UpdateResizeArrows();
        }

        public override void Draw(Graphics g)
        {
            g.FillRectangle(this.backColorBrush, this.X, this.Y, this.Width, this.Height);
            base.Draw(g);
        }

        public void Update()
        {
            
        }
    }
}
