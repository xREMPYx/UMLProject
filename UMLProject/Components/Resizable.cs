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
        private ResizableButton combined { get; set; }

        public Resizable()
        {
            int w = this.Width;
            int h = this.Height;

            combined = new ResizableButton(w + X, h + Y, (x, y) => 
            {
                this.Height = this.Height + y < this.MinHeight ? this.MinHeight : this.Height + y;
                this.Width = this.Width + x < this.MinWidth ? this.MinWidth : this.Width + x;
            });
        }

        public override void Draw(Graphics g)
        {            
            if(IsSelected)
                combined.Draw(g);            
        }

        public void UpdateResizeArrows()
        {
            int w = this.Width;
            int h = this.Height;

            combined.UpdateLocation(w + X, h + Y);
        }

        ResizableButton active;

        public virtual void MouseDown(int x, int y)
        {
            UpdateResizeArrows();

            active = combined.IsInArea(x, y) ? combined : null;

            if (active != null)
            {
                active.MouseDown(x, y);
            }
        }

        public virtual void MouseMove(int x, int y)
        {
            UpdateResizeArrows();

            combined.IsInArea(x, y);

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

        public bool IsResizeActive() => combined.mouseState == MouseState.Down;

        public bool IsResizeArrowInArea(int x, int y) => combined.IsInArea(x, y);

        public virtual void ClearMouseState() => combined.ClearMouseState();
    }
}
