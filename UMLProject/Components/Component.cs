using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMLProject.Components
{
    public abstract class Component
    {
        public int X { get; set; } = 0;
        public int Y { get; set; } = 0;
        public int Width { get; set; } = 0;
        public int Height { get; set; } = 0;
        public bool IsSelected { get; set; }
        public virtual void Draw(Graphics g) { }
        public virtual void Move() { }

        public void UpdateSize(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }
    }
}
