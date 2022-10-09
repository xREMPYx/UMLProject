using UMLProject.Components;

namespace UMLProject
{
    public partial class MainForm : Form
    {
        PaintingArea area = new PaintingArea();

        //public void Draw(Graphics g)
        //{
        //    area.Draw(g);
        //}

        //public void MouseMove(int x, int y)
        //{
        //    area.MouseMove(x, y);
        //}

        //public void MouseDown(int x, int y)
        //{
        //    area.MouseDown(x, y);
        //}

        //public void MouseUp(int x, int y)
        //{
        //    area.MouseUp(x, y);
        //}

        //public void MouseDoubleClick(int x, int y)
        //{
        //    area.MouseDoubleClick(x, y);
        //}

        //public void Select(Component component)
        //{
        //    area.SetSelected(component);
        //}

        //private App application = new App();

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
            area.Draw(e.Graphics);
        }

        private void timer_refresh_Tick(object sender, EventArgs e)
        {            
            this.pictureBox_drawing_area.Refresh();
        }

        private void pictureBox_drawing_area_MouseDown(object sender, MouseEventArgs e)
        {
            this.area.MouseDown(e.X, e.Y);
        }

        private void pictureBox_drawing_area_MouseUp(object sender, MouseEventArgs e)
        {
            this.area.MouseUp(e.X, e.Y);
        }

        private void pictureBox_drawing_area_MouseMove(object sender, MouseEventArgs e)
        {
            this.area.MouseMove(e.X, e.Y);
        }

        private void pictureBox_drawing_area_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.area.MouseDoubleClick(e.X, e.Y);
        }

        private void button_box_Click(object sender, EventArgs e)
        {
            this.area.SetSelected(new Box());
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                this.area.Delete();
            }
        }
    }
}