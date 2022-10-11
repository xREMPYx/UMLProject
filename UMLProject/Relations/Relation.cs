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
        protected Pen Pen = new Pen(Brushes.Black, 2);

        public abstract void Draw(Graphics g);
        
        public Relation(Box from)
        {
            this.From = from;
        }

        public void UpdateStartLocation(int x, int y)
        {
            if (StartX != x)
                this.StartX = x;
            if (StartY != y)
                this.StartY = y;
        }
        
        public void UpdateStartLocation(Location location)
        {
            if (StartX != location.X)
                this.StartX = location.X;
            if (StartY != location.Y)
                this.StartY = location.Y;
        }

        public void UpdateEndLocation(int x, int y)
        {
            if (EndX != x)
                this.EndX = x;
            if (EndY != y)
                this.EndY = y;
        }
        
        public void UpdateEndLocation(Location location)
        {
            if(EndX != location.X)
                this.EndX = location.X;
            if(EndY != location.Y)
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

            if (this.From.Y + this.From.Height < this.To.Y)
            {
                UpdateStartLocation(GetBottomLocation(From));

                if(this.To.X < this.From.X + this.From.Width / 2)
                    UpdateEndLocation(GetTopLocation(To));
            }

            if (this.To.Y + this.To.Height < this.From.Y)
            {
                UpdateEndLocation(GetBottomLocation(To));

                if (this.From.X < this.To.X + this.To.Width / 2)
                    UpdateStartLocation(GetTopLocation(From));
            }
        }

        public bool IsInArea(int x, int y)
        {
            Pen.Color = Color.Black;
            
            int sX = StartX > EndX ? EndX : StartX;
            int cX = StartX > EndX ? StartX - EndX : EndX - StartX;

            int sY = StartY > EndY ? EndY : StartY;
            int cY = StartY > EndY ? StartY - EndY : EndY - StartY;

            bool isInrange = Enumerable.Range(sX, cX).Contains(x)
                          && Enumerable.Range(sY, cY).Contains(y);

            if (!isInrange)
                return false;            

            int vX = EndX - StartX;
            int vY = EndY - StartY;

            int c = vY * StartX - vX * StartY;

            int lineEquation = (-vY * x) + (vX * y) + c;
            
            bool isOnLine = lineEquation > -450 && lineEquation < 450;            

            if (!isOnLine)
                return false;

            Pen.Color = Color.Blue;

            return true;
        }

        private Location GetTopLocation(Box box) => GetCustomBox(box, (b) => new Location(b.X + b.Width / 2, b.Y));
        private Location GetBottomLocation(Box box) => GetCustomBox(box, (b) => new Location(b.X + b.Width / 2, b.Y + b.Height));
        private Location GetLeftLocation(Box box) => GetCustomBox(box, (b) => new Location(b.X, b.Y + b.Height / 2));
        private Location GetRightLocation(Box box) => GetCustomBox(box, (b) => new Location(b.X + b.Width, b.Y + b.Height / 2));

        private Location GetCustomBox(Box box, Func<Box, Location> func) => func(box);
        

    }
}
