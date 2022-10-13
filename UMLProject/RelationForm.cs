using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UMLProject.Components;

namespace UMLProject
{
    public partial class RelationForm : Form
    {
        public string From { get; set; }
        public string To { get; set; }
        public RelationForm(Box from, Box to)
        {
            InitializeComponent();
            this.label_from.Text = from.Name;
            this.label_to.Text = to.Name;            
        }

        private void button_confirm_Click(object sender, EventArgs e)
        {
            this.From = this.textBox_from.Text;
            this.To = this.textBox_to.Text;

            this.DialogResult = DialogResult.OK;
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
