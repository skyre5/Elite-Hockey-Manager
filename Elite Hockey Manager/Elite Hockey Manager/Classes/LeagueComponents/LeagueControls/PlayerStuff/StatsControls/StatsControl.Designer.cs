namespace Elite_Hockey_Manager.Classes.LeagueComponents.LeagueControls.PlayerStuff.StatsControls
{
    partial class StatsControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.titleLabel = new System.Windows.Forms.Label();
            this.skaterStatsButton = new System.Windows.Forms.Button();
            this.goalieStatsButton = new System.Windows.Forms.Button();
            this.statsFormButton = new System.Windows.Forms.Button();
            this.playerStatsControl = new Elite_Hockey_Manager.Classes.LeagueComponents.LeagueControls.PlayerStatsControl();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.Location = new System.Drawing.Point(0, 8);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(742, 13);
            this.titleLabel.TabIndex = 1;
            this.titleLabel.Text = "Team Name / League Name";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // skaterStatsButton
            // 
            this.skaterStatsButton.Enabled = false;
            this.skaterStatsButton.Location = new System.Drawing.Point(6, 254);
            this.skaterStatsButton.Name = "skaterStatsButton";
            this.skaterStatsButton.Size = new System.Drawing.Size(75, 23);
            this.skaterStatsButton.TabIndex = 2;
            this.skaterStatsButton.Text = "Skater";
            this.skaterStatsButton.UseVisualStyleBackColor = true;
            this.skaterStatsButton.Click += new System.EventHandler(this.SkaterStatsButton_Click);
            // 
            // goalieStatsButton
            // 
            this.goalieStatsButton.Location = new System.Drawing.Point(87, 254);
            this.goalieStatsButton.Name = "goalieStatsButton";
            this.goalieStatsButton.Size = new System.Drawing.Size(75, 23);
            this.goalieStatsButton.TabIndex = 3;
            this.goalieStatsButton.Text = "Goalie";
            this.goalieStatsButton.UseVisualStyleBackColor = true;
            this.goalieStatsButton.Click += new System.EventHandler(this.GoalieStatsButton_Click);
            // 
            // statsFormButton
            // 
            this.statsFormButton.Location = new System.Drawing.Point(606, 235);
            this.statsFormButton.Name = "statsFormButton";
            this.statsFormButton.Size = new System.Drawing.Size(136, 44);
            this.statsFormButton.TabIndex = 4;
            this.statsFormButton.Text = "Open Stats Page";
            this.statsFormButton.UseVisualStyleBackColor = true;
            this.statsFormButton.Click += new System.EventHandler(this.StatsFormButton_Click);
            // 
            // playerStatsControl
            // 
            this.playerStatsControl.AutoSize = true;
            this.playerStatsControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.playerStatsControl.DisplayLength = Elite_Hockey_Manager.Classes.LeagueComponents.LeagueControls.StatsDisplayLength.Long;
            this.playerStatsControl.DisplayType = Elite_Hockey_Manager.Classes.LeagueComponents.LeagueControls.StatsDisplayType.Skater;
            this.playerStatsControl.Location = new System.Drawing.Point(-1, 24);
            this.playerStatsControl.Name = "playerStatsControl";
            this.playerStatsControl.Size = new System.Drawing.Size(743, 203);
            this.playerStatsControl.StoredGoalies = null;
            this.playerStatsControl.StoredSkaters = null;
            this.playerStatsControl.TabIndex = 0;
            // 
            // StatsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.statsFormButton);
            this.Controls.Add(this.goalieStatsButton);
            this.Controls.Add(this.skaterStatsButton);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.playerStatsControl);
            this.Name = "StatsControl";
            this.Size = new System.Drawing.Size(745, 282);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PlayerStatsControl playerStatsControl;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Button skaterStatsButton;
        private System.Windows.Forms.Button goalieStatsButton;
        private System.Windows.Forms.Button statsFormButton;
    }
}
