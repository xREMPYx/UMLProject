using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMLProject.Enums;

namespace UMLProject
{
    public class ResizableButton : Button
    {
        private Action<int, int> func;

        public ResizableButton(Arrows direction, Action<int, int> func, int x, int y)
        {
            Cursor cursor;

            if (direction == Arrows.Vertical)
                cursor = Cursors.SizeNS;
            else if (direction == Arrows.Horizontal)
                cursor = Cursors.SizeWE;
            else
                cursor = Cursors.SizeNWSE;

            this.Cursor = cursor;

            this.Width = 10;
            this.Height = 10;
            this.func = func;

            this.UpdateLocation(x, y);

            //this.BringToFront();
            //this.Visible = true;
        }

        public void UpdateLocation(int x, int y)
        {            
            this.Location = new Point(x, y);
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
