using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UMLProject.Enums;
using UMLProject.Models;

namespace UMLProject
{
    public partial class BoxElementForm : Form
    {
        public BoxElement Element { get; private set; }

        private BoxElementType type;        

        public BoxElementForm(BoxElementType type)
        {
            InitializeComponent();

            this.comboBox_modifier.Items.Add(AccessModifier.Public);
            this.comboBox_modifier.Items.Add(AccessModifier.Private);
            this.comboBox_modifier.Items.Add(AccessModifier.Protected);

            this.comboBox_modifier.SelectedIndex = 0;

            if(type == BoxElementType.Method)
            {
                this.label_parameters.Visible = true;
                this.textBox_parameters.Visible = true;
                this.Element = new Method();
            }
            else
            {
                this.Element = new Property();
            }

            this.type = type;
        }
        public BoxElementForm(BoxElementType type, BoxElement element) : this(type)
        {
            this.comboBox_modifier.SelectedItem = element.Modifier;
            this.textBox_return_type.Text = element.ReturnType;
            this.textBox_name.Text = element.Name;

            if (this.type == BoxElementType.Method)
            {
                this.textBox_parameters.Text = ((Method)element).Parameters;
            }
        }


        private void button_confirm_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
                return;

            if (this.type == BoxElementType.Method)
            {
                ((Method)this.Element).Parameters = this.textBox_parameters.Text;
            }

            this.Element.ReturnType = this.textBox_return_type.Text;
            this.Element.Name = this.textBox_name.Text;
            this.Element.Modifier = (AccessModifier)this.comboBox_modifier.SelectedItem;                        

            this.DialogResult = DialogResult.OK;
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void validation_string_empty(object sender, CancelEventArgs e)
        {
            TextBox box = (TextBox)sender;

            if (String.IsNullOrEmpty(box.Text))
            {
                this.errorProvider1.SetError(box, "This field cannot be empty!");
                e.Cancel = true;
            }
            else
            {
                this.errorProvider1.Clear();
                e.Cancel = false;
            }
        }
    }
}
