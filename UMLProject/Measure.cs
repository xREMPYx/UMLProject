using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMLProject.Models;

namespace UMLProject
{
    public static class Measure
    {
        public static SizeF MeasureMinWidth(List<BoxElement> elements, Graphics g, Font f)
        {
            SizeF res = SizeF.Empty;

            foreach (BoxElement e in elements)
            {                
                SizeF size = g.MeasureString(e.ToString(), f);

                if (size.Width > res.Width || size.Height > res.Height)
                    res = size;
            }

            return res;
        }
    }
}
