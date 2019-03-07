using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    public partial class Form1 : Form {
        public string CurrentProjectDir => @"C:\Users\Reloa\Documents\RpgeOpen Projects\test";
        public string TileSheetsDir => Path.Combine( CurrentProjectDir, Project.Paths.TileSheets);

        public Form1()
        {
            InitializeComponent();
        }

        private void MiMapImport_Click(object sender, EventArgs e) {
            if( OfMapImport.ShowDialog() != DialogResult.OK )
                return;

            TiledImporter.ImportTmx(OfMapImport.FileName, CurrentProjectDir);
        }

        private void Form1_Load(object sender, EventArgs e) {
            OfMapImport.InitialDirectory = Environment.GetFolderPath( Environment.SpecialFolder.MyDocuments );
        }
    }
}
