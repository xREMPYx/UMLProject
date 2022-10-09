using UMLProject.Components;
using UMLProject.Enums;
using UMLProject.Utils;

namespace UMLProject
{
    public partial class MainForm : Form
    {
        private PaintingArea area { get; set; } = new PaintingArea();
        private List<Button> buttons { get; }

        public MainForm()
        {
            InitializeComponent();

            buttons = new List<Button>() 
            {
                this.button_aggregation,
                this.button_association,
                this.button_composition,
                this.button_dependency,
                this.button_implementation,
                this.button_inheritance,
                this.button_box
            };

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
            this.panel2.Size = this.panel2.MinimumSize;

            MakeButtonSelected();
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
            MakeButtonSelected();
            this.area.MouseDoubleClick(e.X, e.Y);
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                this.area.Delete();
            }
        }

        private void MakeButtonSelected(Button? b = null)
        {
            this.buttons.ForEach(b => b.BackColor = Color.DarkGray);

            if(b != null)
                b.BackColor = Color.White;            
        }

        //File actions

        private void button_save_Click(object sender, EventArgs e)
        {            
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            { 
                saveFileDialog.Filter = "JPEG Image (.jpeg)|*.jpeg|Png Image (.png)|*.png";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {                    
                    PictureType type = saveFileDialog.FileName.Split(".")[1] == "jpeg"
                        ? PictureType.JPG 
                        : PictureType.PNG;

                    PictureBuilder builder = new PictureBuilder(area.Boxes, type);

                    builder.GetPicture().Save(saveFileDialog.FileName);
                }
            };
        }

        private void button_export_code_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                if(folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    string dir = folderBrowserDialog.SelectedPath;

                    foreach (Box b in area.Boxes)
                    {
                        CsFileBuilder builder = new CsFileBuilder(b);                        

                        File.WriteAllText($@"{dir}\{b.Name}.cs", builder.GetText());
                    }
                }
            };
        }

        private void button_export_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "JSON file (.json)|*.json";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string file = saveFileDialog.FileName;

                    File.WriteAllText(file, Formatter.Serialize(area));
                }
            };
        }

        private void button_import_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string file = openFileDialog.FileName;

                    string text = File.ReadAllText(file);

                    this.area = Formatter.GetPaintingArea(text);
                }
            };
        }

        //Buttons

        private void button_box_Click(object sender, EventArgs e)
        {
            MakeButtonSelected((Button)sender);
            this.area.SetSelected(new Box());
        }

        private void button_composition_Click(object sender, EventArgs e)
        {
            MakeButtonSelected((Button)sender);
        }

        private void button_aggregation_Click(object sender, EventArgs e)
        {
            MakeButtonSelected((Button)sender);
        }

        private void button_dependency_Click(object sender, EventArgs e)
        {
            MakeButtonSelected((Button)sender);
        }

        private void button_implementation_Click(object sender, EventArgs e)
        {
            MakeButtonSelected((Button)sender);
        }

        private void button_inheritance_Click(object sender, EventArgs e)
        {
            MakeButtonSelected((Button)sender);
        }

        private void button_association_Click(object sender, EventArgs e)
        {
            MakeButtonSelected((Button)sender);
        }
    }
}