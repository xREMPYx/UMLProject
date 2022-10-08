using UMLProject.Components;

namespace UMLProject
{
    public partial class MainForm : Form
    {
        private App application = new App();

        public MainForm()
        {            
            InitializeComponent();
            this.panel2.BringToFront();
        }

        private void button_file_Click(object sender, EventArgs e)
        {
            this.panel2.Size = this.panel2.Size == this.panel2.MaximumSize 
                ? this.panel2.MinimumSize 
                : this.panel2.MaximumSize;
        }

        private void pictureBox_drawing_area_Paint(object sender, PaintEventArgs e)
        {
            application.Draw(e.Graphics);
        }

        private void timer_refresh_Tick(object sender, EventArgs e)
        {            
            this.pictureBox_drawing_area.Refresh();
        }

        private void pictureBox_drawing_area_MouseDown(object sender, MouseEventArgs e)
        {
            this.application.MouseDown(e.X, e.Y);
        }

        private void pictureBox_drawing_area_MouseUp(object sender, MouseEventArgs e)
        {
            this.application.MouseUp(e.X, e.Y);
        }

        private void pictureBox_drawing_area_MouseMove(object sender, MouseEventArgs e)
        {
            this.application.MouseMove(e.X, e.Y);
        }

        private void button_box_Click(object sender, EventArgs e)
        {
            this.application.Select(new Box());
        }
    }
}