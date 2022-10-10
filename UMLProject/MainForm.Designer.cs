namespace UMLProject
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel_top = new System.Windows.Forms.Panel();
            this.button_dependency = new System.Windows.Forms.Button();
            this.button_aggregation = new System.Windows.Forms.Button();
            this.button_box = new System.Windows.Forms.Button();
            this.button_composition = new System.Windows.Forms.Button();
            this.button_association = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button_inheritance = new System.Windows.Forms.Button();
            this.button_file = new System.Windows.Forms.Button();
            this.button_implementation = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.pictureBox_drawing_area = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button_export = new System.Windows.Forms.Button();
            this.button_import = new System.Windows.Forms.Button();
            this.button_generate_code = new System.Windows.Forms.Button();
            this.button_save = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel_top.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_drawing_area)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_top
            // 
            this.panel_top.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_top.AutoSize = true;
            this.panel_top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel_top.Controls.Add(this.button_dependency);
            this.panel_top.Controls.Add(this.button_aggregation);
            this.panel_top.Controls.Add(this.button_box);
            this.panel_top.Controls.Add(this.button_composition);
            this.panel_top.Controls.Add(this.button_association);
            this.panel_top.Controls.Add(this.button2);
            this.panel_top.Controls.Add(this.button_inheritance);
            this.panel_top.Controls.Add(this.button_file);
            this.panel_top.Controls.Add(this.button_implementation);
            this.panel_top.Controls.Add(this.button4);
            this.panel_top.Location = new System.Drawing.Point(0, 0);
            this.panel_top.Name = "panel_top";
            this.panel_top.Size = new System.Drawing.Size(684, 76);
            this.panel_top.TabIndex = 0;
            // 
            // button_dependency
            // 
            this.button_dependency.BackColor = System.Drawing.Color.DarkGray;
            this.button_dependency.BackgroundImage = global::UMLProject.Properties.Resources.dependencyR;
            this.button_dependency.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_dependency.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_dependency.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button_dependency.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_dependency.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.button_dependency.Location = new System.Drawing.Point(337, 12);
            this.button_dependency.Name = "button_dependency";
            this.button_dependency.Size = new System.Drawing.Size(34, 34);
            this.button_dependency.TabIndex = 16;
            this.button_dependency.UseVisualStyleBackColor = false;
            this.button_dependency.Click += new System.EventHandler(this.button_dependency_Click);
            // 
            // button_aggregation
            // 
            this.button_aggregation.BackColor = System.Drawing.Color.DarkGray;
            this.button_aggregation.BackgroundImage = global::UMLProject.Properties.Resources.aggregationR;
            this.button_aggregation.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_aggregation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_aggregation.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button_aggregation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_aggregation.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.button_aggregation.Location = new System.Drawing.Point(371, 12);
            this.button_aggregation.Name = "button_aggregation";
            this.button_aggregation.Size = new System.Drawing.Size(34, 34);
            this.button_aggregation.TabIndex = 15;
            this.button_aggregation.UseVisualStyleBackColor = false;
            this.button_aggregation.Click += new System.EventHandler(this.button_aggregation_Click);
            // 
            // button_box
            // 
            this.button_box.BackColor = System.Drawing.Color.DarkGray;
            this.button_box.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_box.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_box.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button_box.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_box.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.button_box.Location = new System.Drawing.Point(102, 12);
            this.button_box.Name = "button_box";
            this.button_box.Size = new System.Drawing.Size(94, 34);
            this.button_box.TabIndex = 3;
            this.button_box.UseVisualStyleBackColor = false;
            this.button_box.Click += new System.EventHandler(this.button_box_Click);
            // 
            // button_composition
            // 
            this.button_composition.BackColor = System.Drawing.Color.DarkGray;
            this.button_composition.BackgroundImage = global::UMLProject.Properties.Resources.compositionR;
            this.button_composition.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_composition.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_composition.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button_composition.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_composition.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.button_composition.Location = new System.Drawing.Point(405, 12);
            this.button_composition.Name = "button_composition";
            this.button_composition.Size = new System.Drawing.Size(34, 34);
            this.button_composition.TabIndex = 14;
            this.button_composition.UseVisualStyleBackColor = false;
            this.button_composition.Click += new System.EventHandler(this.button_composition_Click);
            // 
            // button_association
            // 
            this.button_association.BackColor = System.Drawing.Color.DarkGray;
            this.button_association.BackgroundImage = global::UMLProject.Properties.Resources.associationR;
            this.button_association.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_association.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_association.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button_association.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_association.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.button_association.Location = new System.Drawing.Point(235, 12);
            this.button_association.Name = "button_association";
            this.button_association.Size = new System.Drawing.Size(34, 34);
            this.button_association.TabIndex = 13;
            this.button_association.UseVisualStyleBackColor = false;
            this.button_association.Click += new System.EventHandler(this.button_association_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.Enabled = false;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Location = new System.Drawing.Point(102, 42);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(94, 26);
            this.button2.TabIndex = 2;
            this.button2.Text = "Box";
            this.button2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button_inheritance
            // 
            this.button_inheritance.BackColor = System.Drawing.Color.DarkGray;
            this.button_inheritance.BackgroundImage = global::UMLProject.Properties.Resources.inheritanceR;
            this.button_inheritance.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_inheritance.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_inheritance.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button_inheritance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_inheritance.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.button_inheritance.Location = new System.Drawing.Point(269, 12);
            this.button_inheritance.Name = "button_inheritance";
            this.button_inheritance.Size = new System.Drawing.Size(34, 34);
            this.button_inheritance.TabIndex = 12;
            this.button_inheritance.UseVisualStyleBackColor = false;
            this.button_inheritance.Click += new System.EventHandler(this.button_inheritance_Click);
            // 
            // button_file
            // 
            this.button_file.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.button_file.BackgroundImage = global::UMLProject.Properties.Resources.free_file_icon_1453_thumb;
            this.button_file.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_file.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_file.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button_file.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_file.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.button_file.Location = new System.Drawing.Point(12, 12);
            this.button_file.Name = "button_file";
            this.button_file.Size = new System.Drawing.Size(56, 56);
            this.button_file.TabIndex = 0;
            this.button_file.UseVisualStyleBackColor = false;
            this.button_file.Click += new System.EventHandler(this.button_file_Click);
            // 
            // button_implementation
            // 
            this.button_implementation.BackColor = System.Drawing.Color.DarkGray;
            this.button_implementation.BackgroundImage = global::UMLProject.Properties.Resources.realization_implementationR;
            this.button_implementation.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_implementation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_implementation.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button_implementation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_implementation.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.button_implementation.Location = new System.Drawing.Point(303, 12);
            this.button_implementation.Name = "button_implementation";
            this.button_implementation.Size = new System.Drawing.Size(34, 34);
            this.button_implementation.TabIndex = 11;
            this.button_implementation.UseVisualStyleBackColor = false;
            this.button_implementation.Click += new System.EventHandler(this.button_implementation_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.Enabled = false;
            this.button4.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button4.ForeColor = System.Drawing.Color.Black;
            this.button4.Location = new System.Drawing.Point(235, 42);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(204, 26);
            this.button4.TabIndex = 4;
            this.button4.Text = "Relations";
            this.button4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button4.UseVisualStyleBackColor = false;
            // 
            // pictureBox_drawing_area
            // 
            this.pictureBox_drawing_area.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox_drawing_area.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(110)))), ((int)(((byte)(110)))));
            this.pictureBox_drawing_area.Location = new System.Drawing.Point(0, 0);
            this.pictureBox_drawing_area.Name = "pictureBox_drawing_area";
            this.pictureBox_drawing_area.Size = new System.Drawing.Size(681, 370);
            this.pictureBox_drawing_area.TabIndex = 1;
            this.pictureBox_drawing_area.TabStop = false;
            this.pictureBox_drawing_area.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_drawing_area_Paint);
            this.pictureBox_drawing_area.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox_drawing_area_MouseDoubleClick);
            this.pictureBox_drawing_area.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_drawing_area_MouseDown);
            this.pictureBox_drawing_area.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_drawing_area_MouseMove);
            this.pictureBox_drawing_area.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_drawing_area_MouseUp);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panel2.Controls.Add(this.button_export);
            this.panel2.Controls.Add(this.button_import);
            this.panel2.Controls.Add(this.button_generate_code);
            this.panel2.Controls.Add(this.button_save);
            this.panel2.Location = new System.Drawing.Point(0, 78);
            this.panel2.MaximumSize = new System.Drawing.Size(116, 88);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(0, 0);
            this.panel2.TabIndex = 2;
            // 
            // button_export
            // 
            this.button_export.Location = new System.Drawing.Point(0, 66);
            this.button_export.Name = "button_export";
            this.button_export.Size = new System.Drawing.Size(117, 23);
            this.button_export.TabIndex = 3;
            this.button_export.Text = "Export (json)";
            this.button_export.UseVisualStyleBackColor = true;
            this.button_export.Click += new System.EventHandler(this.button_export_Click);
            // 
            // button_import
            // 
            this.button_import.Location = new System.Drawing.Point(0, 44);
            this.button_import.Name = "button_import";
            this.button_import.Size = new System.Drawing.Size(117, 23);
            this.button_import.TabIndex = 2;
            this.button_import.Text = "Import (json)";
            this.button_import.UseVisualStyleBackColor = true;
            this.button_import.Click += new System.EventHandler(this.button_import_Click);
            // 
            // button_generate_code
            // 
            this.button_generate_code.Location = new System.Drawing.Point(0, 22);
            this.button_generate_code.Name = "button_generate_code";
            this.button_generate_code.Size = new System.Drawing.Size(117, 23);
            this.button_generate_code.TabIndex = 1;
            this.button_generate_code.Text = "Generate Code";
            this.button_generate_code.UseVisualStyleBackColor = true;
            this.button_generate_code.Click += new System.EventHandler(this.button_export_code_Click);
            // 
            // button_save
            // 
            this.button_save.Location = new System.Drawing.Point(0, 0);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(117, 23);
            this.button_save.TabIndex = 0;
            this.button_save.Text = "Save";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.pictureBox_drawing_area);
            this.panel1.Location = new System.Drawing.Point(0, 78);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(684, 373);
            this.panel1.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(110)))), ((int)(((byte)(110)))));
            this.ClientSize = new System.Drawing.Size(684, 452);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel_top);
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(700, 450);
            this.Name = "MainForm";
            this.Text = "UML Design";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.panel_top.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_drawing_area)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel panel_top;
        private Button button_file;
        private Button button_box;
        private Button button2;
        private Button button_dependency;
        private Button button_aggregation;
        private Button button_composition;
        private Button button_association;
        private Button button_inheritance;
        private Button button_implementation;
        private Button button4;
        private PictureBox pictureBox_drawing_area;
        private Panel panel2;
        private Button button_export;
        private Button button_import;
        private Button button_generate_code;
        private Button button_save;
        private Panel panel1;
    }
}