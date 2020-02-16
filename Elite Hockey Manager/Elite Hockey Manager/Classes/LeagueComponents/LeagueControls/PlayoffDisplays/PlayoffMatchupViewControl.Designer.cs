namespace Elite_Hockey_Manager.Classes.LeagueComponents.LeagueControls.PlayoffDisplays
{
    partial class PlayoffMatchupViewControl
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
            this.lowSeedTeamPlayoffControl = new Elite_Hockey_Manager.Classes.LeagueComponents.LeagueControls.PlayoffDisplays.TeamLogoPlayoffViewControl();
            this.highSeedTeamPlayoffControl = new Elite_Hockey_Manager.Classes.LeagueComponents.LeagueControls.PlayoffDisplays.TeamLogoPlayoffViewControl();
            this.SuspendLayout();
            // 
            // lowSeedTeamPlayoffControl
            // 
            this.lowSeedTeamPlayoffControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lowSeedTeamPlayoffControl.Location = new System.Drawing.Point(0, 38);
            this.lowSeedTeamPlayoffControl.Name = "lowSeedTeamPlayoffControl";
            this.lowSeedTeamPlayoffControl.Seed = 0;
            this.lowSeedTeamPlayoffControl.Size = new System.Drawing.Size(110, 29);
            this.lowSeedTeamPlayoffControl.TabIndex = 1;
            this.lowSeedTeamPlayoffControl.Team = null;
            this.lowSeedTeamPlayoffControl.Wins = 0;
            // 
            // highSeedTeamPlayoffControl
            // 
            this.highSeedTeamPlayoffControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.highSeedTeamPlayoffControl.Location = new System.Drawing.Point(0, 3);
            this.highSeedTeamPlayoffControl.Name = "highSeedTeamPlayoffControl";
            this.highSeedTeamPlayoffControl.Seed = 0;
            this.highSeedTeamPlayoffControl.Size = new System.Drawing.Size(110, 29);
            this.highSeedTeamPlayoffControl.TabIndex = 0;
            this.highSeedTeamPlayoffControl.Team = null;
            this.highSeedTeamPlayoffControl.Wins = 0;
            // 
            // PlayoffMatchupViewControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lowSeedTeamPlayoffControl);
            this.Controls.Add(this.highSeedTeamPlayoffControl);
            this.Name = "PlayoffMatchupViewControl";
            this.Size = new System.Drawing.Size(110, 70);
            this.ResumeLayout(false);

        }

        #endregion

        private TeamLogoPlayoffViewControl highSeedTeamPlayoffControl;
        private TeamLogoPlayoffViewControl lowSeedTeamPlayoffControl;
    }
}
