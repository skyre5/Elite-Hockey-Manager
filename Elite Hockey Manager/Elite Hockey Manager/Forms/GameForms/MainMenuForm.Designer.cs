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
            this.leagueLeadersStatsControl = new Elite_Hockey_Manager.Classes.LeagueComponents.LeagueControls.PlayerStuff.StatsControls.StatsControl();
            this.simLeagueControl = new Elite_Hockey_Manager.Classes.LeagueComponents.LeagueControls.SimLeagueControls.SimLeagueRegularSeasonControl();
            this.leagueGamesDisplay = new Elite_Hockey_Manager.Classes.LeagueComponents.LeagueControls.LeagueGamesDisplayControl();
            this.standingsControl = new Elite_Hockey_Manager.Classes.LeagueComponents.StandingsControl();
            this.SuspendLayout();
            // 
            // simLeagueBackgroundWorker
            // 
            this.simLeagueBackgroundWorker.WorkerReportsProgress = true;
            this.simLeagueBackgroundWorker.WorkerSupportsCancellation = true;
            this.simLeagueBackgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.simLeagueBackgroundWorker_ProgressChanged);
            this.simLeagueBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.simLeagueBackgroundWorker_RunWorkerCompleted);
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
            // leagueLeadersStatsControl
            // 
            this.leagueLeadersStatsControl.AutoSize = true;
            this.leagueLeadersStatsControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.leagueLeadersStatsControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.leagueLeadersStatsControl.DisplayTeamAbbreviation = true;
            this.leagueLeadersStatsControl.DisplayType = Elite_Hockey_Manager.Classes.LeagueComponents.LeagueControls.StatsDisplayType.Skater;
            this.leagueLeadersStatsControl.Location = new System.Drawing.Point(476, 12);
            this.leagueLeadersStatsControl.Name = "leagueLeadersStatsControl";
            this.leagueLeadersStatsControl.Size = new System.Drawing.Size(748, 284);
            this.leagueLeadersStatsControl.TabIndex = 3;
            this.leagueLeadersStatsControl.Title = "Team Name / League Name";
            // 
            // simLeagueControl
            // 
            this.simLeagueControl.Location = new System.Drawing.Point(476, 303);
            this.simLeagueControl.Name = "simLeagueControl";
            this.simLeagueControl.Size = new System.Drawing.Size(360, 50);
            this.simLeagueControl.TabIndex = 2;
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
            this.standingsControl.Location = new System.Drawing.Point(12, 12);
            this.standingsControl.Name = "standingsControl";
            this.standingsControl.Size = new System.Drawing.Size(458, 341);
            this.standingsControl.TabIndex = 0;
            // 
            // MainMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1228, 586);
            this.Controls.Add(this.simProgressLabel);
            this.Controls.Add(this.simProgressBar);
            this.Controls.Add(this.leagueLeadersStatsControl);
            this.Controls.Add(this.simLeagueControl);
            this.Controls.Add(this.leagueGamesDisplay);
            this.Controls.Add(this.standingsControl);
            this.Name = "MainMenuForm";
            this.Load += new System.EventHandler(this.MainMenuForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Classes.LeagueComponents.StandingsControl standingsControl;
        private Classes.LeagueComponents.LeagueControls.LeagueGamesDisplayControl leagueGamesDisplay;
        private Classes.LeagueComponents.LeagueControls.SimLeagueControls.SimLeagueRegularSeasonControl simLeagueControl;
        private Classes.LeagueComponents.LeagueControls.PlayerStuff.StatsControls.StatsControl leagueLeadersStatsControl;
        private System.ComponentModel.BackgroundWorker simLeagueBackgroundWorker;
        private System.Windows.Forms.ProgressBar simProgressBar;
        private System.Windows.Forms.Label simProgressLabel;
    }
}