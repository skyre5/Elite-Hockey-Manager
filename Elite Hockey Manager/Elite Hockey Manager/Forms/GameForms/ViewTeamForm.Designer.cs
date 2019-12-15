namespace Elite_Hockey_Manager.Forms.GameForms
{
    partial class ViewTeamForm
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
            this.teamCapControl = new Elite_Hockey_Manager.Classes.LeagueComponents.LeagueControls.LineupControls.TeamCapControl();
            this.teamLinesControl = new Elite_Hockey_Manager.Classes.LeagueComponents.LeagueControls.TeamLinesControl();
            this.button1 = new System.Windows.Forms.Button();
            this.playerStatsControl1 = new Elite_Hockey_Manager.Classes.LeagueComponents.LeagueControls.PlayerStatsControl();
            this.SuspendLayout();
            // 
            // teamCapControl
            // 
            this.teamCapControl.Location = new System.Drawing.Point(743, 28);
            this.teamCapControl.Name = "teamCapControl";
            this.teamCapControl.SalaryCap = 50D;
            this.teamCapControl.Size = new System.Drawing.Size(184, 82);
            this.teamCapControl.TabIndex = 1;
            this.teamCapControl.Team = null;
            // 
            // teamLinesControl
            // 
            this.teamLinesControl.Location = new System.Drawing.Point(12, 12);
            this.teamLinesControl.Name = "teamLinesControl";
            this.teamLinesControl.Size = new System.Drawing.Size(662, 469);
            this.teamLinesControl.TabIndex = 0;
            this.teamLinesControl.Team = null;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(761, 201);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // playerStatsControl1
            // 
            this.playerStatsControl1.AutoSize = true;
            this.playerStatsControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.playerStatsControl1.DisplayLength = Elite_Hockey_Manager.Classes.LeagueComponents.LeagueControls.StatsDisplayLength.Long;
            this.playerStatsControl1.DisplayType = Elite_Hockey_Manager.Classes.LeagueComponents.LeagueControls.StatsDisplayType.Skater;
            this.playerStatsControl1.Location = new System.Drawing.Point(286, 278);
            this.playerStatsControl1.Name = "playerStatsControl1";
            this.playerStatsControl1.Size = new System.Drawing.Size(743, 203);
            this.playerStatsControl1.StoredGoalies = null;
            this.playerStatsControl1.StoredSkaters = null;
            this.playerStatsControl1.TabIndex = 4;
            // 
            // ViewTeamForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1059, 512);
            this.Controls.Add(this.playerStatsControl1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.teamCapControl);
            this.Controls.Add(this.teamLinesControl);
            this.Name = "ViewTeamForm";
            this.Text = "ViewTeamForm";
            this.Load += new System.EventHandler(this.ViewTeamForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion


        private Classes.LeagueComponents.LeagueControls.TeamLinesControl teamLinesControl;
        private Classes.LeagueComponents.LeagueControls.LineupControls.TeamCapControl teamCapControl;
        private System.Windows.Forms.Button button1;
        private Classes.LeagueComponents.LeagueControls.PlayerStatsControl playerStatsControl1;
    }
}