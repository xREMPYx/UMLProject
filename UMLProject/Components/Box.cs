using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMLProject.Enums;
using UMLProject.Models;

namespace UMLProject.Components
{
    public class Box : Resizable
    {
        public string Name { get; set; }
        public AccessModifier Access { get; set; }
        public BoxType Type { get; set; }
        public List<Method> Methods { get; set; } = new List<Method>();
        public List<Property> Properties { get; set; } = new List<Property>();
        private MouseState mouseState { get; set; } = MouseState.Up;
        private TextBuilder textBuilder { get; set; }

        public Box() { }

        public Box(string name, AccessModifier modifier, BoxType type, List<Method> methods, List<Property> properties)
        {
            this.Name = name;
            this.Access = modifier;
            this.Type = type;
            this.Methods = methods;
            this.Properties = properties;

            textBuilder = new TextBuilder(this);

            SizeF min = Measure.MeasureString(textBuilder.GetTextFormMeasurement());

            this.Width = (int)min.Width + 20;
            this.Height = (int)min.Height + 20;            

            this.MinWidth = (int)min.Width;
            this.MinHeight = (int)min.Height;

            UpdateResizeArrows();
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

            UpdateResizeArrows();

            base.MouseMove(x, y);

            this.IsInArea(x, y);

            if (this.mouseState == MouseState.Down)
            {
                if (!this.IsResizeArrowInArea(x, y) && !this.IsResizeActive())
                {
                    this.X -= mouseDown.X - x;
                    this.Y -= mouseDown.Y - y;

                    Location max = this.MaxLocation();
                    Location min = this.MinLocation();

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
            UpdateResizeArrows();

            base.MouseUp(x, y);

            this.mouseState = MouseState.Up;
        }

        public override void ClearMouseState()
        {
            base.ClearMouseState();
            mouseState = MouseState.Up;
        }

        public Location MaxLocation()
        {
            PaintingAreaSize s = PaintingArea.Size;

            return new Location(s.Width + s.X - Width, s.Height + s.Y - Height);
        }

        public Location MinLocation() => new Location(5, 5);

        public void SetUnSelected() => this.IsSelected = false;

        private void UpdateMinSize()
        {
            textBuilder = new TextBuilder(this);

            SizeF min = Measure.MeasureString(textBuilder.GetTextFormMeasurement());

            this.MinWidth = (int)min.Width;
            this.MinHeight = (int)min.Height;
        }
    }
}
