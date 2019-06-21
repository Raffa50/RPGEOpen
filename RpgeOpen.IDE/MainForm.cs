using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using RpgeOpen.IDE.Models;
using RpgeOpen.IDE.Utils;
using RpgeOpen.Models;
using RpgeOpen.Models.Entities;

namespace RpgeOpen.IDE
{
    public partial class MainForm : Form {
        private CurrentProject currentProject;
        private TileMap currentMap;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MiMapImport_Click(object sender, EventArgs e) {
            if( OfMapImport.ShowDialog() != DialogResult.OK )
                return;

            RpgeOpen.Models.Size size;
            try
            {
                size= TiledImporter.ImportTmx(OfMapImport.FileName, currentProject.Directory);
            } catch(Exception ex)
            {
                MessageBox.Show(this, "An error occured while importing Tiled map. Please check the file", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Debug.WriteLine(ex.StackTrace);
                return;
            }
            currentProject.Project.Maps.Add( new Map( OfMapImport.SafeFileName, size ) );
            LoadMaps();
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

            var project = new ProjectDetails(Path.GetFileNameWithoutExtension(SfNewProject.FileName));
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
                currentProject.Project.Maps.Select( m => new ListViewItem { Name = m.TmxPath, Text = m.DisplayName} ).ToArray() );
        }

        private void LoadProject( string fileName ) {
            try {
                currentProject = new CurrentProject(fileName);
            } catch( JsonSerializationException ) {
                MessageBox.Show( this, "Invalid project file " + fileName, "Project loading error", MessageBoxButtons.OK, MessageBoxIcon.Error );
                return;
            }

            LoadMaps();
            MnSave.Enabled = MnMapImport.Enabled = MnTest.Enabled = mnRelease.Enabled = true;
        }

        private void LvMaps_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e) {
            var key = e.Item.Name;

            currentMap?.Dispose();
            currentMap = new TileMap(currentProject.Project.Maps.First( m => m.TmxPath == key ));
            currentMap.Load(currentProject.Directory);

            PbMap.Height = currentMap.Image.Height;
            PbMap.Width = currentMap.Image.Width;
            PbMap.Invalidate();
        }

        private void MnSave_Click(object sender, EventArgs e)
        {
            currentProject.Save();
        }

        private void reportBugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/Raffa50/RPGEOpen/issues");
        }

        private void versionDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var sp = new SplashForm();
            sp.ShowDialog();
        }

        private void MnTest_Click(object sender, EventArgs e)
        {
            MonoContent.Deploy(currentProject, TargetConsoleType.Pc, Path.Combine(Application.StartupPath, @"Player\Content"));
            Process.Start(@"Player\RpgeOpen.Player.exe");
        }

        private void PbMap_Paint(object sender, PaintEventArgs paintEventArgs) {
            if( currentMap == null )
                return;
            var img = (Image) currentMap.Image.Clone();

            using( var g = Graphics.FromImage( img ) ) {
                g.DrawImage( img, new Point() );

                if( tsShowGrid.Checked ) {
                    for( var i = 1; i < (img.Width / currentMap.TileSize.Width ); i++ ) {
                        g.DrawLine(
                            Pens.Red, new Point(currentMap.TileSize.Width * i, 0 ),
                            new Point(currentMap.TileSize.Width * i, img.Height ) );
                    }

                    for( var i = 1; i < (img.Height / currentMap.TileSize.Height ); i++ ) {
                        g.DrawLine(
                            Pens.Red, new Point( 0, currentMap.TileSize.Height * i ),
                            new Point(img.Width, currentMap.TileSize.Width * i ) );
                    }
                }
            }

            paintEventArgs.Graphics.DrawImage(img, new Point());
        }

        private void tsShowGrid_Click(object sender, EventArgs e)
        {
            PbMap.Invalidate();
        }
    }
}
