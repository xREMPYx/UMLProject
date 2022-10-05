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
        public bool IsVisible { get; set; } = true;
        public bool IsSelected { get; set; } = true;
        
        public virtual void Draw(Graphics g) { }
        public virtual void Move() { }

        public void UpdateSize(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }
    }
}
