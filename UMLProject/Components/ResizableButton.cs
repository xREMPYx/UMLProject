using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMLProject.Enums;

namespace UMLProject.Components
{
    public class ResizableButton : Component
    {
        private Action<int, int> func;

        private Pen pen = Pens.Black;

        private MouseState mouseState;

        public ResizableButton(int x, int y, Action<int, int> func)
        {
            Width = 6;
            Height = 6;

            this.func = func;

            UpdateLocation(x, y);
        }

        public override void Draw(Graphics g)
        {
            if (IsVisible == false)
                return;

            g.FillRectangle(Brushes.White, X - Width, Y - Height, Width, Height);
            g.DrawRectangle(pen, X - Width, Y - Height, Width, Height);
        }

        public bool IsInArea(int x, int y)
        {
            bool result = Enumerable.Range(X - Width, Width).Contains(x)
                          && Enumerable.Range(Y - Height, Height).Contains(y);

            pen = result == true ? Pens.DarkBlue : Pens.Black;

            return result;
        }

        public void UpdateLocation(int x, int y)
        {
            X = x;
            Y = y;
        }

        Location mouseDown;
        public void MouseDown(int x, int y)
        {
            mouseState = MouseState.Down;

            Location location = new Location()
            {
                X = x,
                Y = y
            };
            mouseDown = location;
        }

        //Location mouseHover;
        public void MouseMove(int x, int y)
        {
            if (mouseState == MouseState.Up)
                return;

            Location location = new Location()
            {
                X = x,
                Y = y
            };
            
            func(x - mouseDown.X, y - mouseDown.Y);
            mouseDown = location;
        }

        public void MouseUp(int x, int y)
        {
            mouseState = MouseState.Up;
        }
    }
}
