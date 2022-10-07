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
        public List<Method> Methods { get; set; }
        public List<Property> Properties { get; set; }
        private MouseState mouseState { get; set; } = MouseState.Up;

        public Box(string name, AccessModifier modifier, BoxType type, List<Method> methods, List<Property> properties)
        {
            this.Name = name;
            this.Access = modifier;
            this.Type = type;
            this.Methods = methods;
            this.Properties = properties;
            this.Width = 100;
            this.Height = 100;

            UpdateResizeArrows();
        }

        public override void Draw(Graphics g)
        {
            g.DrawRectangle(IsActivePen, this.X, this.Y, this.Width, this.Height);
                            
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
        }

        public override void MouseMove(int x, int y)
        {
            UpdateResizeArrows();

            base.MouseMove(x, y);

            this.IsInArea(x, y);

            if(this.mouseState == MouseState.Down)
            {
                if (!this.IsAnyArrowInLocation(x, y))
                {
                    this.X -= mouseDown.X - x;
                    this.Y -= mouseDown.Y - y;

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
    }
}
