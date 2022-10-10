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
    public class TextBuilder
    {
        private Box box { get; set; }
        public TextBuilder(Box box)
        {
            this.box = box;
        }

        public string GetTextFormMeasurement()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(GetType());
            sb.AppendLine(box.Name);
            sb.AppendLine(GetMethods());
            sb.AppendLine(GetProperties());

            return sb.ToString();
        }

        public string GetText()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(GetHeader());
            sb.AppendLine(GetMethods());
            sb.AppendLine(GetProperties());

            return sb.ToString();
        }

        public string GetHeader()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(FillWithGapsToCenter(GetType()));
            sb.AppendLine(FillWithGapsToCenter(box.Name));

            return sb.ToString();
        }

        public string GetMethods()
        {
            StringBuilder sb = new StringBuilder();

            foreach (BoxElement e in box.Methods)
            {
                sb.AppendLine(e.ToString());
            }

            return sb.ToString();
        }

        public string GetProperties()
        {
            StringBuilder sb = new StringBuilder();

            foreach (BoxElement e in box.Properties)
            {
                sb.AppendLine(e.ToString());
            }

            return sb.ToString();
        }

        public int MaxRowWidth()
        {
            int width = 0;

            foreach (BoxElement e in box.Properties)
            {
                width = e.ToString().Length > width ? e.Name.Length : width;
            }

            foreach (BoxElement e in box.Methods)
            {
                width = e.ToString().Length > width ? e.Name.Length : width;
            }

            width = box.Name.ToString().Length > width ? box.Name.Length : width;

            return width;
        }

        private string FillWithGapsToCenter(string text)
        {
            string gaps = string.Empty.PadRight((box.Width - (int)Measure.MeasureString(text).Width) / 6);

            return gaps + text + gaps;
        }

        private string GetType()
        {
            string type =
                  box.Type == BoxType.Interface ? "<<interface>>"
                : box.Type == BoxType.Abstract ? "<<abstract>>" :
                "";

            return type;
        }
    }
}
