using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMLProject.Components;
using UMLProject.Enums;
using UMLProject.Models;

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

        public void UpdateStartLocation(int x, int y)
        {
            this.StartX = x;
            this.StartY = y;
        }
        
        public void UpdateStartLocation(Location location)
        {
            this.StartX = location.X;
            this.StartY = location.Y;
        }

        public void UpdateEndLocation(int x, int y)
        {
            this.EndX = x;
            this.EndY = y;
        }
        
        public void UpdateEndLocation(Location location)
        {
            this.EndX = location.X;
            this.EndY = location.Y;
        }

        public void UpdateLocationAccordingly()
        {
            if (To == null)
                return;

            if(this.From.X > this.To.X)
            {
                UpdateStartLocation(GetLeftLocation(From));
                UpdateEndLocation(GetRightLocation(To));
            }

            if (this.From.X < this.To.X)
            {
                UpdateStartLocation(GetRightLocation(From));
                UpdateEndLocation(GetLeftLocation(To));
            }

            //if (this.From.Y > this.To.Y)
            //{
            //    UpdateStartLocation(GetLeftLocation(From));
            //    UpdateEndLocation(GetRightLocation(To));
            //}
        }

        private Location GetTopLocation(Box box) => GetCustomBox(box, (b) => new Location(b.X + b.Width / 2, b.Y));
        private Location GetBottomLocation(Box box) => GetCustomBox(box, (b) => new Location(b.X + b.Width / 2, b.Y + b.Height));
        private Location GetLeftLocation(Box box) => GetCustomBox(box, (b) => new Location(b.X, b.Y + b.Height / 2));
        private Location GetRightLocation(Box box) => GetCustomBox(box, (b) => new Location(b.X + b.Width, b.Y + b.Height / 2));

        private Location GetCustomBox(Box box, Func<Box, Location> func) => func(box);
        

    }
}
