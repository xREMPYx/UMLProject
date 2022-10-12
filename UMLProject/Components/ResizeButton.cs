using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMLProject.Enums;
using UMLProject.Models;

namespace UMLProject.Components
{
    public class ResizeButton : Component
    {
        private Action<int, int> func;
        public MouseState mouseState { get; private set; }

        public ResizeButton(int x, int y, Action<int, int> func)
        {
            this.Width = 10;
            this.Height = 10;

            this.func = func;

            UpdateLocation(x, y);
        }

        public override void Draw(Graphics g)
        {
            if (this.IsSelected == false)
                return;

            g.FillRectangle(Brushes.White, X - Width / 2, Y - Height / 2, Width, Height);
            g.DrawRectangle(IsActivePen, X - Width / 2, Y - Height / 2, Width, Height);
        }

        public void UpdateLocation(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        Location mouseDown;
        public void MouseDown(int x, int y)
        {            
            this.mouseState = MouseState.Down;

            Location location = new Location(x, y);

            this.mouseDown = location;
        }

        public void MouseMove(int x, int y)
        {
            if (mouseState == MouseState.Down)
            {
                Location location = new Location(x, y);

                this.func(x - mouseDown.X, y - mouseDown.Y);
                this.mouseDown = location;
            }
        }

        public void MouseUp(int x, int y)
        {
            this.mouseState = MouseState.Up;
        }

        public override bool IsInArea(int x, int y)
        {
            bool result = Enumerable.Range(X - Width / 2, Width).Contains(x)
                          && Enumerable.Range(Y - Height / 2, Height).Contains(y);

            IsActivePen = result == true ? Pens.DarkBlue : Pens.Black;

            return result;
        }

        public void UpdateFunc(Action<int, int> func) => this.func = func;

        public void ClearMouseState() => mouseState = MouseState.Up;
    }
}
