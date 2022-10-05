using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMLProject.Enums;

namespace UMLProject.Components
{
    public abstract class Resizable : Component
    {
        private Dictionary<Arrows, ResizableButton> buttons = new();

        public Resizable()
        {
            int w = this.Width;
            int h = this.Height;

            ResizableButton vertical = new ResizableButton(w / 2 + X, h + Y, (x, y) => this.Height += y);
            ResizableButton horizontal = new ResizableButton(w, h / 2 + Y, (x, y) => this.Width += x);
            ResizableButton combined = new ResizableButton(w + X, h + Y, (x, y) => { this.Width += x; this.Height += y; });

            buttons.Add(Arrows.Vertical, vertical);
            buttons.Add(Arrows.Horizontal, horizontal);
            buttons.Add(Arrows.Combined, combined);
        }

        public override void Draw(Graphics g)
        {            
            if(IsSelected)
                buttons.ToList().ForEach(c => c.Value.Draw(g));            
        }

        public void UpdateResizeArrows()
        {
            int w = this.Width;
            int h = this.Height;

            ResizableButton vertical = buttons[Arrows.Vertical];
            ResizableButton horizontal = buttons[Arrows.Horizontal];
            ResizableButton combined = buttons[Arrows.Combined];

            vertical.UpdateLocation(w / 2, h + Y);
            horizontal.UpdateLocation(w + X, h / 2 + Y);
            combined.UpdateLocation(w + X, h + Y);
        }

        ResizableButton active;

        public void MouseDown(int x, int y)
        {
            active = buttons.Where(b => b.Value.IsInArea(x, y)).First().Value;

            if (active == null)
                return;

            active.MouseDown(x, y);
        }

        public void MouseMove(int x, int y)
        {
            buttons.ToList().ForEach(b => b.Value.IsInArea(x, y));

            if (active == null)
                return;

            active.MouseMove(x, y);
            UpdateResizeArrows();
        }

        public void MouseUp(int x, int y)
        {
            if (active == null)
                return;

            active.MouseUp(x, y);
            UpdateResizeArrows();
        }
    }
}
