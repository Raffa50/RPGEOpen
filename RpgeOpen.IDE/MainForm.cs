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
using RpgeOpen.IDE.Utils;
using RpgeOpen.Models;

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
            OfMapImport.InitialDirectory = Environment.GetFolderPath( Environment.SpecialFolder.MyDocuments );
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var sp= new SplashForm();
            sp.ShowDialog();
        }
    }
}
