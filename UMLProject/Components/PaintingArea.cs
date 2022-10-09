﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMLProject.Enums;
using UMLProject.Models;

namespace UMLProject.Components
{
    public class PaintingArea : Resizable
    {
        private Component? selected = null;

        private SolidBrush backColorBrush = new SolidBrush(Color.FromArgb(224, 224, 224));

        private List<Box> boxes = new List<Box>();

        public static PaintingAreaSize Size;

        public PaintingArea()
        {
            this.X = 5;
            this.Y = 5;
            this.Width = 480;
            this.Height = 270;
            this.MinWidth = 160;
            this.MinHeight = 90;

            PaintingArea.Size = new PaintingAreaSize(Width, Height);

            UpdateResizeArrows();
        }

        public override void Draw(Graphics g)
        {
            g.FillRectangle(this.backColorBrush, this.X, this.Y, this.Width, this.Height);

            foreach (Box b in boxes)
            {
                b.Draw(g);
            }

            base.Draw(g);
        }

        Box? active;
        public override void MouseDown(int x, int y)
        {
            this.active = this.boxes
                .Where(b => b.IsInArea(x, y) || (b.IsResizeArrowInArea(x, y) && b.IsSelected))
                .LastOrDefault();

            this.boxes.Where(b => !b.IsInArea(x, y))
                .ToList()
                .ForEach(b => b.SetUnSelected());

            if (this.active != null)
            {
                this.active.MouseDown(x, y);
            }

            if (this.selected != null)
            {
                BoxForm form = new BoxForm(x, y);

                if (form.ShowDialog() == DialogResult.OK)
                {
                    Location max = form.Box.GetMaxLocation();

                    form.Box.X = form.Box.X > max.X ? max.X : form.Box.X;
                    form.Box.Y = form.Box.Y > max.Y ? max.Y : form.Box.Y;

                    this.boxes.Add(form.Box);
                    this.selected = null;
                }
            }

            base.MouseDown(x, y);

            PaintingArea.Size = new PaintingAreaSize(this.Width, this.Height);
        }

        public override void MouseMove(int x, int y)
        {
            this.boxes.ForEach(b => b.IsInArea(x, y));

            if (this.active != null)
                this.active.MouseMove(x, y);

            SizeF s = SizeF.Empty;

            foreach (Box b in boxes)
            {
                int w = b.X + b.Width;

                int h = b.Y + b.Height;

                if (w > s.Width)
                    s.Width = w;

                if (h > s.Height)
                    s.Height = h;
            }

            this.MinWidth = (int)s.Width;
            this.MinHeight = (int)s.Height;            

            base.MouseMove(x, y);
        }

        public void MouseDoubleClick(int x, int y)
        {
            this.active = this.boxes.Where(b => b.IsInArea(x, y))
                .LastOrDefault();

            if(this.active != null)
            {
                BoxForm form = new BoxForm(this.active);

                if (form.ShowDialog() == DialogResult.OK)
                {
                    this.active.Name = form.Box.Name;
                    this.active.Modifier = form.Box.Modifier;
                    this.active.Type = form.Box.Type;
                    this.active.Properties = form.Box.Properties;
                    this.active.Methods = form.Box.Methods;
                    this.active.Width = form.Box.Width;
                    this.active.Height = form.Box.Height;
                }

                this.active.UpdateResizeArrows();
            }
        }

        public override void MouseUp(int x, int y)
        {
            this.boxes.ForEach(b => b.ClearMouseState());

            base.MouseUp(x, y);
        }

        public void Delete()
        {
            this.boxes = this.boxes.Where(b => !b.IsSelected).ToList();
        }

        public void SetSelected(Component component) => this.selected = component;
    }
}
