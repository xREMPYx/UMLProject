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
        public ResizeButton resizeButton { get; private set; }

        public Resizable()
        {
            int w = this.Width;
            int h = this.Height;

            resizeButton = new ResizeButton(w + X, h + Y, Resize);

            void Resize(int x, int y)
            {
                this.Height = this.Height + y < this.MinHeight ? this.MinHeight : this.Height + y;
                this.Width = this.Width + x < this.MinWidth ? this.MinWidth : this.Width + x;
            }
        }

        public override void Draw(Graphics g)
        {            
            if(IsSelected)
                resizeButton.Draw(g);
        }

        public virtual void UpdateResizeButton()
        {
            int w = this.Width;
            int h = this.Height;

            resizeButton.UpdateLocation(w + X, h + Y);
        }

        ResizeButton? active;

        public virtual void MouseDown(int x, int y)
        {
            UpdateResizeButton();

            active = resizeButton.IsInArea(x, y) ? resizeButton : null;

            if (active != null)
            {
                active.MouseDown(x, y);
            }
        }

        public virtual void MouseMove(int x, int y)
        {
            UpdateResizeButton();

            resizeButton.IsInArea(x, y);

            if (active != null)
            {
                active.MouseMove(x, y);                
            }  
        }

        public virtual void MouseUp(int x, int y)
        {
            UpdateResizeButton();

            if (active != null)
            {
                active.MouseUp(x, y);
            }           
        }

        protected void UpdateResizeFunc(Action<int, int> func) => this.resizeButton.UpdateFunc(func);

        public bool IsResizeActive() => resizeButton.mouseState == MouseState.Down;

        public bool IsResizeArrowInArea(int x, int y) => resizeButton.IsInArea(x, y);

        public virtual void ClearMouseState() => resizeButton.ClearMouseState();

        public void SetResizeButtonUnVisible() => resizeButton.IsSelected = false;
        public void SetResizeButtonVisible() => resizeButton.IsSelected = true;

        protected void SetResizeButtonSize(int s)
        {
            resizeButton.Width = s;
            resizeButton.Height = s;
        }
    }
}
