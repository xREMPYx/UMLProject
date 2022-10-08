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

            ResizableButton vertical = new ResizableButton(w / 2 + X, h + Y, (x, y) =>
            {
                this.Height = this.Height + y < this.MinHeight ? this.MinHeight : this.Height + y;
            });

            ResizableButton horizontal = new ResizableButton(w + X, h / 2 + Y, (x, y) =>
            {
                this.Width = this.Width + x < this.MinWidth ? this.MinWidth : this.Width + x;
            });
            ResizableButton combined = new ResizableButton(w + X, h + Y, (x, y) => 
            {
                this.Height = this.Height + y < this.MinHeight ? this.MinHeight : this.Height + y;
                this.Width = this.Width + x < this.MinWidth ? this.MinWidth : this.Width + x;
            });

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

            vertical.UpdateLocation(w / 2 + X, h + Y);
            horizontal.UpdateLocation(w + X, h / 2 + Y);
            combined.UpdateLocation(w + X, h + Y);
        }

        ResizableButton active;

        public virtual void MouseDown(int x, int y)
        {
            UpdateResizeArrows();

            active = buttons.Where(b => b.Value.IsInArea(x, y)).FirstOrDefault().Value;

            if (active != null)
            {
                active.MouseDown(x, y);
            }
        }

        public virtual void MouseMove(int x, int y)
        {
            UpdateResizeArrows();
            
            buttons.ToList().ForEach(b => b.Value.IsInArea(x, y));

            if (active != null)
            {
                active.MouseMove(x, y);                
            }  
        }

        public virtual void MouseUp(int x, int y)
        {
            UpdateResizeArrows();

            if (active != null)
            {
                active.MouseUp(x, y);
            }           
        }

        public bool IsAnyArrowInLocation(int x, int y)
        {
            bool res = false;

            foreach (var r in buttons.Values)
            {
                res = r.IsInArea(x, y);
            }

            //return true; 

            return res;
        }

        public virtual void ClearMouseState() => buttons.ToList().ForEach(b => b.Value.ClearMouseState());
    }
}
