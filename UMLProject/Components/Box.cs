using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMLProject.Enums;
using UMLProject.Models;
using UMLProject.Relations;
using UMLProject.Utils;

namespace UMLProject.Components
{
    public class Box : Resizable
    {
        public string Name { get; set; }
        public AccessModifier Modifier { get; set; }
        public BoxType Type { get; set; }
        public List<Method> Methods { get; set; } = new List<Method>();
        public List<Property> Properties { get; set; } = new List<Property>();
        public List<Relation> From { get; set; } = new List<Relation>();
        public List<Relation> To { get; set; } = new List<Relation>();
        private MouseState mouseState { get; set; } = MouseState.Up;
        private TextBuilder textBuilder { get; set; }

        public Box() { }

        public Box(string name, AccessModifier modifier, BoxType type, List<Method> methods, List<Property> properties)
        {
            this.Name = name;
            this.Modifier = modifier;
            this.Type = type;
            this.Methods = methods;
            this.Properties = properties;

            textBuilder = new TextBuilder(this);

            SizeF min = Measure.MeasureString(textBuilder.GetTextFormMeasurement());

            this.Width = (int)min.Width + 20;
            this.Height = (int)min.Height + 20;            

            this.MinWidth = (int)min.Width;
            this.MinHeight = (int)min.Height;

            UpdateResizeButton();
            UpdateResizeFunc(Resize);
        }

        public override void Draw(Graphics g)
        {            
            g.FillRectangle(Brushes.White, X, Y, Width, Height);
            g.DrawRectangle(IsActivePen, X, Y, Width, Height);            

            g.DrawString(textBuilder.GetHeader(), Font, Brushes.Black, X, Y);

            SizeF h = Measure.MeasureString(textBuilder.GetHeader());

            int hY = Y + (int)h.Height;

            g.DrawLine(Pens.Black, X, hY, X + Width, hY);

            g.DrawString(textBuilder.GetProperties(), Font, Brushes.Black, X, hY + 2);

            SizeF p = Measure.MeasureString(textBuilder.GetProperties());

            int pY = Y + (int)h.Height + (int)p.Height + 2;

            g.DrawLine(Pens.Black, X, pY, X + Width, pY);

            g.DrawString(textBuilder.GetMethods(), Font, Brushes.Black, X, pY);

            base.Draw(g);
        }

        Location mouseDown;
        public override void MouseDown(int x, int y)
        {
            base.MouseDown(x, y);

            this.mouseState = MouseState.Down;

            Location location = new Location()
            {
                X = x,
                Y = y
            };

            mouseDown = location;

            IsSelected = true;
        }

        public override void MouseMove(int x, int y)
        {
            UpdateMinSize();

            UpdateResizeButton();

            base.MouseMove(x, y);

            this.IsInArea(x, y);

            if (this.mouseState == MouseState.Down)
            {
                if (!this.IsResizeArrowInArea(x, y) && !this.IsResizeActive())
                {
                    this.X -= mouseDown.X - x;
                    this.Y -= mouseDown.Y - y;

                    Location max = this.GetMaxLocation();
                    Location min = this.GetMinLocation();

                    if (this.X > max.X)
                        X = max.X;

                    if (this.Y > max.Y)
                        Y = max.Y;

                    if (this.X < min.X)
                        X = min.X;

                    if (this.Y < min.Y)
                        Y = min.Y;

                    mouseDown = new Location(x, y);
                }
            }            
        }

        public override void MouseUp(int x, int y)
        {
            UpdateResizeButton();

            base.MouseUp(x, y);

            this.mouseState = MouseState.Up;
        }

        public override void ClearMouseState()
        {
            base.ClearMouseState();
            mouseState = MouseState.Up;
        }

        public Location GetMaxLocation()
        {
            PaintingAreaSize s = PaintingArea.Size;

            return new Location(s.Width + s.X - Width, s.Height + s.Y - Height);
        }

        public Location GetMinLocation() => new Location(5, 5);

        private void UpdateMinSize()
        {
            textBuilder = new TextBuilder(this);

            SizeF min = Measure.MeasureString(textBuilder.GetTextFormMeasurement());

            this.MinWidth = (int)min.Width;
            this.MinHeight = (int)min.Height;
        }

        //Updated func for resize
        private void Resize(int x, int y)
        {
            int tmpW = this.Width;
            int tmpH = this.Height;

            int w = this.Width + x < this.MinWidth ? this.MinWidth : this.Width + x;
            int h = this.Height + y < this.MinHeight ? this.MinHeight : this.Height + y;
            
            this.Width = w;
            this.Height = h;

            PaintingAreaSize size = PaintingArea.Size;

            if(X + Width > (int)size.Width + size.X)
            {
                this.Width = tmpW;
            }

            if (Y + Height > (int)size.Height + size.Y)
            {
                this.Height = tmpH;
            }
        }
    }
}
