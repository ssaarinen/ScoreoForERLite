namespace ScoreoForERLite.App
{
    partial class ExportToHtmlDialog
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox textBoxResultsFile;
        private System.Windows.Forms.Label labelResultsFile;
        private System.Windows.Forms.Button buttonBrowseResults;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            textBoxResultsFile = new TextBox();
            labelResultsFile = new Label();
            buttonBrowseResults = new Button();
            buttonOk = new Button();
            buttonCancel = new Button();
            textBoxResultsTitle = new TextBox();
            labelResultsTitle = new Label();
            buttonBrowseSplits = new Button();
            textBoxSplitsFile = new TextBox();
            labelSplitsFile = new Label();
            SuspendLayout();
            // 
            // textBoxResultsFile
            // 
            textBoxResultsFile.Location = new Point(208, 20);
            textBoxResultsFile.Name = "textBoxResultsFile";
            textBoxResultsFile.ReadOnly = true;
            textBoxResultsFile.Size = new Size(422, 31);
            textBoxResultsFile.TabIndex = 1;
            // 
            // labelResultsFile
            // 
            labelResultsFile.Location = new Point(14, 20);
            labelResultsFile.Name = "labelResultsFile";
            labelResultsFile.Size = new Size(188, 23);
            labelResultsFile.TabIndex = 0;
            labelResultsFile.Text = "Tulostiedosto";
            // 
            // buttonBrowseResults
            // 
            buttonBrowseResults.Location = new Point(636, 20);
            buttonBrowseResults.Name = "buttonBrowseResults";
            buttonBrowseResults.Size = new Size(45, 31);
            buttonBrowseResults.TabIndex = 2;
            buttonBrowseResults.Text = "...";
            buttonBrowseResults.Click += ButtonBrowseResults_Click;
            // 
            // buttonOk
            // 
            buttonOk.DialogResult = DialogResult.OK;
            buttonOk.Location = new Point(474, 348);
            buttonOk.Name = "buttonOk";
            buttonOk.Size = new Size(79, 36);
            buttonOk.TabIndex = 10;
            buttonOk.Text = "Export";
            // 
            // buttonCancel
            // 
            buttonCancel.DialogResult = DialogResult.Cancel;
            buttonCancel.Location = new Point(559, 348);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(122, 36);
            buttonCancel.TabIndex = 11;
            buttonCancel.Text = "Cancel";
            // 
            // textBoxResultsTitle
            // 
            textBoxResultsTitle.Location = new Point(208, 94);
            textBoxResultsTitle.Name = "textBoxResultsTitle";
            textBoxResultsTitle.Size = new Size(422, 31);
            textBoxResultsTitle.TabIndex = 7;
            // 
            // labelResultsTitle
            // 
            labelResultsTitle.Location = new Point(14, 94);
            labelResultsTitle.Name = "labelResultsTitle";
            labelResultsTitle.Size = new Size(188, 23);
            labelResultsTitle.TabIndex = 6;
            labelResultsTitle.Text = "Tapahtuman otsikko";
            // 
            // buttonBrowseSplits
            // 
            buttonBrowseSplits.Location = new Point(636, 57);
            buttonBrowseSplits.Name = "buttonBrowseSplits";
            buttonBrowseSplits.Size = new Size(45, 31);
            buttonBrowseSplits.TabIndex = 5;
            buttonBrowseSplits.Text = "...";
            buttonBrowseSplits.Click += ButtonBrowseSplits_Click;
            // 
            // textBoxSplitsFile
            // 
            textBoxSplitsFile.Location = new Point(208, 57);
            textBoxSplitsFile.Name = "textBoxSplitsFile";
            textBoxSplitsFile.ReadOnly = true;
            textBoxSplitsFile.Size = new Size(422, 31);
            textBoxSplitsFile.TabIndex = 4;
            // 
            // labelSplitsFile
            // 
            labelSplitsFile.Location = new Point(14, 57);
            labelSplitsFile.Name = "labelSplitsFile";
            labelSplitsFile.Size = new Size(188, 23);
            labelSplitsFile.TabIndex = 3;
            labelSplitsFile.Text = "Väliaikatiedosto";
            // 
            // ExportToHtmlDialog
            // 
            ClientSize = new Size(693, 396);
            Controls.Add(labelResultsFile);
            Controls.Add(textBoxResultsFile);
            Controls.Add(buttonBrowseResults);
            Controls.Add(labelSplitsFile);
            Controls.Add(textBoxSplitsFile);
            Controls.Add(buttonBrowseSplits);
            Controls.Add(labelResultsTitle);
            Controls.Add(textBoxResultsTitle);
            Controls.Add(buttonOk);
            Controls.Add(buttonCancel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ExportToHtmlDialog";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Export to HTML";
            TopMost = true;
            ResumeLayout(false);
            PerformLayout();
        }
        private TextBox textBoxResultsTitle;
        private Label labelResultsTitle;
        private Button buttonBrowseSplits;
        private TextBox textBoxSplitsFile;
        private Label labelSplitsFile;
    }
}