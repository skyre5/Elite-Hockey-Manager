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
            this.standingsControl = new Elite_Hockey_Manager.Classes.LeagueComponents.StandingsControl();
            this.leagueGamesDisplay = new Elite_Hockey_Manager.Classes.LeagueComponents.LeagueControls.LeagueGamesDisplayControl();
            this.SuspendLayout();
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
            // leagueGamesDisplay
            // 
            this.leagueGamesDisplay.Location = new System.Drawing.Point(12, 413);
            this.leagueGamesDisplay.Name = "leagueGamesDisplay";
            this.leagueGamesDisplay.Size = new System.Drawing.Size(1079, 161);
            this.leagueGamesDisplay.TabIndex = 1;
            // 
            // MainMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1096, 586);
            this.Controls.Add(this.leagueGamesDisplay);
            this.Controls.Add(this.standingsControl);
            this.Name = "MainMenuForm";
            this.Load += new System.EventHandler(this.MainMenuForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Classes.LeagueComponents.StandingsControl standingsControl;
        private Classes.LeagueComponents.LeagueControls.LeagueGamesDisplayControl leagueGamesDisplay;
    }
}