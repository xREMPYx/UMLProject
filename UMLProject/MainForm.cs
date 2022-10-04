namespace UMLProject
{
    public partial class MainForm : Form
    {
        private App application = new App();

        public MainForm()
        {            
            InitializeComponent();
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
    }
}