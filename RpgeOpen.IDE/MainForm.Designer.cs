using System;

namespace RpgeOpen.IDE
{
    partial class MainForm
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MnProjectNew = new System.Windows.Forms.ToolStripMenuItem();
            this.MnProjectLoad = new System.Windows.Forms.ToolStripMenuItem();
            this.MnSave = new System.Windows.Forms.ToolStripMenuItem();
            this.releaseToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pCwinosxlinuxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mapsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MnMapImport = new System.Windows.Forms.ToolStripMenuItem();
            this.enemiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MnTest = new System.Windows.Forms.ToolStripMenuItem();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportBugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.versionDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.LvMaps = new System.Windows.Forms.ListView();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.PbMap = new System.Windows.Forms.PictureBox();
            this.OfMapImport = new System.Windows.Forms.OpenFileDialog();
            this.SfNewProject = new System.Windows.Forms.SaveFileDialog();
            this.OfLoadProject = new System.Windows.Forms.OpenFileDialog();
            this.pS4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xboxOneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.switchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbMap)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.mapsToolStripMenuItem,
            this.enemiesToolStripMenuItem,
            this.MnTest,
            this.infoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnProjectNew,
            this.MnProjectLoad,
            this.MnSave,
            this.releaseToToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // MnProjectNew
            // 
            this.MnProjectNew.Image = ((System.Drawing.Image)(resources.GetObject("MnProjectNew.Image")));
            this.MnProjectNew.Name = "MnProjectNew";
            this.MnProjectNew.Size = new System.Drawing.Size(216, 26);
            this.MnProjectNew.Text = "New Project";
            this.MnProjectNew.Click += new System.EventHandler(this.newProjectToolStripMenuItem_Click);
            // 
            // MnProjectLoad
            // 
            this.MnProjectLoad.Image = ((System.Drawing.Image)(resources.GetObject("MnProjectLoad.Image")));
            this.MnProjectLoad.Name = "MnProjectLoad";
            this.MnProjectLoad.Size = new System.Drawing.Size(216, 26);
            this.MnProjectLoad.Text = "Load Project";
            this.MnProjectLoad.Click += new System.EventHandler(this.loadProjectToolStripMenuItem_Click);
            // 
            // MnSave
            // 
            this.MnSave.Enabled = false;
            this.MnSave.Image = ((System.Drawing.Image)(resources.GetObject("MnSave.Image")));
            this.MnSave.Name = "MnSave";
            this.MnSave.Size = new System.Drawing.Size(216, 26);
            this.MnSave.Text = "Save";
            this.MnSave.Click += new System.EventHandler(this.MnSave_Click);
            // 
            // releaseToToolStripMenuItem
            // 
            this.releaseToToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pCwinosxlinuxToolStripMenuItem,
            this.pS4ToolStripMenuItem,
            this.xboxOneToolStripMenuItem,
            this.switchToolStripMenuItem});
            this.releaseToToolStripMenuItem.Enabled = false;
            this.releaseToToolStripMenuItem.Name = "releaseToToolStripMenuItem";
            this.releaseToToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.releaseToToolStripMenuItem.Text = "Release to";
            // 
            // pCwinosxlinuxToolStripMenuItem
            // 
            this.pCwinosxlinuxToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("pCwinosxlinuxToolStripMenuItem.Image")));
            this.pCwinosxlinuxToolStripMenuItem.Name = "pCwinosxlinuxToolStripMenuItem";
            this.pCwinosxlinuxToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.pCwinosxlinuxToolStripMenuItem.Text = "PC (win/osx/linux)";
            // 
            // mapsToolStripMenuItem
            // 
            this.mapsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnMapImport});
            this.mapsToolStripMenuItem.Name = "mapsToolStripMenuItem";
            this.mapsToolStripMenuItem.Size = new System.Drawing.Size(57, 24);
            this.mapsToolStripMenuItem.Text = "Maps";
            // 
            // MnMapImport
            // 
            this.MnMapImport.Enabled = false;
            this.MnMapImport.Image = ((System.Drawing.Image)(resources.GetObject("MnMapImport.Image")));
            this.MnMapImport.Name = "MnMapImport";
            this.MnMapImport.Size = new System.Drawing.Size(202, 26);
            this.MnMapImport.Text = "Import from Tiled";
            this.MnMapImport.Click += new System.EventHandler(this.MiMapImport_Click);
            // 
            // enemiesToolStripMenuItem
            // 
            this.enemiesToolStripMenuItem.Name = "enemiesToolStripMenuItem";
            this.enemiesToolStripMenuItem.Size = new System.Drawing.Size(76, 24);
            this.enemiesToolStripMenuItem.Text = "Enemies";
            // 
            // MnTest
            // 
            this.MnTest.Enabled = false;
            this.MnTest.Image = ((System.Drawing.Image)(resources.GetObject("MnTest.Image")));
            this.MnTest.Name = "MnTest";
            this.MnTest.Size = new System.Drawing.Size(67, 24);
            this.MnTest.Text = "Test";
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reportBugToolStripMenuItem,
            this.versionDetailsToolStripMenuItem});
            this.infoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("infoToolStripMenuItem.Image")));
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.Size = new System.Drawing.Size(67, 24);
            this.infoToolStripMenuItem.Text = "Info";
            // 
            // reportBugToolStripMenuItem
            // 
            this.reportBugToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("reportBugToolStripMenuItem.Image")));
            this.reportBugToolStripMenuItem.Name = "reportBugToolStripMenuItem";
            this.reportBugToolStripMenuItem.Size = new System.Drawing.Size(180, 26);
            this.reportBugToolStripMenuItem.Text = "Report bug";
            this.reportBugToolStripMenuItem.Click += new System.EventHandler(this.reportBugToolStripMenuItem_Click);
            // 
            // versionDetailsToolStripMenuItem
            // 
            this.versionDetailsToolStripMenuItem.Name = "versionDetailsToolStripMenuItem";
            this.versionDetailsToolStripMenuItem.Size = new System.Drawing.Size(180, 26);
            this.versionDetailsToolStripMenuItem.Text = "Version details";
            this.versionDetailsToolStripMenuItem.Click += new System.EventHandler(this.versionDetailsToolStripMenuItem_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 28);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.LvMaps);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.flowLayoutPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(800, 422);
            this.splitContainer1.SplitterDistance = 199;
            this.splitContainer1.TabIndex = 1;
            // 
            // LvMaps
            // 
            this.LvMaps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LvMaps.Location = new System.Drawing.Point(0, 0);
            this.LvMaps.Name = "LvMaps";
            this.LvMaps.Size = new System.Drawing.Size(199, 422);
            this.LvMaps.TabIndex = 0;
            this.LvMaps.UseCompatibleStateImageBehavior = false;
            this.LvMaps.View = System.Windows.Forms.View.List;
            this.LvMaps.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.LvMaps_ItemSelectionChanged);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Black;
            this.flowLayoutPanel1.Controls.Add(this.PbMap);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(597, 422);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // PbMap
            // 
            this.PbMap.Location = new System.Drawing.Point(3, 3);
            this.PbMap.Name = "PbMap";
            this.PbMap.Size = new System.Drawing.Size(343, 243);
            this.PbMap.TabIndex = 0;
            this.PbMap.TabStop = false;
            // 
            // OfMapImport
            // 
            this.OfMapImport.DefaultExt = "tmx";
            this.OfMapImport.FileName = "map";
            this.OfMapImport.Filter = "Tiled Map File (*.tmx)|*.tmx";
            // 
            // SfNewProject
            // 
            this.SfNewProject.DefaultExt = "rpgeo";
            this.SfNewProject.Filter = "Rpge Open Project (*.rpgeo)|*.rpgeo";
            // 
            // OfLoadProject
            // 
            this.OfLoadProject.Filter = "Rpge Open Project (*.rpgeo)|*.rpgeo";
            // 
            // pS4ToolStripMenuItem
            // 
            this.pS4ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("pS4ToolStripMenuItem.Image")));
            this.pS4ToolStripMenuItem.Name = "pS4ToolStripMenuItem";
            this.pS4ToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.pS4ToolStripMenuItem.Text = "PS4";
            // 
            // xboxOneToolStripMenuItem
            // 
            this.xboxOneToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("xboxOneToolStripMenuItem.Image")));
            this.xboxOneToolStripMenuItem.Name = "xboxOneToolStripMenuItem";
            this.xboxOneToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.xboxOneToolStripMenuItem.Text = "XboxOne";
            // 
            // switchToolStripMenuItem
            // 
            this.switchToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("switchToolStripMenuItem.Image")));
            this.switchToolStripMenuItem.Name = "switchToolStripMenuItem";
            this.switchToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.switchToolStripMenuItem.Text = "Switch";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Rpg Engine Open IDE";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PbMap)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripMenuItem MnProjectNew;
        private System.Windows.Forms.ToolStripMenuItem MnProjectLoad;
        private System.Windows.Forms.ToolStripMenuItem MnSave;
        private System.Windows.Forms.ToolStripMenuItem releaseToToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mapsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MnMapImport;
        private System.Windows.Forms.OpenFileDialog OfMapImport;
        private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog SfNewProject;
        private System.Windows.Forms.OpenFileDialog OfLoadProject;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.PictureBox PbMap;
        private System.Windows.Forms.ListView LvMaps;
        private System.Windows.Forms.ToolStripMenuItem enemiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pCwinosxlinuxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MnTest;
        private System.Windows.Forms.ToolStripMenuItem reportBugToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem versionDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pS4ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xboxOneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem switchToolStripMenuItem;
    }
}

