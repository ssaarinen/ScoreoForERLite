namespace ScoreoForERLite.App
{
    partial class SettingsDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            settingsGrid = new PropertyGrid();
            statusStrip1 = new StatusStrip();
            settingsToolStripStatusLabel = new ToolStripStatusLabel();
            menuStrip1 = new MenuStrip();
            actionsToolStripMenuItem = new ToolStripMenuItem();
            loadFromCompetitionToolStripMenuItem = new ToolStripMenuItem();
            copyToClipboardToolStripMenuItem = new ToolStripMenuItem();
            statusStrip1.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // settingsGrid
            // 
            settingsGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            settingsGrid.Location = new Point(0, 39);
            settingsGrid.Margin = new Padding(3, 30, 3, 3);
            settingsGrid.Name = "settingsGrid";
            settingsGrid.PropertySort = PropertySort.Categorized;
            settingsGrid.Size = new Size(804, 705);
            settingsGrid.TabIndex = 0;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(24, 24);
            statusStrip1.Items.AddRange(new ToolStripItem[] { settingsToolStripStatusLabel });
            statusStrip1.Location = new Point(0, 747);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(804, 32);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // settingsToolStripStatusLabel
            // 
            settingsToolStripStatusLabel.AutoToolTip = true;
            settingsToolStripStatusLabel.DoubleClickEnabled = true;
            settingsToolStripStatusLabel.Name = "settingsToolStripStatusLabel";
            settingsToolStripStatusLabel.Size = new Size(232, 25);
            settingsToolStripStatusLabel.Text = "settingsToolStripStatusLabel";
            settingsToolStripStatusLabel.Click += SettingsToolStripStatusLabel_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { actionsToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(804, 33);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip1";
            // 
            // actionsToolStripMenuItem
            // 
            actionsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { loadFromCompetitionToolStripMenuItem, copyToClipboardToolStripMenuItem });
            actionsToolStripMenuItem.Name = "actionsToolStripMenuItem";
            actionsToolStripMenuItem.Size = new Size(107, 29);
            actionsToolStripMenuItem.Text = "Toiminnot";
            // 
            // loadFromCompetitionToolStripMenuItem
            // 
            loadFromCompetitionToolStripMenuItem.Name = "loadFromCompetitionToolStripMenuItem";
            loadFromCompetitionToolStripMenuItem.Size = new Size(304, 34);
            loadFromCompetitionToolStripMenuItem.Text = "Lataa kilpailutiedostosta";
            loadFromCompetitionToolStripMenuItem.Click += LoadFromCompetitionToolStripMenuItem_Click;
            // 
            // copyToClipboardToolStripMenuItem
            // 
            copyToClipboardToolStripMenuItem.Name = "copyToClipboardToolStripMenuItem";
            copyToClipboardToolStripMenuItem.Size = new Size(304, 34);
            copyToClipboardToolStripMenuItem.Text = "Kopioi leikepöydälle";
            copyToClipboardToolStripMenuItem.Click += CopyToClipboardToolStripMenuItem_Click;
            // 
            // SettingsDialog
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(804, 779);
            Controls.Add(menuStrip1);
            Controls.Add(statusStrip1);
            Controls.Add(settingsGrid);
            MainMenuStrip = menuStrip1;
            MinimizeBox = false;
            MinimumSize = new Size(800, 0);
            Name = "SettingsDialog";
            Text = "Asetukset";
            TopMost = true;
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PropertyGrid settingsGrid;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel settingsToolStripStatusLabel;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem actionsToolStripMenuItem;
        private ToolStripMenuItem loadFromCompetitionToolStripMenuItem;
        private ToolStripMenuItem copyToClipboardToolStripMenuItem;
    }
}