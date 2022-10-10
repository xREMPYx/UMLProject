using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMLProject.Components;
using UMLProject.Enums;

namespace UMLProject.Relations
{
    public abstract class Relation
    {
        public RelationType Type { get; set; }
        public int StartX { get; set; }
        public int StartY { get; set; }
        public int EndX { get; set; }
        public int EndY { get; set; }
        public Box From { get; set; }
        public Box To { get; set; }
        public static Pen GetPen() => new Pen(Brushes.Black, 2);

        public abstract void Draw(Graphics g);
        
        public Relation(Box from)
        {
            this.From = from;
        }

        public void InitLocation(int x, int y)
        {
            this.StartX = x;
            this.StartY = y;
        }

        public void UpdateLocation(int x, int y)
        {
            this.EndX = x;
            this.EndY = y;
        }
    }
}
