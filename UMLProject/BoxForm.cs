﻿using System;
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

        private int x;
        private int y;

        public BoxForm(Box box)
        {
            InitializeComponent();

            this.Box = box;

            InitComboBoxes();

            this.comboBox_type.SelectedIndex = (int)box.Type;
            this.comboBox_modifier.SelectedIndex = (int)box.Access;

            this.textBox_name.Text = box.Name;

            this.listBox_methods.Items.AddRange(box.Methods.ToArray());
            this.listBox_properties.Items.AddRange(box.Properties.ToArray());
        }

        public BoxForm(int x, int y)
        {
            InitializeComponent();

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
            Property p = new Property();

            BoxElementForm form = new BoxElementForm(p);

            if(form.ShowDialog() == DialogResult.OK)
                this.listBox_properties.Items.Add(p);
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
            Method m = new Method();

            BoxElementForm form = new BoxElementForm(m);

            if (form.ShowDialog() == DialogResult.OK)
                this.listBox_methods.Items.Add(m);
        }
    }
}
