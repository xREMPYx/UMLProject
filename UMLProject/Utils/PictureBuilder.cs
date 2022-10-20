using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMLProject.Components;
using UMLProject.Enums;
using UMLProject.Models;
using UMLProject.Relations;

namespace UMLProject.Utils
{
    public class PictureBuilder
    {
        private List<Box> boxes { get; set; }
        private List<Relation> relations { get; set; }

        private Bitmap bitmap = new Bitmap(PaintingArea.Size.Width + 5, PaintingArea.Size.Height + 5);

        public PictureBuilder(PaintingArea area, PictureType type)
        {
            this.boxes = area.Boxes;
            this.relations = area.Relations;

            DrawPicture(type);
        }

        public Image GetPicture() => this.bitmap;

        private void DrawPicture(PictureType type)
        {
            if (type == PictureType.JPG)
            {
                DrawBackground();
            }

            foreach (Box b in this.boxes)
            {
                DrawComponent(b);
            }

            foreach (Relation r in this.relations)
            {
                DrawComponent(r);
            }
        }

        private void DrawComponent(Component component)
        {
            Graphics g = Graphics.FromImage(this.bitmap);

            bool tmp = component.IsSelected;

            component.IsSelected = false;

            component.Draw(g);

            component.IsSelected = tmp;
        }

        private void DrawBackground()
        {
            Graphics g = Graphics.FromImage(this.bitmap);

            PaintingAreaSize size = PaintingArea.Size;

            g.FillRectangle(PaintingArea.BackColorBrush, 0, 0, size.Width + 5, size.Height + 5);
        }
    }
}
