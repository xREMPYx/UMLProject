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

        protected Pen Pen = new Pen(Brushes.Black, 2) { DashPattern = new float[] { 1 } };
        
        public Relation(Box from = null)
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

            //SetResizeButtonUnVisible();

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

            UpdateResizeButton();

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

        public void DoubleClick(int x, int y)
        {
            if(IsResizeArrowInArea(x, y))
            {
                this.IsModified = false;
                Location l = GetMidLocation();
                this.MidX = l.X;
                this.MidY = l.Y;
                this.UpdateLocationAccordingly();
            }
            else
            {
                Edit();
            }
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

            this.resizeButton.UpdateLocation(MidX, MidY);            

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

            if (To != null)
                SetResizeButtonVisible();
            else
                SetResizeButtonUnVisible();

            return true;
        }

        private bool IsInRange(Location current, Location start, Location end)
        {
            int sX = start.X >= end.X ? end.X : start.X;
            int eX = start.X >= end.X ? start.X - end.X : end.X - start.X;

            int sY = start.Y >= end.Y ? end.Y : start.Y;
            int eY = start.Y >= end.Y ? start.Y - end.Y : end.Y - start.Y;

            int t = 50;

            sX -= t;
            eX += t;

            sY -= t;
            eY += t;

            bool isInrange = Enumerable.Range(sX, eX).Contains(current.X)
                          && Enumerable.Range(sY, eY).Contains(current.Y);

            return isInrange;
        }

        private bool SatisfiesLineEquation(Location current, Location start, Location end)
        {
            int vX = end.X - start.X;
            int vY = end.Y - start.Y;

            int c = vY * start.X - vX * start.Y;

            int lineEquation = (-vY * current.X) + (vX * current.Y) + c;

            int t = 600;

            return lineEquation > -t && lineEquation < t;
        }

        private Location GetMidLocation()
        {
            int x = (StartX + EndX) / 2;
            int y = (StartY + EndY) / 2;

            return new Location(x, y);
        }

        private Location GetTopLocation(Box box, bool isEnd)
        {
            int pad = RelationGetter.GetRelationPadding(Type, isEnd);

            return new Location(box.X + box.Width / 2, box.Y - pad);
        }
        private Location GetBottomLocation(Box box, bool isEnd)
        {
            int pad = RelationGetter.GetRelationPadding(Type, isEnd);

            return new Location(box.X + box.Width / 2, box.Y + box.Height + pad);
        }

        private Location GetLeftLocation(Box box, bool isEnd)
        {
            int pad = RelationGetter.GetRelationPadding(Type, isEnd);

            return new Location(box.X - pad, box.Y + box.Height / 2);
        }
        private Location GetRightLocation(Box box, bool isEnd)
        {
            int pad = RelationGetter.GetRelationPadding(Type, isEnd);

            return new Location(box.X + box.Width + pad, box.Y + box.Height / 2);
        }


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
                UpdateStartLocation(GetLeftLocation(From, false));
                UpdateEndLocation(GetRightLocation(To, true));
            }

            if (this.From.X < this.To.X)
            {
                UpdateStartLocation(GetRightLocation(From, false));
                UpdateEndLocation(GetLeftLocation(To, true));
            }

            if (this.From.Y + this.From.Height < this.To.Y)
            {
                UpdateStartLocation(GetBottomLocation(From, false));

                if (this.To.X < this.From.X + this.From.Width / 2)
                    UpdateEndLocation(GetTopLocation(To, true));
            }

            if (this.To.Y + this.To.Height < this.From.Y)
            {
                UpdateEndLocation(GetBottomLocation(To, true));

                if (this.From.X < this.To.X + this.To.Width / 2)
                    UpdateStartLocation(GetTopLocation(From, false));
            }

            UpdateResizeButton();
        }

        private void UpdateLocationOfModified()
        {
            if (this.From.X + this.From.Width >= this.MidX)
                UpdateStartLocation(GetLeftLocation(From, false));

            if (this.From.Y >= this.MidY && MidX > this.From.X)
                UpdateStartLocation(GetTopLocation(From, false));

            if (this.From.Y + this.From.Height > this.MidY && MidX > this.From.X + this.From.Width)
                UpdateStartLocation(GetRightLocation(From, false));

            if (this.From.Y + this.From.Height <= MidY)
                UpdateStartLocation(GetBottomLocation(From, false));
            
            if (this.To.X + this.To.Width >= this.MidX)
                UpdateEndLocation(GetLeftLocation(To, true));

            if (this.To.Y >= this.MidY && MidX > this.To.X)
                UpdateEndLocation(GetTopLocation(To, true));

            if (this.To.Y + this.To.Height > this.MidY && MidX > this.To.X + this.To.Width)
                UpdateEndLocation(GetRightLocation(To, true));

            if (this.To.Y + this.To.Height <= MidY)
                UpdateEndLocation(GetBottomLocation(To, true));            
        }
    }
}
