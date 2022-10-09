using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMLProject.Enums;
using UMLProject.Models;

namespace UMLProject.Components
{
    public class PaintingArea : Resizable
    {
        private Component selected = null;

        private SolidBrush backColorBrush = new SolidBrush(Color.FromArgb(224, 224, 224));

        private List<Box> boxes = new List<Box>();

        public static PaintingAreaSize Size;

        public PaintingArea()
        {
            this.X = 5;
            this.Y = 5;
            this.Width = 480;
            this.Height = 270;
            this.MinWidth = 160;
            this.MinHeight = 90;

            Size = new PaintingAreaSize(Width, Height);

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
            Box active = boxes
                .Where(b => b.IsInArea(x, y) || (b.IsAnyArrowInLocation(x, y) && b.IsSelected))
                .LastOrDefault();

            boxes.Where(b => !b.IsInArea(x, y))
                .ToList()
                .ForEach(b => b.SetUnSelected());

            if (active != null)
            {
                active.MouseDown(x, y);
            }

            if (selected != null)
            {
                BoxForm form = new BoxForm(x, y);

                if (form.ShowDialog() == DialogResult.OK)
                {
                    boxes.Add(form.Box);
                    selected = null;
                }
            }

            base.MouseDown(x, y);

            Size = new PaintingAreaSize(Width, Height);
        }

        public override void MouseMove(int x, int y)
        {
            Box active = boxes.Where(b => b.IsInArea(x, y) || b.IsAnyArrowInLocation(x,y))
                .LastOrDefault();

            if (active != null)
                active.MouseMove(x, y);

            SizeF s = SizeF.Empty;

            foreach (Box b in boxes)
            {
                int w = b.X + b.Width;

                int h = b.Y + b.Height;

                if (w > s.Width)
                    s.Width = w;

                if (h > s.Height)
                    s.Height = h;
            }

            this.MinWidth = (int)s.Width;
            this.MinHeight = (int)s.Height;            

            base.MouseMove(x, y);
        }

        public void MouseDoubleClick(int x, int y)
        {
            Box active = boxes.Where(b => b.IsInArea(x, y))
                .LastOrDefault();

            if(active != null)
            {
                BoxForm form = new BoxForm(active);

                if (form.ShowDialog() == DialogResult.OK)
                {
                    active.Name = form.Box.Name;
                    active.Access = form.Box.Access;
                    active.Type = form.Box.Type;
                    active.Properties = form.Box.Properties;
                    active.Methods = form.Box.Methods;
                    active.Width = form.Box.Width;
                    active.Height = form.Box.Height;
                }

                active.UpdateResizeArrows();
            }
        }

        public override void MouseUp(int x, int y)
        {
            boxes.ForEach(b => b.ClearMouseState());

            base.MouseUp(x, y);
        }

        public void SetSelected(Component component) => selected = component;
    }
}
