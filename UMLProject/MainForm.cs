namespace UMLProject
{
    public partial class MainForm : Form
    {
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
    }
}