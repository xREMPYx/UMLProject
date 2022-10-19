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
        private List<Component> components = new List<Component>() { new PaintingArea() };

        public void Draw(Graphics g)
        {
            components.ForEach(c => c.Draw(g));
        }

        public App()
        {
            
        }
    }
}
