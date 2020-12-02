namespace Elite_Hockey_Manager.Forms
{
    partial class ImportForm
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
            this.firstConferenceLabel = new System.Windows.Forms.Label();
            this.secondConferenceLabel = new System.Windows.Forms.Label();
            this.statusLabel = new System.Windows.Forms.Label();
            this.startGameButton = new System.Windows.Forms.Button();
            this.importButton = new System.Windows.Forms.Button();
            this.importLeagueBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.importProgressBar = new System.Windows.Forms.ProgressBar();
            this.selectSeasonComboBox = new System.Windows.Forms.ComboBox();
            this.seasonLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // firstConferenceLabel
            // 
            this.firstConferenceLabel.Location = new System.Drawing.Point(185, 9);
            this.firstConferenceLabel.Name = "firstConferenceLabel";
            this.firstConferenceLabel.Size = new System.Drawing.Size(162, 302);
            this.firstConferenceLabel.TabIndex = 0;
            this.firstConferenceLabel.Text = "First Conference:";
            // 
            // secondConferenceLabel
            // 
            this.secondConferenceLabel.Location = new System.Drawing.Point(354, 9);
            this.secondConferenceLabel.Name = "secondConferenceLabel";
            this.secondConferenceLabel.Size = new System.Drawing.Size(131, 302);
            this.secondConferenceLabel.TabIndex = 1;
            this.secondConferenceLabel.Text = "Second Conference:";
            // 
            // statusLabel
            // 
            this.statusLabel.Location = new System.Drawing.Point(12, 9);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(137, 85);
            this.statusLabel.TabIndex = 2;
            this.statusLabel.Text = "Import Status:";
            // 
            // startGameButton
            // 
            this.startGameButton.Enabled = false;
            this.startGameButton.Location = new System.Drawing.Point(163, 403);
            this.startGameButton.Name = "startGameButton";
            this.startGameButton.Size = new System.Drawing.Size(134, 23);
            this.startGameButton.TabIndex = 3;
            this.startGameButton.Text = "Create League";
            this.startGameButton.UseVisualStyleBackColor = true;
            this.startGameButton.Click += new System.EventHandler(this.StartGameButton_Click);
            // 
            // importButton
            // 
            this.importButton.Location = new System.Drawing.Point(13, 98);
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(124, 23);
            this.importButton.TabIndex = 4;
            this.importButton.Text = "Import League";
            this.importButton.UseVisualStyleBackColor = true;
            this.importButton.Click += new System.EventHandler(this.ImportButton_Click);
            // 
            // importLeagueBackgroundWorker
            // 
            this.importLeagueBackgroundWorker.WorkerReportsProgress = true;
            this.importLeagueBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.ImportLeague_DoWork);
            this.importLeagueBackgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.ImportLeagueBackgroundWorker_ProgressChanged);
            this.importLeagueBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.ImportLeagueBackgroundWorker_RunWorkerCompleted);
            // 
            // importProgressBar
            // 
            this.importProgressBar.Location = new System.Drawing.Point(15, 128);
            this.importProgressBar.Name = "importProgressBar";
            this.importProgressBar.Size = new System.Drawing.Size(122, 23);
            this.importProgressBar.TabIndex = 5;
            // 
            // selectSeasonComboBox
            // 
            this.selectSeasonComboBox.FormattingEnabled = true;
            this.selectSeasonComboBox.Location = new System.Drawing.Point(15, 196);
            this.selectSeasonComboBox.Name = "selectSeasonComboBox";
            this.selectSeasonComboBox.Size = new System.Drawing.Size(121, 21);
            this.selectSeasonComboBox.TabIndex = 6;
            this.selectSeasonComboBox.SelectedIndexChanged += new System.EventHandler(this.SelectSeasonComboBox_SelectedIndexChanged);
            // 
            // seasonLabel
            // 
            this.seasonLabel.AutoSize = true;
            this.seasonLabel.Location = new System.Drawing.Point(15, 177);
            this.seasonLabel.Name = "seasonLabel";
            this.seasonLabel.Size = new System.Drawing.Size(76, 13);
            this.seasonLabel.TabIndex = 7;
            this.seasonLabel.Text = "Select Season";
            // 
            // ImportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 450);
            this.Controls.Add(this.seasonLabel);
            this.Controls.Add(this.selectSeasonComboBox);
            this.Controls.Add(this.importProgressBar);
            this.Controls.Add(this.importButton);
            this.Controls.Add(this.startGameButton);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.secondConferenceLabel);
            this.Controls.Add(this.firstConferenceLabel);
            this.Name = "ImportForm";
            this.Text = "ImportForm";
            this.Load += new System.EventHandler(this.ImportForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label firstConferenceLabel;
        private System.Windows.Forms.Label secondConferenceLabel;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Button startGameButton;
        private System.Windows.Forms.Button importButton;
        private System.ComponentModel.BackgroundWorker importLeagueBackgroundWorker;
        private System.Windows.Forms.ProgressBar importProgressBar;
        private System.Windows.Forms.ComboBox selectSeasonComboBox;
        private System.Windows.Forms.Label seasonLabel;
    }
}