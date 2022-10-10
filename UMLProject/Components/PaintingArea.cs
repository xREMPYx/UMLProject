using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMLProject.Enums;
using UMLProject.Models;
using UMLProject.Relations;

namespace UMLProject.Components
{
    public class PaintingArea : Resizable
    {
        public static SolidBrush BackColorBrush { get; } = new SolidBrush(Color.FromArgb(224, 224, 224));
        public static PaintingAreaSize Size { get; set; }

        //

        private Box? selected { get; set; } = null;
        private RelationType? relationType { get; set; } = null;
        private Relation? relation { get; set; } = null;
        public List<Box> Boxes { get; private set; } = new List<Box>();     

        public PaintingArea()
        {
            this.X = 5;
            this.Y = 5;
            this.Width = 480;
            this.Height = 270;
            this.MinWidth = 160;
            this.MinHeight = 90;

            PaintingArea.Size = new PaintingAreaSize(this.Width, this.Height);

            UpdateResizeArrows();
        }

        public override void Draw(Graphics g)
        {
            g.FillRectangle(PaintingArea.BackColorBrush, this.X, this.Y, this.Width, this.Height);

            foreach (Box b in Boxes)
            {
                b.Draw(g);
            }

            base.Draw(g);
        }

        Box? active;
        public override void MouseDown(int x, int y)
        {
            this.active = GetBoxInArea(x, y);

            UnselectRelevantBoxes(x, y);

            if (this.active != null && this.relation == null)
            {
                this.active.MouseDown(x, y);
            }
            else if (this.active != null && this.relation != null)
            {
                //should add line
                RelationType type = (RelationType)this.relationType;

                

                this.active.From.Add(RelationGetter.GetRelation(type, active));
                
            }
            else if (this.selected != null)
            {
                CreateNewBox(x, y);
            }

            base.MouseDown(x, y);

            PaintingArea.Size = new PaintingAreaSize(this.Width, this.Height);
        }

        public override void MouseMove(int x, int y)
        {
            MarkHoveredArea(x, y);

            if (this.active != null)
            {
                this.active.MouseMove(x, y);
            }                

            SetMinimalSize();

            base.MouseMove(x, y);
        }

        public void MouseDoubleClick(int x, int y)
        {
            this.active = GetBoxInArea(x, y);

            if(this.active != null)
            {
                UpdateBox();

                this.active.UpdateResizeArrows();
            }
        }

        public override void MouseUp(int x, int y)
        {
            this.Boxes.ForEach(b => b.ClearMouseState());

            base.MouseUp(x, y);
        }

        //Returns box in area
        private Box? GetBoxInArea(int x, int y)
        {
            return this.Boxes.Where(b => b.IsInArea(x, y) || (b.IsResizeArrowInArea(x, y) && b.IsSelected))
                                .LastOrDefault();
        }

        //Marks current area
        private void MarkHoveredArea(int x, int y) => this.Boxes.ForEach(b => b.IsInArea(x, y));

        //Unselect relevant boxes
        private void UnselectRelevantBoxes(int x, int y)
        {
            this.Boxes.Where(b => !b.IsInArea(x, y))
                    .ToList()
                    .ForEach(b => b.SetUnSelected());
        }

        //Updates box
        private void UpdateBox()
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
        }

        //Creates new box
        private void CreateNewBox(int x, int y)
        {
            BoxForm form = new BoxForm(x, y);

            if (form.ShowDialog() == DialogResult.OK)
            {
                Location max = form.Box.GetMaxLocation();

                form.Box.X = form.Box.X > max.X ? max.X : form.Box.X;
                form.Box.Y = form.Box.Y > max.Y ? max.Y : form.Box.Y;

                this.Boxes.Add(form.Box);
                this.selected = null;
            }
        }

        //Sets minimal size of painting area accroding to box locations and sizes
        private void SetMinimalSize()
        {
            SizeF min = SizeF.Empty;

            foreach (Box b in Boxes)
            {
                int w = b.X + b.Width;

                int h = b.Y + b.Height;

                if (w > min.Width)
                    min.Width = w;

                if (h > min.Height)
                    min.Height = h;
            }

            this.MinWidth = (int)min.Width;
            this.MinHeight = (int)min.Height;
        }

        //Deletes selected box
        public void Delete()
        {
            this.Boxes = this.Boxes.Where(b => !b.IsSelected).ToList();
        }

        public void SelectNewBox(Box box) => this.selected = box;

        public void SelectNewRelation(RelationType relation) => this.relationType = relation;
    }
}
