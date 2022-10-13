namespace UMLProject
{
    partial class RelationForm
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
            this.textBox_from = new System.Windows.Forms.TextBox();
            this.label_from = new System.Windows.Forms.Label();
            this.label_to = new System.Windows.Forms.Label();
            this.textBox_to = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_confirm
            // 
            this.button_confirm.Location = new System.Drawing.Point(12, 103);
            this.button_confirm.Name = "button_confirm";
            this.button_confirm.Size = new System.Drawing.Size(74, 23);
            this.button_confirm.TabIndex = 0;
            this.button_confirm.Text = "Confirm";
            this.button_confirm.UseVisualStyleBackColor = true;
            this.button_confirm.Click += new System.EventHandler(this.button_confirm_Click);
            // 
            // button_cancel
            // 
            this.button_cancel.Location = new System.Drawing.Point(145, 103);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(75, 23);
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
            this.label1.Size = new System.Drawing.Size(30, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Box:";
            // 
            // textBox_from
            // 
            this.textBox_from.Location = new System.Drawing.Point(145, 12);
            this.textBox_from.Name = "textBox_from";
            this.textBox_from.Size = new System.Drawing.Size(75, 23);
            this.textBox_from.TabIndex = 3;
            // 
            // label_from
            // 
            this.label_from.AutoSize = true;
            this.label_from.Location = new System.Drawing.Point(48, 15);
            this.label_from.Name = "label_from";
            this.label_from.Size = new System.Drawing.Size(33, 15);
            this.label_from.TabIndex = 4;
            this.label_from.Text = "from";
            // 
            // label_to
            // 
            this.label_to.AutoSize = true;
            this.label_to.Location = new System.Drawing.Point(48, 64);
            this.label_to.Name = "label_to";
            this.label_to.Size = new System.Drawing.Size(18, 15);
            this.label_to.TabIndex = 7;
            this.label_to.Text = "to";
            // 
            // textBox_to
            // 
            this.textBox_to.Location = new System.Drawing.Point(145, 58);
            this.textBox_to.Name = "textBox_to";
            this.textBox_to.Size = new System.Drawing.Size(75, 23);
            this.textBox_to.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Box:";
            // 
            // RelationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(232, 138);
            this.Controls.Add(this.label_to);
            this.Controls.Add(this.textBox_to);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label_from);
            this.Controls.Add(this.textBox_from);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.button_confirm);
            this.Name = "RelationForm";
            this.Text = "RelationForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button button_confirm;
        private Button button_cancel;
        private Label label1;
        private TextBox textBox_from;
        private Label label_from;
        private Label label_to;
        private TextBox textBox_to;
        private Label label3;
    }
}