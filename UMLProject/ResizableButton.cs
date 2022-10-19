using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMLProject.Components;
using UMLProject.Enums;

namespace UMLProject
{
    public class ResizableButton : Component
    {
        private Action<int, int> func;

        private Pen pen = Pens.Black;

        public ResizableButton(Action<int, int> func, int x, int y)
        { 
            this.Width = 10;
            this.Height = 10;
            this.func = func;

            this.UpdateLocation(x, y);
        }

        public override void Draw(Graphics g)
        {
            g.FillRectangle(Brushes.White, this.X, this.Y, this.Width, this.Height);
            g.DrawRectangle(pen, this.X, this.Y, this.Width, this.Height);
        }

        public bool IsInArea(int x, int y)
        {
            bool result = Enumerable.Range(this.X, this.Width).Contains(x)
                          && Enumerable.Range(this.Y, this.Height).Contains(y);

            pen = result == true ? Pens.DarkBlue : Pens.Black;

            return result;
        }
            

        public void UpdateLocation(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
        
        MouseEventArgs mouseDown;
        public void MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = e;
        }

        MouseEventArgs mouseHover;
        public void MouseHover(object sender, MouseEventArgs e)
        {
            mouseHover = e;
        }

        public void MouseUp(object sender, MouseEventArgs e)
        {
            int x = mouseDown.X - mouseHover.X;
            int y = mouseDown.Y - mouseHover.Y;

            this.func(x, y);
        }
    }
}
