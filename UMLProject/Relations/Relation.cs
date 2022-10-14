using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMLProject.Components;
using UMLProject.Enums;
using UMLProject.Models;

namespace UMLProject.Relations
{
    public abstract class Relation : Resizable
    {
        public RelationType Type { get; set; }
        public int StartX { get; set; }
        public int StartY { get; set; }
        public int MidX { get; set; }
        public int MidY { get; set; }
        public int EndX { get; set; }
        public int EndY { get; set; }
        public bool IsModified { get; set; } = false;
        public Box From { get; set; }
        public Box To { get; set; }
        public string FromText { get; set; } = String.Empty;
        public string ToText { get; set; } = String.Empty;

        protected GraphicsPath capPath = new GraphicsPath();

        protected Pen Pen = new Pen(Brushes.Black, 2) { DashPattern = new float[] { 1 }
    };
        
        public Relation(Box from)
        {
            UpdateResizeFunc((x, y) =>
            {
                IsModified = true;

                PaintingAreaSize size = PaintingArea.Size;

                MidX = size.Width + size.X < MidX + x ? size.Width + size.X : MidX + x;
                MidY = size.Height + size.Y < MidY + y ? size.Height + size.Y : MidY + y;

                MidX = MidX < size.X ? size.X : MidX;
                MidY = MidY < size.Y ? size.Y : MidY;

                this.resizeButton.X = MidX;
                this.resizeButton.Y = MidY;
            });

            this.SetResizeButtonSize(6);
            this.From = from;

            SetResizeButtonUnVisible();

            Pen.DashPattern = new float[] { 1 };
        }

        public override void Draw(Graphics g)
        {
            this.UpdateLocationAccordingly();
            this.UpdateResizeButton();            

            Pen fPen = new Pen(Pen.Brush, Pen.Width);
            Pen sPen = new Pen(Pen.Brush, Pen.Width);

            sPen.DashPattern = Pen.DashPattern;
            fPen.DashPattern = Pen.DashPattern;

            sPen.CustomEndCap = new CustomLineCap(null, capPath);

            Location s = GetStartTextLocation();
            Location e = GetEndTextLocation();

            g.DrawString(FromText, Component.Font, Brushes.Black, s.X, s.Y);
            g.DrawString(ToText, Component.Font, Brushes.Black, e.X, e.Y);
            
            g.DrawLine(fPen, StartX, StartY, MidX, MidY);
            g.DrawLine(sPen, MidX, MidY, EndX, EndY);

            base.Draw(g);
        }

        public override void MouseDown(int x, int y)
        {
            IsSelected = true;

            base.MouseDown(x, y);
        }

        public override void MouseMove(int x, int y)
        {
            base.MouseMove(x, y);
        }

        public override void MouseUp(int x, int y)
        {
            IsSelected = false;

            base.MouseUp(x, y);
        }

        public void Edit()
        {
            RelationForm form = new RelationForm(From, To);

            if (form.ShowDialog() == DialogResult.OK)
            {
                this.FromText = form.From;
                this.ToText = form.To;
            }
        }

        public override void UpdateResizeButton()
        {
            Location l = GetMidLocation();

            if (IsModified)
                return;

            this.resizeButton.UpdateLocation(l.X, l.Y);
            this.MidX = l.X;
            this.MidY = l.Y;
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

            UpdateResizeButton();
        }
        
        public void UpdateEndLocation(Location location)
        {
            if(EndX != location.X)
                this.EndX = location.X;
            if(EndY != location.Y)
                this.EndY = location.Y;

            UpdateResizeButton();
        }

        public void UpdateLocationAccordingly()
        {
            if (IsModified)
                UpdateLocationOfModified();
            else
                UpdateLocationOfUnmodified();
        }

        public override bool IsInArea(int x, int y)
        {
            Pen.Color = IsSelected ? Color.DarkBlue : Color.Black;

            Location current = new(x, y);
            Location s = new(StartX, StartY);
            Location m = new(MidX, MidY);
            Location e = new(EndX, EndY);

            if (!IsInRange(current, s, m) && !IsInRange(current, m, e))
                return false;

            if (!SatisfiesLineEquation(current, s, m) && !SatisfiesLineEquation(current, m, e))
                return false;

            Pen.Color = Color.DarkBlue;

            return true;
        }

