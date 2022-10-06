using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMLProject.Enums;
using UMLProject.Models;

namespace UMLProject.Components
{
    public class ResizableButton : Component
    {
        private Action<int, int> func;

        private MouseState mouseState;

        public ResizableButton(int x, int y, Action<int, int> func)
        {
            this.Width = 6;
            this.Height = 6;

            this.func = func;

            UpdateLocation(x, y);
        }

        public override void Draw(Graphics g)
        {
            if (this.IsVisible == false)
                return;

            g.FillRectangle(Brushes.White, X, Y, Width, Height);
            g.DrawRectangle(IsActivePen, X, Y, Width, Height);
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

        //Location mouseHover;
        public void MouseMove(int x, int y)
        {
            if (mouseState == MouseState.Up)
                return;

            Location location = new Location(x, y);

            this.func(x - mouseDown.X, y - mouseDown.Y);
            this.mouseDown = location;
        }

        public void MouseUp(int x, int y)
        {
            this.mouseState = MouseState.Up;
        }
    }
}
