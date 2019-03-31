namespace Elite_Hockey_Manager.Classes.GameComponents.GameControls
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
            this.homeTeamLabel = new System.Windows.Forms.Label();
            this.awayTeamLabel = new System.Windows.Forms.Label();
            this.playersTabControl = new System.Windows.Forms.TabControl();
            this.homePlayersPage = new System.Windows.Forms.TabPage();
            this.awayPlayersPage = new System.Windows.Forms.TabPage();
            this.eventsTabControl = new System.Windows.Forms.TabControl();
            this.allEventsPage = new System.Windows.Forms.TabPage();
            this.goalsPage = new System.Windows.Forms.TabPage();
            this.penaltiesPage = new System.Windows.Forms.TabPage();
            this.shotPage = new System.Windows.Forms.TabPage();
            this.periodButton = new System.Windows.Forms.Button();
            this.gameButton = new System.Windows.Forms.Button();
            this.playButton = new System.Windows.Forms.Button();
            this.pauseButton = new System.Windows.Forms.Button();
            this.simGroupbox = new System.Windows.Forms.GroupBox();
            this.eightRadioButton = new System.Windows.Forms.RadioButton();
            this.fourRadioButton = new System.Windows.Forms.RadioButton();
            this.twoRadioButton = new System.Windows.Forms.RadioButton();
            this.oneRadioButton = new System.Windows.Forms.RadioButton();
            this.shotCounterControl1 = new Elite_Hockey_Manager.Classes.GameComponents.GameControls.ShotCounterControl();
            this.awayLineControl1 = new Elite_Hockey_Manager.Classes.GameComponents.GameControls.AwayLineControl();
            this.homeLineControl1 = new Elite_Hockey_Manager.Classes.GameComponents.GameControls.HomeLineControl();
            this.playersTabControl.SuspendLayout();
            this.eventsTabControl.SuspendLayout();
            this.simGroupbox.SuspendLayout();
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
            // playersTabControl
            // 
            this.playersTabControl.Controls.Add(this.homePlayersPage);
            this.playersTabControl.Controls.Add(this.awayPlayersPage);
            this.playersTabControl.Location = new System.Drawing.Point(744, 107);
            this.playersTabControl.Name = "playersTabControl";
            this.playersTabControl.SelectedIndex = 0;
            this.playersTabControl.Size = new System.Drawing.Size(202, 379);
            this.playersTabControl.TabIndex = 7;
            // 
            // homePlayersPage
            // 
            this.homePlayersPage.Location = new System.Drawing.Point(4, 22);
            this.homePlayersPage.Name = "homePlayersPage";
            this.homePlayersPage.Padding = new System.Windows.Forms.Padding(3);
            this.homePlayersPage.Size = new System.Drawing.Size(194, 353);
            this.homePlayersPage.TabIndex = 0;
            this.homePlayersPage.Text = "Home";
            this.homePlayersPage.UseVisualStyleBackColor = true;
            // 
            // awayPlayersPage
            // 
            this.awayPlayersPage.Location = new System.Drawing.Point(4, 22);
            this.awayPlayersPage.Name = "awayPlayersPage";
            this.awayPlayersPage.Padding = new System.Windows.Forms.Padding(3);
            this.awayPlayersPage.Size = new System.Drawing.Size(194, 353);
            this.awayPlayersPage.TabIndex = 1;
            this.awayPlayersPage.Text = "Away";
            this.awayPlayersPage.UseVisualStyleBackColor = true;
            // 
            // eventsTabControl
            // 
            this.eventsTabControl.Controls.Add(this.allEventsPage);
            this.eventsTabControl.Controls.Add(this.goalsPage);
            this.eventsTabControl.Controls.Add(this.penaltiesPage);
            this.eventsTabControl.Controls.Add(this.shotPage);
            this.eventsTabControl.Location = new System.Drawing.Point(385, 107);
            this.eventsTabControl.Multiline = true;
            this.eventsTabControl.Name = "eventsTabControl";
            this.eventsTabControl.SelectedIndex = 0;
            this.eventsTabControl.Size = new System.Drawing.Size(353, 379);
            this.eventsTabControl.TabIndex = 9;
            this.eventsTabControl.SelectedIndexChanged += new System.EventHandler(this.eventsTabControl_SelectedIndexChanged);
            // 
            // allEventsPage
            // 
            this.allEventsPage.AutoScroll = true;
            this.allEventsPage.Location = new System.Drawing.Point(4, 22);
            this.allEventsPage.Name = "allEventsPage";
            this.allEventsPage.Padding = new System.Windows.Forms.Padding(3);
            this.allEventsPage.Size = new System.Drawing.Size(345, 353);
            this.allEventsPage.TabIndex = 0;
            this.allEventsPage.Text = "All Events";
            this.allEventsPage.UseVisualStyleBackColor = true;
            // 
            // goalsPage
            // 
            this.goalsPage.Location = new System.Drawing.Point(4, 22);
            this.goalsPage.Name = "goalsPage";
            this.goalsPage.Padding = new System.Windows.Forms.Padding(3);
            this.goalsPage.Size = new System.Drawing.Size(345, 353);
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
            this.penaltiesPage.Size = new System.Drawing.Size(345, 353);
            this.penaltiesPage.TabIndex = 2;
            this.penaltiesPage.Text = "Penalties";
            this.penaltiesPage.UseVisualStyleBackColor = true;
            // 
            // shotPage
            // 
            this.shotPage.Location = new System.Drawing.Point(4, 22);
            this.shotPage.Name = "shotPage";
            this.shotPage.Padding = new System.Windows.Forms.Padding(3);
            this.shotPage.Size = new System.Drawing.Size(345, 353);
            this.shotPage.TabIndex = 3;
            this.shotPage.Text = "Shots";
            this.shotPage.UseVisualStyleBackColor = true;
            // 
            // periodButton
            // 
            this.periodButton.Location = new System.Drawing.Point(102, 48);
            this.periodButton.Name = "periodButton";
            this.periodButton.Size = new System.Drawing.Size(75, 23);
            this.periodButton.TabIndex = 14;
            this.periodButton.Text = "Sim Period";
            this.periodButton.UseVisualStyleBackColor = true;
            // 
            // gameButton
            // 
            this.gameButton.Location = new System.Drawing.Point(189, 48);
            this.gameButton.Name = "gameButton";
            this.gameButton.Size = new System.Drawing.Size(75, 23);
            this.gameButton.TabIndex = 15;
            this.gameButton.Text = "Sim Game";
            this.gameButton.UseVisualStyleBackColor = true;
            // 
            // playButton
            // 
            this.playButton.Location = new System.Drawing.Point(21, 19);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(75, 23);
            this.playButton.TabIndex = 16;
            this.playButton.Text = "▶";
            this.playButton.UseVisualStyleBackColor = true;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            // 
            // pauseButton
            // 
            this.pauseButton.Location = new System.Drawing.Point(21, 48);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(75, 23);
            this.pauseButton.TabIndex = 17;
            this.pauseButton.Text = "❚❚";
            this.pauseButton.UseVisualStyleBackColor = true;
            this.pauseButton.Click += new System.EventHandler(this.pauseButton_Click);
            // 
            // simGroupbox
            // 
            this.simGroupbox.Controls.Add(this.eightRadioButton);
            this.simGroupbox.Controls.Add(this.fourRadioButton);
            this.simGroupbox.Controls.Add(this.twoRadioButton);
            this.simGroupbox.Controls.Add(this.oneRadioButton);
            this.simGroupbox.Controls.Add(this.playButton);
            this.simGroupbox.Controls.Add(this.gameButton);
            this.simGroupbox.Controls.Add(this.pauseButton);
            this.simGroupbox.Controls.Add(this.periodButton);
            this.simGroupbox.Location = new System.Drawing.Point(389, 3);
            this.simGroupbox.Name = "simGroupbox";
            this.simGroupbox.Size = new System.Drawing.Size(428, 89);
            this.simGroupbox.TabIndex = 19;
            this.simGroupbox.TabStop = false;
            this.simGroupbox.Text = "Sim Controls";
            // 
            // eightRadioButton
            // 
            this.eightRadioButton.AutoSize = true;
            this.eightRadioButton.Location = new System.Drawing.Point(233, 25);
            this.eightRadioButton.Name = "eightRadioButton";
            this.eightRadioButton.Size = new System.Drawing.Size(38, 17);
            this.eightRadioButton.TabIndex = 21;
            this.eightRadioButton.Text = "8X";
            this.eightRadioButton.UseVisualStyleBackColor = true;
            this.eightRadioButton.CheckedChanged += new System.EventHandler(this.eightRadioButton_CheckedChanged);
            // 
            // fourRadioButton
            // 
            this.fourRadioButton.AutoSize = true;
            this.fourRadioButton.Location = new System.Drawing.Point(189, 25);
            this.fourRadioButton.Name = "fourRadioButton";
            this.fourRadioButton.Size = new System.Drawing.Size(38, 17);
            this.fourRadioButton.TabIndex = 20;
            this.fourRadioButton.Text = "4X";
            this.fourRadioButton.UseVisualStyleBackColor = true;
            this.fourRadioButton.CheckedChanged += new System.EventHandler(this.fourRadioButton_CheckedChanged);
            // 
            // twoRadioButton
            // 
            this.twoRadioButton.AutoSize = true;
            this.twoRadioButton.Location = new System.Drawing.Point(147, 25);
            this.twoRadioButton.Name = "twoRadioButton";
            this.twoRadioButton.Size = new System.Drawing.Size(38, 17);
            this.twoRadioButton.TabIndex = 19;
            this.twoRadioButton.Text = "2X";
            this.twoRadioButton.UseVisualStyleBackColor = true;
            this.twoRadioButton.CheckedChanged += new System.EventHandler(this.twoRadioButton_CheckedChanged);
            // 
            // oneRadioButton
            // 
            this.oneRadioButton.AutoSize = true;
            this.oneRadioButton.Checked = true;
            this.oneRadioButton.Location = new System.Drawing.Point(103, 25);
            this.oneRadioButton.Name = "oneRadioButton";
            this.oneRadioButton.Size = new System.Drawing.Size(38, 17);
            this.oneRadioButton.TabIndex = 18;
            this.oneRadioButton.TabStop = true;
            this.oneRadioButton.Text = "1X";
            this.oneRadioButton.UseVisualStyleBackColor = true;
            this.oneRadioButton.CheckedChanged += new System.EventHandler(this.oneRadioButton_CheckedChanged);
            // 
            // shotCounterControl1
            // 
            this.shotCounterControl1.Location = new System.Drawing.Point(23, 370);
            this.shotCounterControl1.Name = "shotCounterControl1";
            this.shotCounterControl1.Size = new System.Drawing.Size(283, 104);
            this.shotCounterControl1.TabIndex = 8;
            // 
            // awayLineControl1
            // 
            this.awayLineControl1.Location = new System.Drawing.Point(106, 69);
            this.awayLineControl1.Name = "awayLineControl1";
            this.awayLineControl1.Size = new System.Drawing.Size(242, 139);
            this.awayLineControl1.TabIndex = 4;
            // 
            // homeLineControl1
            // 
            this.homeLineControl1.Location = new System.Drawing.Point(106, 214);
            this.homeLineControl1.Name = "homeLineControl1";
            this.homeLineControl1.Size = new System.Drawing.Size(242, 139);
            this.homeLineControl1.TabIndex = 3;
            // 
            // GameControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.simGroupbox);
            this.Controls.Add(this.eventsTabControl);
            this.Controls.Add(this.shotCounterControl1);
            this.Controls.Add(this.playersTabControl);
            this.Controls.Add(this.awayTeamLabel);
            this.Controls.Add(this.homeTeamLabel);
            this.Controls.Add(this.awayLineControl1);
            this.Controls.Add(this.homeLineControl1);
            this.Controls.Add(this.scoreLabel);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.periodLabel);
            this.Name = "GameControl";
            this.Size = new System.Drawing.Size(949, 524);
            this.playersTabControl.ResumeLayout(false);
            this.eventsTabControl.ResumeLayout(false);
            this.simGroupbox.ResumeLayout(false);
            this.simGroupbox.PerformLayout();
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
        private System.Windows.Forms.TabControl playersTabControl;
        private System.Windows.Forms.TabPage homePlayersPage;
        private System.Windows.Forms.TabPage awayPlayersPage;
        private ShotCounterControl shotCounterControl1;
        private System.Windows.Forms.TabControl eventsTabControl;
        private System.Windows.Forms.TabPage allEventsPage;
        private System.Windows.Forms.TabPage goalsPage;
        private System.Windows.Forms.TabPage penaltiesPage;
        private System.Windows.Forms.TabPage shotPage;
        private System.Windows.Forms.Button periodButton;
        private System.Windows.Forms.Button gameButton;
        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.Button pauseButton;
        private System.Windows.Forms.GroupBox simGroupbox;
        private System.Windows.Forms.RadioButton eightRadioButton;
        private System.Windows.Forms.RadioButton fourRadioButton;
        private System.Windows.Forms.RadioButton twoRadioButton;
        private System.Windows.Forms.RadioButton oneRadioButton;
    }
}
