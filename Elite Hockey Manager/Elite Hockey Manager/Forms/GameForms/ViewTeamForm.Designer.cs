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
            // playerStatsControl1
            // 
            this.playerStatsControl1.AutoSize = true;
            this.playerStatsControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.playerStatsControl1.DisplayLength = Elite_Hockey_Manager.Classes.LeagueComponents.LeagueControls.StatsDisplayLength.Long;
            this.playerStatsControl1.DisplayType = Elite_Hockey_Manager.Classes.LeagueComponents.LeagueControls.StatsDisplayType.Skater;
            this.playerStatsControl1.Location = new System.Drawing.Point(292, 297);
            this.playerStatsControl1.Name = "playerStatsControl1";
            this.playerStatsControl1.Size = new System.Drawing.Size(743, 181);
            this.playerStatsControl1.TabIndex = 2;
            // 
            // ViewTeamForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1059, 512);
            this.Controls.Add(this.playerStatsControl1);
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
        private Classes.LeagueComponents.LeagueControls.PlayerStatsControl playerStatsControl1;
    }
}