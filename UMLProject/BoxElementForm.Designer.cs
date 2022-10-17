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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_name = new System.Windows.Forms.TextBox();
            this.comboBox_modifier = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_return_type = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button_cancel = new System.Windows.Forms.Button();
            this.button_confirm = new System.Windows.Forms.Button();
            this.textBox_parameters = new System.Windows.Forms.TextBox();
            this.label_parameters = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
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
            this.textBox_name.Validating += new System.ComponentModel.CancelEventHandler(this.validation_string_empty);
            // 
            // comboBox_modifier
            // 
            this.comboBox_modifier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
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
            this.textBox_return_type.Validating += new System.ComponentModel.CancelEventHandler(this.validation_string_empty);
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
            this.button_cancel.Location = new System.Drawing.Point(131, 145);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(84, 26);
            this.button_cancel.TabIndex = 13;
            this.button_cancel.Text = "Cancel";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // button_confirm
            // 
            this.button_confirm.Location = new System.Drawing.Point(15, 145);
            this.button_confirm.Name = "button_confirm";
            this.button_confirm.Size = new System.Drawing.Size(84, 26);
            this.button_confirm.TabIndex = 14;
            this.button_confirm.Text = "Confirm";
            this.button_confirm.UseVisualStyleBackColor = true;
            this.button_confirm.Click += new System.EventHandler(this.button_confirm_Click);
            // 
            // textBox_parameters
            // 
            this.textBox_parameters.Location = new System.Drawing.Point(94, 99);
            this.textBox_parameters.Name = "textBox_parameters";
            this.textBox_parameters.Size = new System.Drawing.Size(121, 23);
            this.textBox_parameters.TabIndex = 18;
            this.textBox_parameters.Visible = false;
            // 
            // label_parameters
            // 
            this.label_parameters.AutoSize = true;
            this.label_parameters.Location = new System.Drawing.Point(15, 102);
            this.label_parameters.Name = "label_parameters";
            this.label_parameters.Size = new System.Drawing.Size(69, 15);
            this.label_parameters.TabIndex = 17;
            this.label_parameters.Text = "Parameters:";
            this.label_parameters.Visible = false;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // BoxElementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ClientSize = new System.Drawing.Size(236, 183);
            this.Controls.Add(this.textBox_parameters);
            this.Controls.Add(this.label_parameters);
            this.Controls.Add(this.button_confirm);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.textBox_return_type);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox_modifier);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_name);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "BoxElementForm";
            this.Text = "BoxElementForm";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
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
        private TextBox textBox_parameters;
        private Label label_parameters;
        private ErrorProvider errorProvider1;
    }
}