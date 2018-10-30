namespace Elite_Hockey_Manager.Forms.HelperForms
{
    partial class LeagueInfoForm
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
            this.leagueSizeBar = new System.Windows.Forms.TrackBar();
            this.numTeamsLabel = new System.Windows.Forms.Label();
            this.leagueNameLabel = new System.Windows.Forms.Label();
            this.leagueNameText = new System.Windows.Forms.TextBox();
            this.leagueAbbreviationLabel = new System.Windows.Forms.Label();
            this.leagueAbbreviationText = new System.Windows.Forms.TextBox();
            this.createLeagueButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.leagueSizeBar)).BeginInit();
            this.SuspendLayout();
            // 
            // leagueSizeBar
            // 
            this.leagueSizeBar.Location = new System.Drawing.Point(15, 113);
            this.leagueSizeBar.Maximum = 32;
            this.leagueSizeBar.Minimum = 6;
            this.leagueSizeBar.Name = "leagueSizeBar";
            this.leagueSizeBar.Size = new System.Drawing.Size(411, 45);
            this.leagueSizeBar.TabIndex = 0;
            this.leagueSizeBar.Value = 6;
            this.leagueSizeBar.Scroll += new System.EventHandler(this.leagueSizeBar_Scroll);
            // 
            // numTeamsLabel
            // 
            this.numTeamsLabel.AutoSize = true;
            this.numTeamsLabel.Location = new System.Drawing.Point(12, 161);
            this.numTeamsLabel.Name = "numTeamsLabel";
            this.numTeamsLabel.Size = new System.Drawing.Size(96, 13);
            this.numTeamsLabel.TabIndex = 1;
            this.numTeamsLabel.Text = "Number Of Teams:";
            // 
            // leagueNameLabel
            // 
            this.leagueNameLabel.AutoSize = true;
            this.leagueNameLabel.Location = new System.Drawing.Point(12, 20);
            this.leagueNameLabel.Name = "leagueNameLabel";
            this.leagueNameLabel.Size = new System.Drawing.Size(77, 13);
            this.leagueNameLabel.TabIndex = 2;
            this.leagueNameLabel.Text = "League Name:";
            // 
            // leagueNameText
            // 
            this.leagueNameText.Location = new System.Drawing.Point(127, 13);
            this.leagueNameText.Name = "leagueNameText";
            this.leagueNameText.Size = new System.Drawing.Size(128, 20);
            this.leagueNameText.TabIndex = 3;
            this.leagueNameText.Text = "Elite Hockey League";
            // 
            // leagueAbbreviationLabel
            // 
            this.leagueAbbreviationLabel.AutoSize = true;
            this.leagueAbbreviationLabel.Location = new System.Drawing.Point(12, 56);
            this.leagueAbbreviationLabel.Name = "leagueAbbreviationLabel";
            this.leagueAbbreviationLabel.Size = new System.Drawing.Size(108, 13);
            this.leagueAbbreviationLabel.TabIndex = 4;
            this.leagueAbbreviationLabel.Text = "League Abbreviation:";
            // 
            // leagueAbbreviationText
            // 
            this.leagueAbbreviationText.Location = new System.Drawing.Point(127, 56);
            this.leagueAbbreviationText.Name = "leagueAbbreviationText";
            this.leagueAbbreviationText.Size = new System.Drawing.Size(128, 20);
            this.leagueAbbreviationText.TabIndex = 5;
            this.leagueAbbreviationText.Text = "EHL";
            // 
            // createLeagueButton
            // 
            this.createLeagueButton.Location = new System.Drawing.Point(293, 165);
            this.createLeagueButton.Name = "createLeagueButton";
            this.createLeagueButton.Size = new System.Drawing.Size(130, 41);
            this.createLeagueButton.TabIndex = 6;
            this.createLeagueButton.Text = "Create League";
            this.createLeagueButton.UseVisualStyleBackColor = true;
            this.createLeagueButton.Click += new System.EventHandler(this.createLeagueButton_Click);
            // 
            // LeagueInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 218);
            this.Controls.Add(this.createLeagueButton);
            this.Controls.Add(this.leagueAbbreviationText);
            this.Controls.Add(this.leagueAbbreviationLabel);
            this.Controls.Add(this.leagueNameText);
            this.Controls.Add(this.leagueNameLabel);
            this.Controls.Add(this.numTeamsLabel);
            this.Controls.Add(this.leagueSizeBar);
            this.Name = "LeagueInfoForm";
            this.Text = "New League Info";
            this.Load += new System.EventHandler(this.LeagueInfoForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.leagueSizeBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar leagueSizeBar;
        private System.Windows.Forms.Label numTeamsLabel;
        private System.Windows.Forms.Label leagueNameLabel;
        private System.Windows.Forms.TextBox leagueNameText;
        private System.Windows.Forms.Label leagueAbbreviationLabel;
        private System.Windows.Forms.TextBox leagueAbbreviationText;
        private System.Windows.Forms.Button createLeagueButton;
    }
}