        private bool IsInRange(Location current, Location start, Location end)
        {
            int sX = start.X >= end.X ? end.X : start.X;
            int cX = start.X >= end.X ? start.X - end.X : end.X - start.X;

            int sY = start.Y >= end.Y ? end.Y : start.Y;
            int cY = start.Y >= end.Y ? start.Y - end.Y : end.Y - start.Y;

            bool isInrange = Enumerable.Range(sX, cX).Contains(current.X)
                          && Enumerable.Range(sY, cY).Contains(current.Y);

            return isInrange;
        }

        private bool SatisfiesLineEquation(Location current, Location start, Location end)
        {
            int vX = end.X - start.X;
            int vY = end.Y - start.Y;

            int c = vY * start.X - vX * start.Y;

            int lineEquation = (-vY * current.X) + (vX * current.Y) + c;

            return lineEquation > -1000 && lineEquation < 1000;
        }

        private Location GetMidLocation()
        {
            int x = (StartX + EndX) / 2;
            int y = (StartY + EndY) / 2;

            return new Location(x, y);
        }

        private Location GetTopLocation(Box box) => GetCustomBox(box, (b) => new Location(b.X + b.Width / 2, b.Y));
        private Location GetBottomLocation(Box box) => GetCustomBox(box, (b) => new Location(b.X + b.Width / 2, b.Y + b.Height));
        private Location GetLeftLocation(Box box) => GetCustomBox(box, (b) => new Location(b.X, b.Y + b.Height / 2));
        private Location GetRightLocation(Box box) => GetCustomBox(box, (b) => new Location(b.X + b.Width, b.Y + b.Height / 2));
        private Location GetCustomBox(Box box, Func<Box, Location> func) => func(box);

        //Get location for text
        private Location GetStartTextLocation()
        {
            int x = StartX > MidX ? StartX - 25 : StartX + 5;
            int y = StartX > MidY ? StartY - 20 : StartY + 10;

            return new(x, y);
        }

        private Location GetEndTextLocation()
        {
            int x = EndX > MidX ? EndX - 25 : EndX + 5;
            int y = EndY > MidY ? EndY - 20 : EndY + 10;

            return new(x, y);
        }

        //Functions for location updates
        private void UpdateLocationOfUnmodified()
        {
            if (To == null)
                return;

            if (this.From.X > this.To.X)
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

                if (this.To.X < this.From.X + this.From.Width / 2)
                    UpdateEndLocation(GetTopLocation(To));
            }

            if (this.To.Y + this.To.Height < this.From.Y)
            {
                UpdateEndLocation(GetBottomLocation(To));

                if (this.From.X < this.To.X + this.To.Width / 2)
                    UpdateStartLocation(GetTopLocation(From));
            }

            UpdateResizeButton();
        }

        private void UpdateLocationOfModified()
        {
            if (this.From.X + this.From.Width >= this.MidX)
                UpdateStartLocation(GetLeftLocation(From));

            if (this.From.Y >= this.MidY)
                UpdateStartLocation(GetTopLocation(From));

            if (this.From.Y + this.From.Height <= MidY)
                UpdateStartLocation(GetBottomLocation(From));

            if (this.From.X + this.From.Width <= this.MidX)
                UpdateStartLocation(GetRightLocation(From));

            if (this.To.X + this.To.Width >= this.MidX)
                UpdateEndLocation(GetLeftLocation(To));

            if (this.To.Y >= this.MidY)
                UpdateEndLocation(GetTopLocation(To));

            if (this.To.Y + this.To.Height <= MidY)
                UpdateEndLocation(GetBottomLocation(To));

            if (this.To.X + this.To.Width <= this.MidX)
                UpdateEndLocation(GetRightLocation(To));
        }
    }
}
