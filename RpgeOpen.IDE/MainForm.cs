using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using RpgeOpen.IDE.Utils;
using RpgeOpen.Models;
using RpgeOpen.Models.Entities;

namespace RpgeOpen.IDE
{
    public partial class MainForm : Form {
        private Project currentProject;
        private string CurrentProjectDir;

        private TileMap currentMap;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MiMapImport_Click(object sender, EventArgs e) {
            if( OfMapImport.ShowDialog() != DialogResult.OK )
                return;

            Size size;
            try
            {
                size= TiledImporter.ImportTmx(OfMapImport.FileName, CurrentProjectDir);
            } catch(Exception ex)
            {
                MessageBox.Show(this, "An error occured while importing Tiled map. Please check the file", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Debug.WriteLine(ex.StackTrace);
                return;
            }
            currentProject.Maps.Add( new Map( OfMapImport.SafeFileName, size ) );
            LoadMaps();
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var sp= new SplashForm();
            sp.ShowDialog();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            OfMapImport.InitialDirectory = SfNewProject.InitialDirectory = OfLoadProject.InitialDirectory 
                = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        }

        private void newProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SfNewProject.ShowDialog() != DialogResult.OK)
                return;

            var projectDir = Path.Combine( 
                Path.GetDirectoryName(SfNewProject.FileName), 
                Path.GetFileNameWithoutExtension(SfNewProject.FileName) );
            var projectFile = Path.Combine( projectDir, Path.GetFileName(SfNewProject.FileName) );

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
            File.WriteAllText(projectFile, JsonConvert.SerializeObject(project));

            LoadProject(projectFile);
        }

        private void loadProjectToolStripMenuItem_Click(object sender, EventArgs e) {
            if( OfLoadProject.ShowDialog() != DialogResult.OK )
                return;

            LoadProject( OfLoadProject.FileName );
        }

        private void LoadMaps() {
            LvMaps.Items.Clear();
            LvMaps.Items.AddRange( 
                currentProject.Maps.Select( m => new ListViewItem { Name = m.TmxPath, Text = m.DisplayName} ).ToArray() );
        }

        private void LoadProject( string fileName ) {
            var rawProjectFile = File.ReadAllText( fileName );
            try {
                currentProject = JsonConvert.DeserializeObject<Project>( rawProjectFile );
            } catch( JsonSerializationException ) {
                MessageBox.Show( this, "Invalid project file " + fileName, "Project loading error", MessageBoxButtons.OK, MessageBoxIcon.Error );
                return;
            }

            CurrentProjectDir = Path.GetDirectoryName( fileName );
            MnSave.Enabled = MnMapImport.Enabled = true;
        }

        private void LvMaps_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e) {
            var key = e.Item.Name;

            currentMap?.Dispose();
            currentMap = new TileMap(currentProject.Maps.First( m => m.TmxPath == key ));
            currentMap.Load(CurrentProjectDir);
            PbMap.Image = currentMap.Image;
        }
    }
}
