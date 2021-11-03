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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.periodLabel = new System.Windows.Forms.Label();
            this.timeLabel = new System.Windows.Forms.Label();
            this.scoreLabel = new System.Windows.Forms.Label();
            this.homeTeamLabel = new System.Windows.Forms.Label();
            this.awayTeamLabel = new System.Windows.Forms.Label();
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
            this.faceoffChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.shotCounterControl = new Elite_Hockey_Manager.Classes.GameComponents.GameControls.ShotCounterControl();
            this.awayLineControl = new Elite_Hockey_Manager.Classes.GameComponents.GameControls.AwayLineControl();
            this.homeLineControl = new Elite_Hockey_Manager.Classes.GameComponents.GameControls.HomeLineControl();
            this.eventsTabControl.SuspendLayout();
            this.simGroupbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.faceoffChart)).BeginInit();
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
            this.scoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreLabel.Location = new System.Drawing.Point(91, 15);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(205, 33);
            this.scoreLabel.TabIndex = 2;
            this.scoreLabel.Text = "ABR 1 - 0 AAA";
            // 
            // homeTeamLabel
            // 
            this.homeTeamLabel.AutoSize = true;
            this.homeTeamLabel.Location = new System.Drawing.Point(20, 273);
            this.homeTeamLabel.Name = "homeTeamLabel";
            this.homeTeamLabel.Size = new System.Drawing.Size(35, 13);
            this.homeTeamLabel.TabIndex = 5;
            this.homeTeamLabel.Text = "Home";
            // 
            // awayTeamLabel
            // 
            this.awayTeamLabel.AutoSize = true;
            this.awayTeamLabel.Location = new System.Drawing.Point(20, 107);
            this.awayTeamLabel.Name = "awayTeamLabel";
            this.awayTeamLabel.Size = new System.Drawing.Size(33, 13);
            this.awayTeamLabel.TabIndex = 6;
            this.awayTeamLabel.Text = "Away";
            // 
            // eventsTabControl
            // 
            this.eventsTabControl.Controls.Add(this.allEventsPage);
            this.eventsTabControl.Controls.Add(this.goalsPage);
            this.eventsTabControl.Controls.Add(this.penaltiesPage);
            this.eventsTabControl.Controls.Add(this.shotPage);
            this.eventsTabControl.Location = new System.Drawing.Point(436, 107);
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
            this.periodButton.Click += new System.EventHandler(this.periodButton_Click);
            // 
            // gameButton
            // 
            this.gameButton.Location = new System.Drawing.Point(189, 48);
            this.gameButton.Name = "gameButton";
            this.gameButton.Size = new System.Drawing.Size(75, 23);
            this.gameButton.TabIndex = 15;
            this.gameButton.Text = "Sim Game";
            this.gameButton.UseVisualStyleBackColor = true;
            this.gameButton.Click += new System.EventHandler(this.gameButton_Click);
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
            // faceoffChart
            // 
            chartArea1.Name = "ChartArea1";
            this.faceoffChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.faceoffChart.Legends.Add(legend1);
            this.faceoffChart.Location = new System.Drawing.Point(292, 359);
            this.faceoffChart.Name = "faceoffChart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.IsValueShownAsLabel = true;
            series1.IsXValueIndexed = true;
            series1.Legend = "Legend1";
            series1.Name = "Faceoffs";
            this.faceoffChart.Series.Add(series1);
            this.faceoffChart.Size = new System.Drawing.Size(142, 104);
            this.faceoffChart.TabIndex = 20;
            this.faceoffChart.Text = "Faceoffs";
            title1.Name = "Faceoffs";
            title1.Text = "Faceoffs";
            this.faceoffChart.Titles.Add(title1);
            this.faceoffChart.Click += new System.EventHandler(this.chart1_Click);
            // 
            // shotCounterControl
            // 
            this.shotCounterControl.Location = new System.Drawing.Point(3, 359);
            this.shotCounterControl.Name = "shotCounterControl";
            this.shotCounterControl.Size = new System.Drawing.Size(283, 104);
            this.shotCounterControl.TabIndex = 8;
            // 
            // awayLineControl
            // 
            this.awayLineControl.Location = new System.Drawing.Point(106, 69);
            this.awayLineControl.Name = "awayLineControl";
            this.awayLineControl.Size = new System.Drawing.Size(242, 139);
            this.awayLineControl.TabIndex = 4;
            // 
            // homeLineControl
            // 
            this.homeLineControl.Location = new System.Drawing.Point(106, 214);
            this.homeLineControl.Name = "homeLineControl";
            this.homeLineControl.Size = new System.Drawing.Size(242, 139);
            this.homeLineControl.TabIndex = 3;
            // 
            // GameControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.faceoffChart);
            this.Controls.Add(this.simGroupbox);
            this.Controls.Add(this.eventsTabControl);
            this.Controls.Add(this.shotCounterControl);
            this.Controls.Add(this.awayTeamLabel);
            this.Controls.Add(this.homeTeamLabel);
            this.Controls.Add(this.awayLineControl);
            this.Controls.Add(this.homeLineControl);
            this.Controls.Add(this.scoreLabel);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.periodLabel);
            this.Name = "GameControl";
            this.Size = new System.Drawing.Size(827, 524);
            this.eventsTabControl.ResumeLayout(false);
            this.simGroupbox.ResumeLayout(false);
            this.simGroupbox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.faceoffChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label periodLabel;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.Label scoreLabel;
        private HomeLineControl homeLineControl;
        private AwayLineControl awayLineControl;
        private System.Windows.Forms.Label homeTeamLabel;
        private System.Windows.Forms.Label awayTeamLabel;
        private ShotCounterControl shotCounterControl;
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
        private System.Windows.Forms.DataVisualization.Charting.Chart faceoffChart;
    }
}
