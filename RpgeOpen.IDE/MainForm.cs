using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using RpgeOpen.IDE.Utils;
using RpgeOpen.Models.Entities;

namespace RpgeOpen.IDE
{
    public partial class MainForm : Form {
        public string CurrentProjectDir => @"C:\Users\r.aldrigo\Documents\Rpge Open\test";
        public string TileSheetsDir => Path.Combine( CurrentProjectDir, Project.Paths.TileSheets);

        public MainForm()
        {
            InitializeComponent();
        }

        private void MiMapImport_Click(object sender, EventArgs e) {
            if( OfMapImport.ShowDialog() != DialogResult.OK )
                return;

            try
            {
                TiledImporter.ImportTmx(OfMapImport.FileName, CurrentProjectDir);
            } catch(Exception ex)
            {
                MessageBox.Show(this, "An error occured while importing Tiled map. Please check the file", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Debug.WriteLine(ex.StackTrace);
            }
        }

        private void Form1_Load(object sender, EventArgs e) {
            OfMapImport.InitialDirectory = SfNewProject.InitialDirectory = Environment.GetFolderPath( Environment.SpecialFolder.MyDocuments );
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var sp= new SplashForm();
            sp.ShowDialog();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void newProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SfNewProject.ShowDialog() != DialogResult.OK)
                return;

            var projectDir = Path.Combine( 
                Path.GetDirectoryName(SfNewProject.FileName), 
                Path.GetFileNameWithoutExtension(SfNewProject.FileName) );
            if (Directory.Exists(projectDir))
            {
                MessageBox.Show(this, "Project directory already exits", "Can't create new project", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Directory.CreateDirectory(projectDir);
            foreach (string dirPath in Directory.GetDirectories("ProjectStructure", "*", SearchOption.AllDirectories))
                Directory.CreateDirectory(dirPath.Replace("ProjectStructure", projectDir));

            foreach (string newPath in Directory.GetFiles("ProjectStructure", "*.*", SearchOption.AllDirectories))
                File.Copy(newPath, newPath.Replace("ProjectStructure", projectDir), true);

            var project = new Project(Path.GetFileNameWithoutExtension(SfNewProject.FileName));
            File.WriteAllText(SfNewProject.FileName, JsonConvert.SerializeObject(project));
        }
    }
}
