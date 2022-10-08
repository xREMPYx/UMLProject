namespace UMLProject
{
    partial class BoxElementForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_name = new System.Windows.Forms.TextBox();
            this.comboBox_modifier = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_return_type = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button_cancel = new System.Windows.Forms.Button();
            this.button_confirm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Name:";
            // 
            // textBox_name
            // 
            this.textBox_name.Location = new System.Drawing.Point(94, 12);
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.Size = new System.Drawing.Size(121, 23);
            this.textBox_name.TabIndex = 4;
            // 
            // comboBox_modifier
            // 
            this.comboBox_modifier.FormattingEnabled = true;
            this.comboBox_modifier.Location = new System.Drawing.Point(94, 70);
            this.comboBox_modifier.Name = "comboBox_modifier";
            this.comboBox_modifier.Size = new System.Drawing.Size(121, 23);
            this.comboBox_modifier.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "Modifier:";
            // 
            // textBox_return_type
            // 
            this.textBox_return_type.Location = new System.Drawing.Point(94, 41);
            this.textBox_return_type.Name = "textBox_return_type";
            this.textBox_return_type.Size = new System.Drawing.Size(121, 23);
            this.textBox_return_type.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 15);
            this.label2.TabIndex = 11;
            this.label2.Text = "Return type:";
            // 
            // button_cancel
            // 
            this.button_cancel.Location = new System.Drawing.Point(131, 111);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(84, 26);
            this.button_cancel.TabIndex = 13;
            this.button_cancel.Text = "Cancel";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // button_confirm
            // 
            this.button_confirm.Location = new System.Drawing.Point(15, 111);
            this.button_confirm.Name = "button_confirm";
            this.button_confirm.Size = new System.Drawing.Size(84, 26);
            this.button_confirm.TabIndex = 14;
            this.button_confirm.Text = "Confirm";
            this.button_confirm.UseVisualStyleBackColor = true;
            this.button_confirm.Click += new System.EventHandler(this.button_confirm_Click);
            // 
            // BoxElementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(231, 149);
            this.Controls.Add(this.button_confirm);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.textBox_return_type);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox_modifier);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_name);
            this.Controls.Add(this.label1);
            this.Name = "BoxElementForm";
            this.Text = "BoxElementForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label label1;
        private TextBox textBox_name;
        private ComboBox comboBox_modifier;
        private Label label3;
        private TextBox textBox_return_type;
        private Label label2;
        private Button button_cancel;
        private Button button_confirm;
    }
}