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
    public class CsFileBuilder
    {        
        private StringBuilder stringBuilder { get; } = new StringBuilder();
        private Box box { get; set; }
        public CsFileBuilder(Box box)
        {
            this.box = box;

            stringBuilder.AppendLine("using System;");

            stringBuilder.AppendLine($"{GetAccessModifier(box.Modifier)} {GetType(box.Type)} {box.Name}");
            stringBuilder.AppendLine("{");


            foreach (Property p in box.Properties)
            {
                stringBuilder.AppendLine(GetPropertyText(p));
            }

            foreach (Method m in box.Methods)
            {
                stringBuilder.AppendLine(GetMethodText(m));
            }

            stringBuilder.AppendLine("}");
        }

        private string GetPropertyText(Property p)
        {
            return $"\n{GetAccessModifier(p.Modifier)} {p.ReturnType} {p.Name} {"{ get; set; }"}\n";
        }

        private string GetMethodText(Method m)
        {
            return $"\n{GetAccessModifier(m.Modifier)} {m.ReturnType} {m.Name}() {"{}"}\n";
        }

        private string GetAccessModifier(AccessModifier am)
        {
            return am == AccessModifier.Public ? "public" 
                 : am == AccessModifier.Private ? "private" 
                 : "protected";
        }

        private string GetType(BoxType bt)
        {
            return bt == BoxType.Class ? "class" 
                 : bt == BoxType.Interface ? "interface" 
                 : "abstract";
        }

        public string GetText() => stringBuilder.ToString();
    }
}
