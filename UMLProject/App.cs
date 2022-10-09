using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMLProject.Components;

namespace UMLProject
{
    public class App
    {
        PaintingArea area = new PaintingArea();

        public void Draw(Graphics g)
        {
            area.Draw(g);
        }

        public void MouseMove(int x, int y)
        {
            area.MouseMove(x, y);
        }
        
        public void MouseDown(int x, int y)
        {
            area.MouseDown(x, y);
        }
        
        public void MouseUp(int x, int y)
        {
            area.MouseUp(x, y);
        }

        public void MouseDoubleClick(int x, int y)
        {
            area.MouseDoubleClick(x, y);
        }

        public void Select(Component component)
        {
            area.SetSelected(component);
        }
    }
}