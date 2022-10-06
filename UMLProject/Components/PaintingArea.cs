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
        private Component selected;

        private SolidBrush backColorBrush = new SolidBrush(Color.FromArgb(224, 224, 224));

        private List<Box> boxes = new List<Box>();

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

            foreach (Box b in boxes)
            {
                b.Draw(g);
            }

            base.Draw(g);
        }

        public override void MouseDown(int x, int y)
        {
            Add(x, y);

            boxes.ForEach(b => b.MouseDown(x, y));

            
            base.MouseDown(x, y);
        }

        public override void MouseMove(int x, int y)
        {
            boxes.ForEach(b => b.MouseMove(x, y));

            base.MouseMove(x, y);
        }

        public override void MouseUp(int x, int y)
        {
            boxes.ForEach(b => b.MouseUp(x, y));

            base.MouseUp(x, y);
        }

        public void SetSelected(Component component) => selected = component;

        public void Add(int x, int y)
        {
            Box b = new Box("Krabice", AccessModifier.Public, BoxType.Abstract, new List<Models.Method>(), new());
            b.X = x;
            b.Y = y;
            boxes.Add(b);
        }
    }
}
