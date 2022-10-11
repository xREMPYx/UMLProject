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

        private Box? NewBox { get; set; } = null;
        private RelationType? RelationType { get; set; } = null;
        private Relation? Relation { get; set; } = null;
        public List<Box> Boxes { get; private set; } = new List<Box>();
        public List<Relation> Relations { get; private set; } = new List<Relation>();

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

            foreach (Relation r in Relations)
            {
                r.Draw(g);
            }

            base.Draw(g);
        }

        Box? ActiveBox;
        public override void MouseDown(int x, int y)
        {
            this.ActiveBox = GetBoxInArea(x, y);

            UnselectRelevantBoxes(x, y);

            PushBoxToFront();

            if (this.ActiveBox != null && this.RelationType == null)
            {
                this.ActiveBox.MouseDown(x, y);
            }
            else if (this.ActiveBox != null && this.RelationType != null)
            {
                CreateRelation(x, y);
            }
            else if (this.NewBox != null)
            {
                CreateNewBox(x, y);
            }

            base.MouseDown(x, y);

            UpdateSizeOfPaintingArea();            
        }

        public override void MouseMove(int x, int y)
        {
            MarkHoveredArea(x, y);

            if (this.ActiveBox != null && this.Relation == null)
            {
                this.ActiveBox.MouseMove(x, y);
            }
            else if (this.ActiveBox != null && this.Relation != null)
            {
                this.Relation.UpdateEndLocation(x, y);
            }

            SetMinimalSize();

            base.MouseMove(x, y);
        }

        public void MouseDoubleClick(int x, int y)
        {
            this.ActiveBox = GetBoxInArea(x, y);

            if(this.ActiveBox != null)
            {
                UpdateBox();

                this.ActiveBox.UpdateResizeArrows();
            }
        }

        public override void MouseUp(int x, int y)
        {
            if (this.Relation != null)
            {
                AssignRelationArrow(x, y);
            }

            this.Boxes.ForEach(b => b.ClearMouseState());

            base.MouseUp(x, y);
        }

        //Creates relation
        private void CreateRelation(int x, int y)
        {
            this.Relation = new Association(this.ActiveBox);
            this.Relations.Add(Relation);
            this.Relation.UpdateStartLocation(x, y);
            this.Relation.UpdateEndLocation(x, y);
        }

        //Assigns relation
        private void AssignRelationArrow(int x, int y)
        {
            Box? selected = GetBoxInArea(x, y);

            if (selected != null && selected != this.ActiveBox)
            {
                this.Relation.To = selected;
                this.Relation = null;
                this.RelationType = null;
            }
            else
            {
                this.Relations.Remove(this.Relation);
                this.RelationType = null;
                this.Relation = null;
            }
        }

        //Returns box in area
        private Box? GetBoxInArea(int x, int y)
        {
            return this.Boxes.Where(b => b.IsInArea(x, y) || (b.IsResizeArrowInArea(x, y) && b.IsSelected))
                                .LastOrDefault();
        }

        //Marks current area
        private void MarkHoveredArea(int x, int y)
        {
            this.Boxes.ForEach(b => b.IsInArea(x, y));

            this.Relations.ForEach(r => r.IsInArea(x, y));
        }

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
            BoxForm form = new BoxForm(this.ActiveBox);

            if (form.ShowDialog() == DialogResult.OK)
            {
                this.ActiveBox.Name = form.Box.Name;
                this.ActiveBox.Modifier = form.Box.Modifier;
                this.ActiveBox.Type = form.Box.Type;
                this.ActiveBox.Properties = form.Box.Properties;
                this.ActiveBox.Methods = form.Box.Methods;
                this.ActiveBox.Width = form.Box.Width;
                this.ActiveBox.Height = form.Box.Height;
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
                this.NewBox = null;
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
            this.Relations = this.Relations.Where(r => !(r.From == ActiveBox || r.To == ActiveBox)).ToList();

            this.Boxes = this.Boxes.Where(b => !b.IsSelected).ToList();            
        }

        private void PushBoxToFront()
        {
            if (ActiveBox == null)
                return;

            Box tmp = ActiveBox;
            this.Boxes.Remove(ActiveBox);
            this.Boxes.Add(tmp);
        }

        private void UpdateSizeOfPaintingArea() => PaintingArea.Size = new PaintingAreaSize(this.Width, this.Height);

        public void SelectNewBox(Box box) => this.NewBox = box;

        public void SelectNewRelation(RelationType relation) => this.RelationType = relation;
    }
}
