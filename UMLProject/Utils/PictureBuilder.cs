using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMLProject.Components;
using UMLProject.Enums;
using UMLProject.Models;

namespace UMLProject.Utils
{
    public class PictureBuilder
    {
        private List<Box> boxes { get; set; }

        private Bitmap bitmap = new Bitmap(PaintingArea.Size.Width, PaintingArea.Size.Height);

        public PictureBuilder(List<Box> boxes, PictureType type)
        {
            this.boxes = boxes;

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
                DrawBox(b);
            }
        }

        private void DrawBox(Box box)
        {
            Graphics g = Graphics.FromImage(this.bitmap);

            box.X -= 5;
            box.Y -= 5;

            bool tmp = box.IsSelected;

            box.IsSelected = false;

            box.Draw(g);

            box.IsSelected = tmp;
        }

        private void DrawBackground()
        {
            Graphics g = Graphics.FromImage(this.bitmap);

            PaintingAreaSize size = PaintingArea.Size;

            g.FillRectangle(PaintingArea.BackColorBrush, 0, 0, size.Width, size.Height);
        }
    }
}
