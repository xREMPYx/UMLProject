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
    public class CsFileBuilder
    {
        private StringBuilder stringBuilder { get; } = new StringBuilder();
        private List<string> boxNames { get; set; } = new List<string>();
        private IText text {get; set; }
        public CsFileBuilder(List<Relation> relations, Box box)
        {
            boxNames = relations
                .Where(r => r.To == box)
                .Select(b => b.From.Name)
                .ToList();           

            foreach (Property p in box.Properties)
            {
                stringBuilder.AppendLine(GetPropertyText(p));
                stringBuilder.AppendLine();
            }

            foreach (Method m in box.Methods)
            {
                stringBuilder.AppendLine(GetMethodText(m));
                stringBuilder.AppendLine();
            }

            string classText = $"{GetAccessModifier(box.Modifier)} {GetType(box.Type)} {box.Name} {GetParents()}";

            IText text = new InitText(stringBuilder.ToString());

            text = new ClassText(classText, text);
            text = new NameSpaceText("project", text);

            this.text = text;
        }

        private string GetPropertyText(Property p)
        {
            return $"{GetAccessModifier(p.Modifier)} {p.ReturnType} {p.Name} {"{ get; set; }"}";
        }

        private string GetMethodText(Method m)
        {
            string result = string.Empty;
            
            result += $"{GetAccessModifier(m.Modifier)} {m.ReturnType} {m.Name}({m.Parameters})";
            result += "\n{\n";
            result += $"{GetPad()}throw new NotImplementedException();";
            result += "\n}";
            
            return result;
        }

        private string GetAccessModifier(AccessModifier am)
        {
            return am == AccessModifier.Public ? "public" 
                 : am == AccessModifier.Private ? "private" 
                 : "protected";
        }

        private string GetParents()
        {
            if(boxNames.Count == 0)
                return String.Empty;

            return ": " + boxNames.Aggregate((a, b) => $"{a}," + b);
        }

        private string GetType(BoxType bt)
        {
            return bt == BoxType.Class ? "class" 
                 : bt == BoxType.Interface ? "interface" 
                 : "abstract";
        }

        public string GetText() => text.Text;

        public static string GetPad(int c = 1)
        {
            string pad = "    ";

            string res = pad;

            for (int i = 1; i < c; i++)
            {
                res += pad;
            }

            return res;
        }
    }

    //Decorator

    public interface IText
    {
        public string Text { get; set; }
    }

    public class NameSpaceText : IText
    {
        public string Text { get; set; }
        public NameSpaceText(string name, IText text)
        {
            this.Text = $"namespace {name}";
            this.Text += "\n{";

            using (StringReader reader = new StringReader(text.Text))
            {
                string line = reader.ReadLine();

                while (line != null)
                {
                    this.Text += "\n" + CsFileBuilder.GetPad() + line;
                    line = reader.ReadLine();
                }
            }

            this.Text += "\n}";
        }
    }

    public class ClassText : IText
    {
        public string Text { get; set; }

        public ClassText(string classText, IText text)
        {            
            this.Text = classText;
            this.Text += "\n{\n";

            using (StringReader reader = new StringReader(text.Text))
            {                
                string line = reader.ReadLine();

                while (line != null)
                {
                    this.Text += "\n" + CsFileBuilder.GetPad() + line;
                    line = reader.ReadLine();
                }
            }

            this.Text += "\n}";
        }
    }

    public class InitText : IText
    {
        public string Text { get; set; }

        public InitText(string text)
        {
            Text = text;
        }
    }
}
