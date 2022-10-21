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
using UMLProject.Enums;
using UMLProject.Models;

namespace UMLProject
{
    public partial class BoxForm : Form
    {
        public Box Box { get; private set; }
        private List<string> boxNames { get; set; }

        private int x;
        private int y;

        public BoxForm(Box box, List<string> boxNames)
        {
            InitializeComponent();

            this.Box = box;
            this.boxNames = boxNames;

            InitComboBoxes();

            this.comboBox_type.SelectedIndex = (int)box.Type;
            this.comboBox_modifier.SelectedIndex = (int)box.Modifier;

            this.textBox_name.Text = box.Name;

            this.listBox_methods.Items.AddRange(box.Methods.ToArray());
            this.listBox_properties.Items.AddRange(box.Properties.ToArray());            
        }

        public BoxForm(int x, int y, List<string> boxNames)
        {
            InitializeComponent();

            this.boxNames = boxNames;

            InitComboBoxes();

            this.comboBox_type.SelectedIndex = 0;
            this.comboBox_modifier.SelectedIndex = 0;

            this.x = x;
            this.y = y;
        }

        private void InitComboBoxes()
        {
            this.comboBox_modifier.Items.Add(AccessModifier.Public);
            this.comboBox_modifier.Items.Add(AccessModifier.Private);
            this.comboBox_modifier.Items.Add(AccessModifier.Protected);

            this.comboBox_type.Items.Add(BoxType.Class);
            this.comboBox_type.Items.Add(BoxType.Interface);
            this.comboBox_type.Items.Add(BoxType.Abstract);
        }

        private void button_confirm_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
                return;

            this.DialogResult = DialogResult.OK;
           
            string name = this.textBox_name.Text;
            AccessModifier access = (AccessModifier)this.comboBox_modifier.SelectedItem;
            BoxType type = (BoxType)this.comboBox_type.SelectedItem;

            List<Method> methods = this.listBox_methods.Items.Cast<Method>().ToList();
            List<Property> properties = this.listBox_properties.Items.Cast<Property>().ToList();

            Box box = new Box(name, access, type, methods, properties);

            box.X = x;
            box.Y = y;
            box.IsSelected = false;
            box.ClearMouseState();

            Box = box;

            this.Close();
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void button_property_add_Click(object sender, EventArgs e)
        {
            BoxElementForm form = new BoxElementForm(BoxElementType.Property);

            if(form.ShowDialog() == DialogResult.OK)
                this.listBox_properties.Items.Add(form.Element);
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            ListBox listBox = ((Button)sender).Name == "button_property_delete" 
                ? listBox_properties
                : listBox_methods;
            
            int i = listBox.SelectedIndex;

            if(i > -1 && listBox.Items.Count > 0)
                listBox.Items.RemoveAt(i);
        }

        private void button_method_add_Click(object sender, EventArgs e)
        {
            BoxElementForm form = new BoxElementForm(BoxElementType.Method);

            if (form.ShowDialog() == DialogResult.OK)
                this.listBox_methods.Items.Add(form.Element);
        }

        private void textBox_name_Validating(object sender, CancelEventArgs e)
        {            
            TextBox textbox = (TextBox)sender;

            this.errorProvider1.SetError(textbox, null);

            if (string.IsNullOrWhiteSpace(textbox.Text))
            {
                this.errorProvider1.SetError(textbox, "This field cannot be empty!");
                e.Cancel = true;
            }

            if (this.boxNames.Contains(this.textBox_name.Text) && this.Box.Name != this.textBox_name.Text)
            {
                this.errorProvider1.SetError(this.textBox_name, "Name for this box is already taken!");
                e.Cancel = true;
            }
        }

        private void listBox_properties_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            EditBoxElement(sender, BoxElementType.Property);
        }

        private void listBox_methods_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            EditBoxElement(sender, BoxElementType.Method);
        }

        private void EditBoxElement(object sender, BoxElementType type)
        {
            ListBox listBox = (ListBox)sender;

            if (listBox.Items.Count == 0)
                return;

            BoxElement element = (BoxElement)listBox.SelectedItem;

            BoxElementForm form = new BoxElementForm(type, element);

            if (form.ShowDialog() == DialogResult.OK)
            {
                listBox.Items[listBox.SelectedIndex] = form.Element;              
            }
        }
    }
}
