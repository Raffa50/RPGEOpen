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
            this.mnRelease = new System.Windows.Forms.ToolStripMenuItem();
            this.MnReleasePc = new System.Windows.Forms.ToolStripMenuItem();
            this.pS4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xboxOneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.switchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mapsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MnMapImport = new System.Windows.Forms.ToolStripMenuItem();
            this.enemiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MnTest = new System.Windows.Forms.ToolStripMenuItem();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportBugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.versionDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.LvMaps = new System.Windows.Forms.ListView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsMousePos = new System.Windows.Forms.ToolStripStatusLabel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.PbMap = new System.Windows.Forms.PictureBox();
            this.OfMapImport = new System.Windows.Forms.OpenFileDialog();
            this.SfNewProject = new System.Windows.Forms.SaveFileDialog();
            this.OfLoadProject = new System.Windows.Forms.OpenFileDialog();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsShowGrid = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsCursor = new System.Windows.Forms.ToolStripButton();
            this.tsPassability = new System.Windows.Forms.ToolStripButton();
            this.tsDelete = new System.Windows.Forms.ToolStripButton();
            this.tsNoPass = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbMap)).BeginInit();
            this.toolStrip1.SuspendLayout();
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
            this.mnRelease});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // MnProjectNew
            // 
            this.MnProjectNew.Image = ((System.Drawing.Image)(resources.GetObject("MnProjectNew.Image")));
            this.MnProjectNew.Name = "MnProjectNew";
            this.MnProjectNew.Size = new System.Drawing.Size(175, 26);
            this.MnProjectNew.Text = "New Project";
            this.MnProjectNew.Click += new System.EventHandler(this.newProjectToolStripMenuItem_Click);
            // 
            // MnProjectLoad
            // 
            this.MnProjectLoad.Image = ((System.Drawing.Image)(resources.GetObject("MnProjectLoad.Image")));
            this.MnProjectLoad.Name = "MnProjectLoad";
            this.MnProjectLoad.Size = new System.Drawing.Size(175, 26);
            this.MnProjectLoad.Text = "Load Project";
            this.MnProjectLoad.Click += new System.EventHandler(this.loadProjectToolStripMenuItem_Click);
            // 
            // MnSave
            // 
            this.MnSave.Enabled = false;
            this.MnSave.Image = ((System.Drawing.Image)(resources.GetObject("MnSave.Image")));
            this.MnSave.Name = "MnSave";
            this.MnSave.Size = new System.Drawing.Size(175, 26);
            this.MnSave.Text = "Save";
            this.MnSave.Click += new System.EventHandler(this.MnSave_Click);
            // 
            // mnRelease
            // 
            this.mnRelease.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnReleasePc,
            this.pS4ToolStripMenuItem,
            this.xboxOneToolStripMenuItem,
            this.switchToolStripMenuItem});
            this.mnRelease.Enabled = false;
            this.mnRelease.Name = "mnRelease";
            this.mnRelease.Size = new System.Drawing.Size(175, 26);
            this.mnRelease.Text = "Release to";
            // 
            // MnReleasePc
            // 
            this.MnReleasePc.Image = ((System.Drawing.Image)(resources.GetObject("MnReleasePc.Image")));
            this.MnReleasePc.Name = "MnReleasePc";
            this.MnReleasePc.Size = new System.Drawing.Size(211, 26);
            this.MnReleasePc.Text = "PC (win/osx/linux)";
            // 
            // pS4ToolStripMenuItem
            // 
            this.pS4ToolStripMenuItem.Enabled = false;
            this.pS4ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("pS4ToolStripMenuItem.Image")));
            this.pS4ToolStripMenuItem.Name = "pS4ToolStripMenuItem";
            this.pS4ToolStripMenuItem.Size = new System.Drawing.Size(211, 26);
            this.pS4ToolStripMenuItem.Text = "PS4";
            // 
            // xboxOneToolStripMenuItem
            // 
            this.xboxOneToolStripMenuItem.Enabled = false;
            this.xboxOneToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("xboxOneToolStripMenuItem.Image")));
            this.xboxOneToolStripMenuItem.Name = "xboxOneToolStripMenuItem";
            this.xboxOneToolStripMenuItem.Size = new System.Drawing.Size(211, 26);
            this.xboxOneToolStripMenuItem.Text = "XboxOne";
            // 
            // switchToolStripMenuItem
            // 
            this.switchToolStripMenuItem.Enabled = false;
            this.switchToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("switchToolStripMenuItem.Image")));
            this.switchToolStripMenuItem.Name = "switchToolStripMenuItem";
            this.switchToolStripMenuItem.Size = new System.Drawing.Size(211, 26);
            this.switchToolStripMenuItem.Text = "Switch";
            // 
            // mapsToolStripMenuItem
            // 
            this.mapsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnMapImport});
            this.mapsToolStripMenuItem.Name = "mapsToolStripMenuItem";
            this.mapsToolStripMenuItem.Size = new System.Drawing.Size(59, 24);
            this.mapsToolStripMenuItem.Text = "Maps";
            // 
            // MnMapImport
            // 
            this.MnMapImport.Enabled = false;
            this.MnMapImport.Image = ((System.Drawing.Image)(resources.GetObject("MnMapImport.Image")));
            this.MnMapImport.Name = "MnMapImport";
            this.MnMapImport.Size = new System.Drawing.Size(210, 26);
            this.MnMapImport.Text = "Import from Tiled";
            this.MnMapImport.Click += new System.EventHandler(this.MiMapImport_Click);
            // 
            // enemiesToolStripMenuItem
            // 
            this.enemiesToolStripMenuItem.Name = "enemiesToolStripMenuItem";
            this.enemiesToolStripMenuItem.Size = new System.Drawing.Size(78, 24);
            this.enemiesToolStripMenuItem.Text = "Enemies";
            // 
            // MnTest
            // 
            this.MnTest.Enabled = false;
            this.MnTest.Image = ((System.Drawing.Image)(resources.GetObject("MnTest.Image")));
            this.MnTest.Name = "MnTest";
            this.MnTest.Size = new System.Drawing.Size(69, 24);
            this.MnTest.Text = "Test";
            this.MnTest.Click += new System.EventHandler(this.MnTest_Click);
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reportBugToolStripMenuItem,
            this.versionDetailsToolStripMenuItem});
            this.infoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("infoToolStripMenuItem.Image")));
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.Size = new System.Drawing.Size(69, 24);
            this.infoToolStripMenuItem.Text = "Info";
            // 
            // reportBugToolStripMenuItem
            // 
            this.reportBugToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("reportBugToolStripMenuItem.Image")));
            this.reportBugToolStripMenuItem.Name = "reportBugToolStripMenuItem";
            this.reportBugToolStripMenuItem.Size = new System.Drawing.Size(188, 26);
            this.reportBugToolStripMenuItem.Text = "Report bug";
            this.reportBugToolStripMenuItem.Click += new System.EventHandler(this.reportBugToolStripMenuItem_Click);
            // 
            // versionDetailsToolStripMenuItem
            // 
            this.versionDetailsToolStripMenuItem.Name = "versionDetailsToolStripMenuItem";
            this.versionDetailsToolStripMenuItem.Size = new System.Drawing.Size(188, 26);
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
            this.splitContainer1.Panel2.Controls.Add(this.statusStrip1);
            this.splitContainer1.Panel2.Controls.Add(this.flowLayoutPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(800, 445);
            this.splitContainer1.SplitterDistance = 199;
            this.splitContainer1.TabIndex = 1;
            // 
            // LvMaps
            // 
            this.LvMaps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LvMaps.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LvMaps.Location = new System.Drawing.Point(0, 0);
            this.LvMaps.Name = "LvMaps";
            this.LvMaps.Size = new System.Drawing.Size(199, 445);
            this.LvMaps.TabIndex = 0;
            this.LvMaps.UseCompatibleStateImageBehavior = false;
            this.LvMaps.View = System.Windows.Forms.View.List;
            this.LvMaps.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.LvMaps_ItemSelectionChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsMousePos});
            this.statusStrip1.Location = new System.Drawing.Point(0, 419);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(597, 26);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsMousePos
            // 
            this.tsMousePos.Name = "tsMousePos";
            this.tsMousePos.Size = new System.Drawing.Size(57, 20);
            this.tsMousePos.Text = "x: 0 y: 0";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Black;
            this.flowLayoutPanel1.Controls.Add(this.PbMap);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(564, 420);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // PbMap
            // 
            this.PbMap.Location = new System.Drawing.Point(3, 3);
            this.PbMap.Name = "PbMap";
            this.PbMap.Size = new System.Drawing.Size(50, 54);
            this.PbMap.TabIndex = 0;
            this.PbMap.TabStop = false;
            this.PbMap.Paint += new System.Windows.Forms.PaintEventHandler(this.PbMap_Paint);
            this.PbMap.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PbMap_MouseMove);
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
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Right;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsShowGrid,
            this.toolStripSeparator1,
            this.tsCursor,
            this.tsPassability,
            this.tsDelete,
            this.tsNoPass});
            this.toolStrip1.Location = new System.Drawing.Point(760, 28);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(40, 445);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsShowGrid
            // 
            this.tsShowGrid.CheckOnClick = true;
            this.tsShowGrid.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsShowGrid.Image = ((System.Drawing.Image)(resources.GetObject("tsShowGrid.Image")));
            this.tsShowGrid.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsShowGrid.Name = "tsShowGrid";
            this.tsShowGrid.Size = new System.Drawing.Size(37, 24);
            this.tsShowGrid.Text = "Show Grid";
            this.tsShowGrid.Click += new System.EventHandler(this.tsShowGrid_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(37, 6);
            // 
            // tsCursor
            // 
            this.tsCursor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsCursor.Image = ((System.Drawing.Image)(resources.GetObject("tsCursor.Image")));
            this.tsCursor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsCursor.Name = "tsCursor";
            this.tsCursor.Size = new System.Drawing.Size(37, 24);
            this.tsCursor.Text = "Back to cursor";
            this.tsCursor.Click += new System.EventHandler(this.TsCursor_Click);
            // 
            // tsPassability
            // 
            this.tsPassability.Checked = true;
            this.tsPassability.CheckOnClick = true;
            this.tsPassability.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsPassability.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsPassability.Image = ((System.Drawing.Image)(resources.GetObject("tsPassability.Image")));
            this.tsPassability.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsPassability.Name = "tsPassability";
            this.tsPassability.Size = new System.Drawing.Size(37, 24);
            this.tsPassability.Text = "toolStripButton1";
            this.tsPassability.ToolTipText = "Show passability";
            this.tsPassability.Click += new System.EventHandler(this.TsPassability_Click);
            // 
            // tsDelete
            // 
            this.tsDelete.CheckOnClick = true;
            this.tsDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsDelete.Image = ((System.Drawing.Image)(resources.GetObject("tsDelete.Image")));
            this.tsDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsDelete.Name = "tsDelete";
            this.tsDelete.Size = new System.Drawing.Size(37, 24);
            this.tsDelete.Text = "Delete";
            this.tsDelete.Click += new System.EventHandler(this.TsPassabilitySelector_Click);
            // 
            // tsNoPass
            // 
            this.tsNoPass.CheckOnClick = true;
            this.tsNoPass.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsNoPass.Image = global::RpgeOpen.IDE.Properties.Resources.no_entry;
            this.tsNoPass.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsNoPass.Name = "tsNoPass";
            this.tsNoPass.Size = new System.Drawing.Size(37, 24);
            this.tsNoPass.Text = "No pass";
            this.tsNoPass.Click += new System.EventHandler(this.TsPassabilitySelector_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 473);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Rpg Engine Open IDE";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PbMap)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
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
        private System.Windows.Forms.ToolStripMenuItem mnRelease;
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
        private System.Windows.Forms.ToolStripMenuItem MnReleasePc;
        private System.Windows.Forms.ToolStripMenuItem MnTest;
        private System.Windows.Forms.ToolStripMenuItem reportBugToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem versionDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pS4ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xboxOneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem switchToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsShowGrid;
        private System.Windows.Forms.ToolStripButton tsNoPass;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsDelete;
        private System.Windows.Forms.ToolStripButton tsCursor;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsMousePos;
        private System.Windows.Forms.ToolStripButton tsPassability;
    }
}

