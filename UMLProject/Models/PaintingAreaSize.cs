using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMLProject.Models
{
    public struct PaintingAreaSize
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int X { get; set; } = 5;
        public int Y { get; set; } = 5;

        public PaintingAreaSize(int w, int h)
        {
            this.Width = w;
            this.Height = h;
        }

        public void Update(int w, int h)
        {
            this.Width = w;
            this.Height = h;
        }
    }
}
