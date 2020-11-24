namespace Elite_Hockey_Manager.Forms.GameForms
{
    partial class MainMenuForm
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
            this.simLeagueBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.simProgressBar = new System.Windows.Forms.ProgressBar();
            this.simProgressLabel = new System.Windows.Forms.Label();
            this.simPlayoffBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.simLeaguePlayoffControl = new Elite_Hockey_Manager.Classes.LeagueComponents.LeagueControls.SimLeagueControls.SimLeaguePlayoffControl();
            this.playoffDisplayControl = new Elite_Hockey_Manager.Classes.LeagueComponents.LeagueControls.PlayoffDisplays.PlayoffDisplayControl();
            this.leagueLeadersStatsControl = new Elite_Hockey_Manager.Classes.LeagueComponents.LeagueControls.PlayerStuff.StatsControls.StatsControl();
            this.simLeagueRegularSeasonControl = new Elite_Hockey_Manager.Classes.LeagueComponents.LeagueControls.SimLeagueControls.SimLeagueRegularSeasonControl();
            this.leagueGamesDisplay = new Elite_Hockey_Manager.Classes.LeagueComponents.LeagueControls.LeagueGamesDisplayControl();
            this.standingsControl = new Elite_Hockey_Manager.Classes.LeagueComponents.StandingsControl();
            this.simLeagueOffseasonControl1 = new Elite_Hockey_Manager.Classes.LeagueComponents.LeagueControls.SimLeagueControls.SimLeagueOffseasonControl();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.statsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playerStatsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.currentSeasonPlayerStatsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allTimePlayerStatsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.teamMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.currentSeasonTeamStatsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allTimeTeamStatsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // simLeagueBackgroundWorker
            // 
            this.simLeagueBackgroundWorker.WorkerReportsProgress = true;
            this.simLeagueBackgroundWorker.WorkerSupportsCancellation = true;
            this.simLeagueBackgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.SimLeagueBackgroundWorker_ProgressChanged);
            this.simLeagueBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.SimLeagueBackgroundWorker_RunWorkerCompleted);
            // 
            // simProgressBar
            // 
            this.simProgressBar.Location = new System.Drawing.Point(865, 303);
            this.simProgressBar.Name = "simProgressBar";
            this.simProgressBar.Size = new System.Drawing.Size(100, 23);
            this.simProgressBar.TabIndex = 4;
            // 
            // simProgressLabel
            // 
            this.simProgressLabel.AutoSize = true;
            this.simProgressLabel.Location = new System.Drawing.Point(862, 329);
            this.simProgressLabel.Name = "simProgressLabel";
            this.simProgressLabel.Size = new System.Drawing.Size(24, 13);
            this.simProgressLabel.TabIndex = 5;
            this.simProgressLabel.Text = "0/0";
            // 
            // simPlayoffBackgroundWorker
            // 
            this.simPlayoffBackgroundWorker.WorkerReportsProgress = true;
            this.simPlayoffBackgroundWorker.WorkerSupportsCancellation = true;
            this.simPlayoffBackgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.SimPlayoffBackgroundWorker_ProgressChanged);
            this.simPlayoffBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.SimPlayoffBackgroundWorker_RunWorkerCompleted);
            // 
            // simLeaguePlayoffControl
            // 
            this.simLeaguePlayoffControl.Enabled = false;
            this.simLeaguePlayoffControl.Location = new System.Drawing.Point(476, 349);
            this.simLeaguePlayoffControl.Name = "simLeaguePlayoffControl";
            this.simLeaguePlayoffControl.Size = new System.Drawing.Size(360, 58);
            this.simLeaguePlayoffControl.TabIndex = 7;
            this.simLeaguePlayoffControl.Visible = false;
            // 
            // playoffDisplayControl
            // 
            this.playoffDisplayControl.Enabled = false;
            this.playoffDisplayControl.League = null;
            this.playoffDisplayControl.Location = new System.Drawing.Point(12, 27);
            this.playoffDisplayControl.Name = "playoffDisplayControl";
            this.playoffDisplayControl.SelectedRounds = Elite_Hockey_Manager.Classes.LeagueComponents.LeagueControls.PlayoffDisplays.PlayoffRounds.Four;
            this.playoffDisplayControl.Size = new System.Drawing.Size(966, 299);
            this.playoffDisplayControl.TabIndex = 6;
            this.playoffDisplayControl.Visible = false;
            // 
            // leagueLeadersStatsControl
            // 
            this.leagueLeadersStatsControl.AutoSize = true;
            this.leagueLeadersStatsControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.leagueLeadersStatsControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.leagueLeadersStatsControl.DisplayTeamAbbreviation = true;
            this.leagueLeadersStatsControl.DisplayType = Elite_Hockey_Manager.Classes.LeagueComponents.LeagueControls.StatsDisplayType.Skater;
            this.leagueLeadersStatsControl.Location = new System.Drawing.Point(989, -2);
            this.leagueLeadersStatsControl.Name = "leagueLeadersStatsControl";
            this.leagueLeadersStatsControl.Size = new System.Drawing.Size(748, 284);
            this.leagueLeadersStatsControl.TabIndex = 3;
            this.leagueLeadersStatsControl.Title = "Team Name / League Name";
            // 
            // simLeagueRegularSeasonControl
            // 
            this.simLeagueRegularSeasonControl.Location = new System.Drawing.Point(476, 303);
            this.simLeagueRegularSeasonControl.Name = "simLeagueRegularSeasonControl";
            this.simLeagueRegularSeasonControl.Size = new System.Drawing.Size(360, 50);
            this.simLeagueRegularSeasonControl.TabIndex = 2;
            // 
            // leagueGamesDisplay
            // 
            this.leagueGamesDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.leagueGamesDisplay.Location = new System.Drawing.Point(12, 413);
            this.leagueGamesDisplay.Name = "leagueGamesDisplay";
            this.leagueGamesDisplay.Size = new System.Drawing.Size(1079, 161);
            this.leagueGamesDisplay.TabIndex = 1;
            // 
            // standingsControl
            // 
            this.standingsControl.ActiveLeague = null;
            this.standingsControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.standingsControl.Location = new System.Drawing.Point(12, 63);
            this.standingsControl.Name = "standingsControl";
            this.standingsControl.Size = new System.Drawing.Size(458, 341);
            this.standingsControl.TabIndex = 0;
            // 
            // simLeagueOffseasonControl1
            // 
            this.simLeagueOffseasonControl1.Location = new System.Drawing.Point(476, 346);
            this.simLeagueOffseasonControl1.Name = "simLeagueOffseasonControl1";
            this.simLeagueOffseasonControl1.Size = new System.Drawing.Size(360, 58);
            this.simLeagueOffseasonControl1.TabIndex = 8;
            this.simLeagueOffseasonControl1.Visible = false;
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statsToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1766, 24);
            this.menuStrip.TabIndex = 9;
            this.menuStrip.Text = "menuStrip1";
            // 
            // statsToolStripMenuItem
            // 
            this.statsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playerStatsMenuItem,
            this.teamMenuItem});
            this.statsToolStripMenuItem.Name = "statsToolStripMenuItem";
            this.statsToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.statsToolStripMenuItem.Text = "Stats";
            // 
            // playerStatsMenuItem
            // 
            this.playerStatsMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.currentSeasonPlayerStatsMenuItem,
            this.allTimePlayerStatsMenuItem});
            this.playerStatsMenuItem.Name = "playerStatsMenuItem";
            this.playerStatsMenuItem.Size = new System.Drawing.Size(134, 22);
            this.playerStatsMenuItem.Text = "Player Stats";
            // 
            // currentSeasonPlayerStatsMenuItem
            // 
            this.currentSeasonPlayerStatsMenuItem.Name = "currentSeasonPlayerStatsMenuItem";
            this.currentSeasonPlayerStatsMenuItem.Size = new System.Drawing.Size(154, 22);
            this.currentSeasonPlayerStatsMenuItem.Text = "Current Season";
            // 
            // allTimePlayerStatsMenuItem
            // 
            this.allTimePlayerStatsMenuItem.Name = "allTimePlayerStatsMenuItem";
            this.allTimePlayerStatsMenuItem.Size = new System.Drawing.Size(154, 22);
            this.allTimePlayerStatsMenuItem.Text = "All Time";
            // 
            // teamMenuItem
            // 
            this.teamMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.currentSeasonTeamStatsMenuItem,
            this.allTimeTeamStatsMenuItem});
            this.teamMenuItem.Name = "teamMenuItem";
            this.teamMenuItem.Size = new System.Drawing.Size(134, 22);
            this.teamMenuItem.Text = "Team Stats";
            // 
            // currentSeasonTeamStatsMenuItem
            // 
            this.currentSeasonTeamStatsMenuItem.Name = "currentSeasonTeamStatsMenuItem";
            this.currentSeasonTeamStatsMenuItem.Size = new System.Drawing.Size(154, 22);
            this.currentSeasonTeamStatsMenuItem.Text = "Current Season";
            // 
            // allTimeTeamStatsMenuItem
            // 
            this.allTimeTeamStatsMenuItem.Name = "allTimeTeamStatsMenuItem";
            this.allTimeTeamStatsMenuItem.Size = new System.Drawing.Size(154, 22);
            this.allTimeTeamStatsMenuItem.Text = "All Time";
            // 
            // MainMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1766, 578);
            this.Controls.Add(this.simLeagueOffseasonControl1);
            this.Controls.Add(this.simLeaguePlayoffControl);
            this.Controls.Add(this.playoffDisplayControl);
            this.Controls.Add(this.simProgressLabel);
            this.Controls.Add(this.simProgressBar);
            this.Controls.Add(this.leagueLeadersStatsControl);
            this.Controls.Add(this.simLeagueRegularSeasonControl);
            this.Controls.Add(this.leagueGamesDisplay);
            this.Controls.Add(this.standingsControl);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainMenuForm";
            this.Load += new System.EventHandler(this.MainMenuForm_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Classes.LeagueComponents.StandingsControl standingsControl;
        private Classes.LeagueComponents.LeagueControls.LeagueGamesDisplayControl leagueGamesDisplay;
        private Classes.LeagueComponents.LeagueControls.SimLeagueControls.SimLeagueRegularSeasonControl simLeagueRegularSeasonControl;
        private Classes.LeagueComponents.LeagueControls.PlayerStuff.StatsControls.StatsControl leagueLeadersStatsControl;
        private System.ComponentModel.BackgroundWorker simLeagueBackgroundWorker;
        private System.Windows.Forms.ProgressBar simProgressBar;
        private System.Windows.Forms.Label simProgressLabel;
        private Classes.LeagueComponents.LeagueControls.PlayoffDisplays.PlayoffDisplayControl playoffDisplayControl;
        private Classes.LeagueComponents.LeagueControls.SimLeagueControls.SimLeaguePlayoffControl simLeaguePlayoffControl;
        private System.ComponentModel.BackgroundWorker simPlayoffBackgroundWorker;
        private Classes.LeagueComponents.LeagueControls.SimLeagueControls.SimLeagueOffseasonControl simLeagueOffseasonControl1;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem statsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playerStatsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem teamMenuItem;
        private System.Windows.Forms.ToolStripMenuItem currentSeasonPlayerStatsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allTimePlayerStatsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem currentSeasonTeamStatsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allTimeTeamStatsMenuItem;
    }
}