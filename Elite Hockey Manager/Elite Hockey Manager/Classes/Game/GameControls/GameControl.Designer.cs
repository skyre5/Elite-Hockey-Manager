namespace Elite_Hockey_Manager.Classes.Game.GameControls
{
    partial class GameControl
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
            this.periodLabel = new System.Windows.Forms.Label();
            this.timeLabel = new System.Windows.Forms.Label();
            this.scoreLabel = new System.Windows.Forms.Label();
            this.homeLineControl1 = new Elite_Hockey_Manager.Classes.Game.GameControls.HomeLineControl();
            this.awayLineControl1 = new Elite_Hockey_Manager.Classes.Game.GameControls.AwayLineControl();
            this.homeTeamLabel = new System.Windows.Forms.Label();
            this.awayTeamLabel = new System.Windows.Forms.Label();
            this.statsTabControl = new System.Windows.Forms.TabControl();
            this.homePlayersPage = new System.Windows.Forms.TabPage();
            this.awayPlayersPage = new System.Windows.Forms.TabPage();
            this.shotCounterControl1 = new Elite_Hockey_Manager.Classes.Game.GameControls.ShotCounterControl();
            this.eventsTabControl = new System.Windows.Forms.TabControl();
            this.allEventsPage = new System.Windows.Forms.TabPage();
            this.goalsPage = new System.Windows.Forms.TabPage();
            this.penaltiesPage = new System.Windows.Forms.TabPage();
            this.shotPage = new System.Windows.Forms.TabPage();
            this.statsTabControl.SuspendLayout();
            this.eventsTabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // periodLabel
            // 
            this.periodLabel.AutoSize = true;
            this.periodLabel.Location = new System.Drawing.Point(14, 15);
            this.periodLabel.Name = "periodLabel";
            this.periodLabel.Size = new System.Drawing.Size(49, 13);
            this.periodLabel.TabIndex = 0;
            this.periodLabel.Text = "Period: 1";
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.Location = new System.Drawing.Point(320, 15);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(63, 13);
            this.timeLabel.TabIndex = 1;
            this.timeLabel.Text = "Time: 20:00";
            // 
            // scoreLabel
            // 
            this.scoreLabel.AutoSize = true;
            this.scoreLabel.Location = new System.Drawing.Point(135, 15);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(77, 13);
            this.scoreLabel.TabIndex = 2;
            this.scoreLabel.Text = "ABR 1 - 0 AAA";
            // 
            // homeLineControl1
            // 
            this.homeLineControl1.Location = new System.Drawing.Point(106, 214);
            this.homeLineControl1.Name = "homeLineControl1";
            this.homeLineControl1.Size = new System.Drawing.Size(242, 139);
            this.homeLineControl1.TabIndex = 3;
            // 
            // awayLineControl1
            // 
            this.awayLineControl1.Location = new System.Drawing.Point(106, 69);
            this.awayLineControl1.Name = "awayLineControl1";
            this.awayLineControl1.Size = new System.Drawing.Size(242, 139);
            this.awayLineControl1.TabIndex = 4;
            // 
            // homeTeamLabel
            // 
            this.homeTeamLabel.AutoSize = true;
            this.homeTeamLabel.Location = new System.Drawing.Point(17, 214);
            this.homeTeamLabel.Name = "homeTeamLabel";
            this.homeTeamLabel.Size = new System.Drawing.Size(35, 13);
            this.homeTeamLabel.TabIndex = 5;
            this.homeTeamLabel.Text = "Home";
            // 
            // awayTeamLabel
            // 
            this.awayTeamLabel.AutoSize = true;
            this.awayTeamLabel.Location = new System.Drawing.Point(20, 69);
            this.awayTeamLabel.Name = "awayTeamLabel";
            this.awayTeamLabel.Size = new System.Drawing.Size(33, 13);
            this.awayTeamLabel.TabIndex = 6;
            this.awayTeamLabel.Text = "Away";
            // 
            // statsTabControl
            // 
            this.statsTabControl.Controls.Add(this.homePlayersPage);
            this.statsTabControl.Controls.Add(this.awayPlayersPage);
            this.statsTabControl.Location = new System.Drawing.Point(619, 69);
            this.statsTabControl.Name = "statsTabControl";
            this.statsTabControl.SelectedIndex = 0;
            this.statsTabControl.Size = new System.Drawing.Size(202, 387);
            this.statsTabControl.TabIndex = 7;
            // 
            // homePlayersPage
            // 
            this.homePlayersPage.Location = new System.Drawing.Point(4, 22);
            this.homePlayersPage.Name = "homePlayersPage";
            this.homePlayersPage.Padding = new System.Windows.Forms.Padding(3);
            this.homePlayersPage.Size = new System.Drawing.Size(194, 361);
            this.homePlayersPage.TabIndex = 0;
            this.homePlayersPage.Text = "Home";
            this.homePlayersPage.UseVisualStyleBackColor = true;
            // 
            // awayPlayersPage
            // 
            this.awayPlayersPage.Location = new System.Drawing.Point(4, 22);
            this.awayPlayersPage.Name = "awayPlayersPage";
            this.awayPlayersPage.Padding = new System.Windows.Forms.Padding(3);
            this.awayPlayersPage.Size = new System.Drawing.Size(194, 361);
            this.awayPlayersPage.TabIndex = 1;
            this.awayPlayersPage.Text = "Away";
            this.awayPlayersPage.UseVisualStyleBackColor = true;
            // 
            // shotCounterControl1
            // 
            this.shotCounterControl1.Location = new System.Drawing.Point(23, 370);
            this.shotCounterControl1.Name = "shotCounterControl1";
            this.shotCounterControl1.Size = new System.Drawing.Size(283, 104);
            this.shotCounterControl1.TabIndex = 8;
            // 
            // eventsTabControl
            // 
            this.eventsTabControl.Controls.Add(this.allEventsPage);
            this.eventsTabControl.Controls.Add(this.goalsPage);
            this.eventsTabControl.Controls.Add(this.penaltiesPage);
            this.eventsTabControl.Controls.Add(this.shotPage);
            this.eventsTabControl.Location = new System.Drawing.Point(377, 69);
            this.eventsTabControl.Multiline = true;
            this.eventsTabControl.Name = "eventsTabControl";
            this.eventsTabControl.SelectedIndex = 0;
            this.eventsTabControl.Size = new System.Drawing.Size(226, 383);
            this.eventsTabControl.TabIndex = 9;
            // 
            // allEventsPage
            // 
            this.allEventsPage.Location = new System.Drawing.Point(4, 22);
            this.allEventsPage.Name = "allEventsPage";
            this.allEventsPage.Padding = new System.Windows.Forms.Padding(3);
            this.allEventsPage.Size = new System.Drawing.Size(218, 357);
            this.allEventsPage.TabIndex = 0;
            this.allEventsPage.Text = "All Events";
            this.allEventsPage.UseVisualStyleBackColor = true;
            // 
            // goalsPage
            // 
            this.goalsPage.Location = new System.Drawing.Point(4, 22);
            this.goalsPage.Name = "goalsPage";
            this.goalsPage.Padding = new System.Windows.Forms.Padding(3);
            this.goalsPage.Size = new System.Drawing.Size(218, 357);
            this.goalsPage.TabIndex = 1;
            this.goalsPage.Text = "Goals";
            this.goalsPage.UseVisualStyleBackColor = true;
            this.goalsPage.Click += new System.EventHandler(this.goalsTab_Click);
            // 
            // penaltiesPage
            // 
            this.penaltiesPage.Location = new System.Drawing.Point(4, 22);
            this.penaltiesPage.Name = "penaltiesPage";
            this.penaltiesPage.Padding = new System.Windows.Forms.Padding(3);
            this.penaltiesPage.Size = new System.Drawing.Size(218, 357);
            this.penaltiesPage.TabIndex = 2;
            this.penaltiesPage.Text = "Penalties";
            this.penaltiesPage.UseVisualStyleBackColor = true;
            // 
            // shotPage
            // 
            this.shotPage.Location = new System.Drawing.Point(4, 22);
            this.shotPage.Name = "shotPage";
            this.shotPage.Padding = new System.Windows.Forms.Padding(3);
            this.shotPage.Size = new System.Drawing.Size(218, 357);
            this.shotPage.TabIndex = 3;
            this.shotPage.Text = "Shots";
            this.shotPage.UseVisualStyleBackColor = true;
            // 
            // GameControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.eventsTabControl);
            this.Controls.Add(this.shotCounterControl1);
            this.Controls.Add(this.statsTabControl);
            this.Controls.Add(this.awayTeamLabel);
            this.Controls.Add(this.homeTeamLabel);
            this.Controls.Add(this.awayLineControl1);
            this.Controls.Add(this.homeLineControl1);
            this.Controls.Add(this.scoreLabel);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.periodLabel);
            this.Name = "GameControl";
            this.Size = new System.Drawing.Size(847, 486);
            this.statsTabControl.ResumeLayout(false);
            this.eventsTabControl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label periodLabel;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.Label scoreLabel;
        private HomeLineControl homeLineControl1;
        private AwayLineControl awayLineControl1;
        private System.Windows.Forms.Label homeTeamLabel;
        private System.Windows.Forms.Label awayTeamLabel;
        private System.Windows.Forms.TabControl statsTabControl;
        private System.Windows.Forms.TabPage homePlayersPage;
        private System.Windows.Forms.TabPage awayPlayersPage;
        private ShotCounterControl shotCounterControl1;
        private System.Windows.Forms.TabControl eventsTabControl;
        private System.Windows.Forms.TabPage allEventsPage;
        private System.Windows.Forms.TabPage goalsPage;
        private System.Windows.Forms.TabPage penaltiesPage;
        private System.Windows.Forms.TabPage shotPage;
    }
}
