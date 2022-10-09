namespace UMLProject
{
    partial class BoxForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button_confirm = new System.Windows.Forms.Button();
            this.button_cancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_name = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.listBox_properties = new System.Windows.Forms.ListBox();
            this.comboBox_type = new System.Windows.Forms.ComboBox();
            this.comboBox_modifier = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button_property_add = new System.Windows.Forms.Button();
            this.button_property_delete = new System.Windows.Forms.Button();
            this.button_method_delete = new System.Windows.Forms.Button();
            this.button_method_add = new System.Windows.Forms.Button();
            this.listBox_methods = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // button_confirm
            // 
            this.button_confirm.Location = new System.Drawing.Point(12, 289);
            this.button_confirm.Name = "button_confirm";
            this.button_confirm.Size = new System.Drawing.Size(84, 26);
            this.button_confirm.TabIndex = 0;
            this.button_confirm.Text = "Confirm";
            this.button_confirm.UseVisualStyleBackColor = true;
            this.button_confirm.Click += new System.EventHandler(this.button_confirm_Click);
            // 
            // button_cancel
            // 
            this.button_cancel.Location = new System.Drawing.Point(128, 289);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(84, 26);
            this.button_cancel.TabIndex = 1;
            this.button_cancel.Text = "Cancel";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Name:";
            // 
            // textBox_name
            // 
            this.textBox_name.Location = new System.Drawing.Point(91, 12);
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.Size = new System.Drawing.Size(121, 23);
            this.textBox_name.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Type:";
            // 
            // listBox_properties
            // 
            this.listBox_properties.FormattingEnabled = true;
            this.listBox_properties.ItemHeight = 15;
            this.listBox_properties.Location = new System.Drawing.Point(92, 99);
            this.listBox_properties.Name = "listBox_properties";
            this.listBox_properties.Size = new System.Drawing.Size(120, 79);
            this.listBox_properties.TabIndex = 5;
            // 
            // comboBox_type
            // 
            this.comboBox_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_type.FormattingEnabled = true;
            this.comboBox_type.Location = new System.Drawing.Point(91, 41);
            this.comboBox_type.Name = "comboBox_type";
            this.comboBox_type.Size = new System.Drawing.Size(121, 23);
            this.comboBox_type.TabIndex = 6;
            // 
            // comboBox_modifier
            // 
            this.comboBox_modifier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_modifier.FormattingEnabled = true;
            this.comboBox_modifier.Location = new System.Drawing.Point(91, 70);
            this.comboBox_modifier.Name = "comboBox_modifier";
            this.comboBox_modifier.Size = new System.Drawing.Size(121, 23);
            this.comboBox_modifier.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Modifier:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "Properties:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 184);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 15);
            this.label5.TabIndex = 11;
            this.label5.Text = "Methods:";
            // 
            // button_property_add
            // 
            this.button_property_add.Location = new System.Drawing.Point(12, 117);
            this.button_property_add.Name = "button_property_add";
            this.button_property_add.Size = new System.Drawing.Size(66, 23);
            this.button_property_add.TabIndex = 12;
            this.button_property_add.Text = "Add";
            this.button_property_add.UseVisualStyleBackColor = true;
            this.button_property_add.Click += new System.EventHandler(this.button_property_add_Click);
            // 
            // button_property_delete
            // 
            this.button_property_delete.Location = new System.Drawing.Point(12, 146);
            this.button_property_delete.Name = "button_property_delete";
            this.button_property_delete.Size = new System.Drawing.Size(66, 23);
            this.button_property_delete.TabIndex = 13;
            this.button_property_delete.Text = "Delete";
            this.button_property_delete.UseVisualStyleBackColor = true;
            this.button_property_delete.Click += new System.EventHandler(this.button_delete_Click);
            // 
            // button_method_delete
            // 
            this.button_method_delete.Location = new System.Drawing.Point(12, 231);
            this.button_method_delete.Name = "button_method_delete";
            this.button_method_delete.Size = new System.Drawing.Size(66, 23);
            this.button_method_delete.TabIndex = 15;
            this.button_method_delete.Text = "Delete";
            this.button_method_delete.UseVisualStyleBackColor = true;
            this.button_method_delete.Click += new System.EventHandler(this.button_delete_Click);
            // 
            // button_method_add
            // 
            this.button_method_add.Location = new System.Drawing.Point(12, 202);
            this.button_method_add.Name = "button_method_add";
            this.button_method_add.Size = new System.Drawing.Size(66, 23);
            this.button_method_add.TabIndex = 14;
            this.button_method_add.Text = "Add";
            this.button_method_add.UseVisualStyleBackColor = true;
            this.button_method_add.Click += new System.EventHandler(this.button_method_add_Click);
            // 
            // listBox_methods
            // 
            this.listBox_methods.FormattingEnabled = true;
            this.listBox_methods.ItemHeight = 15;
            this.listBox_methods.Location = new System.Drawing.Point(92, 184);
            this.listBox_methods.Name = "listBox_methods";
            this.listBox_methods.Size = new System.Drawing.Size(120, 79);
            this.listBox_methods.TabIndex = 16;
            // 
            // BoxForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(225, 324);
            this.Controls.Add(this.listBox_methods);
            this.Controls.Add(this.button_method_delete);
            this.Controls.Add(this.button_method_add);
            this.Controls.Add(this.button_property_delete);
            this.Controls.Add(this.button_property_add);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBox_modifier);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox_type);
            this.Controls.Add(this.listBox_properties);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_name);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.button_confirm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "BoxForm";
            this.Text = "BoxForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button button_confirm;
        private Button button_cancel;
        private Label label1;
        private TextBox textBox_name;
        private Label label2;
        private ListBox listBox_properties;
        private ComboBox comboBox_type;
        private ComboBox comboBox_modifier;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button button_property_add;
        private Button button_property_delete;
        private Button button_method_delete;
        private Button button_method_add;
        private ListBox listBox_methods;
    }
}