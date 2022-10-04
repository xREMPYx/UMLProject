using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMLProject.Enums;

namespace UMLProject.Components
{
    public class PaintingArea : Component
    {
        private List<ResizableButton> buttons;

        private SolidBrush backColorBrush = new SolidBrush(Color.FromArgb(224, 224, 224));

        public PaintingArea()
        {
            this.X = 10;
            this.Y = 10;
            this.Width = 500;
            this.Height = 300;

            buttons = new List<ResizableButton>()
            {
                new ResizableButton(Arrows.Vertical, (x,y) => this.Width += x, 500, 155),

                new ResizableButton(Arrows.Horizontal, (x,y) => this.Height += y, 255, 305),

                new ResizableButton(Arrows.Combined, (x,y) => { this.Width += x; this.Height += y; }, 500, 300)
            };
        }

        public override void Draw(Graphics g)
        {
            g.FillRectangle(this.backColorBrush, this.X, this.Y, this.Width, this.Width);
        }
    }
}
