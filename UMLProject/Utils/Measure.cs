using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMLProject.Components;
using UMLProject.Models;

namespace UMLProject.Utils
{
    public static class Measure
    {
        public static SizeF MeasureString(string text)
        {
            SizeF res = new SizeF(20, 20);

            using (var image = new Bitmap(1, 1))
            {
                using (var g = Graphics.FromImage(image))
                {
                    SizeF size = g.MeasureString(text, Component.Font);

                    if (size.Width > res.Width)
                        res.Width = size.Width;

                    if (size.Height > res.Height)
                        res.Height = size.Height;
                };
            };

            return res;
        }
    }
}
