using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMLProject.Components
{
    public abstract class Component
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int MaxWidth { get; set; }
        public int MaxHeight { get; set; }
        public int MinWidth { get; set; }
        public int MinHeight { get; set; }
        public bool IsSelected { get; set; } = true;
        protected Pen IsActivePen { get; set; } = Pens.Black;
        public static Font Font { get; set; } = new Font("Arial", 9);

        public virtual void Draw(Graphics g) { }
        public virtual void Move() { }

        public void UpdateSize(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }

        public virtual void SetLocation(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public virtual bool IsInArea(int x, int y)
        {
            bool result = Enumerable.Range(X/* - Width*/, Width).Contains(x)
                          && Enumerable.Range(Y /*- Height*/, Height).Contains(y);

            IsActivePen = result == true ? Pens.DarkBlue : Pens.Black;

            if (IsSelected)
                IsActivePen = Pens.DarkBlue;

            return result;
        }
    }
}
