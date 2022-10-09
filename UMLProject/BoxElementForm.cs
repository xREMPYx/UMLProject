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
        BoxElement element;
        public BoxElementForm(BoxElement element)
        {
            InitializeComponent();

            this.element = element;

            this.comboBox_modifier.Items.Add(AccessModifier.Public);
            this.comboBox_modifier.Items.Add(AccessModifier.Private);
            this.comboBox_modifier.Items.Add(AccessModifier.Protected);
        }

        private void button_confirm_Click(object sender, EventArgs e)
        {
            this.element.ReturnType = this.textBox_return_type.Text;
            this.element.Name = this.textBox_name.Text;
            this.element.Modifier = (AccessModifier)this.comboBox_modifier.SelectedItem;            
            this.DialogResult = DialogResult.OK;
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
