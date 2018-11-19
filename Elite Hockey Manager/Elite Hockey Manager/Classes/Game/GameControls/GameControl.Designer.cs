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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.shotCounterControl1 = new Elite_Hockey_Manager.Classes.Game.GameControls.ShotCounterControl();
            this.tabControl1.SuspendLayout();
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
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(619, 69);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(202, 387);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(194, 361);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Home";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(194, 361);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Away";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // shotCounterControl1
            // 
            this.shotCounterControl1.Location = new System.Drawing.Point(23, 370);
            this.shotCounterControl1.Name = "shotCounterControl1";
            this.shotCounterControl1.Size = new System.Drawing.Size(283, 104);
            this.shotCounterControl1.TabIndex = 8;
            // 
            // GameControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.shotCounterControl1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.awayTeamLabel);
            this.Controls.Add(this.homeTeamLabel);
            this.Controls.Add(this.awayLineControl1);
            this.Controls.Add(this.homeLineControl1);
            this.Controls.Add(this.scoreLabel);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.periodLabel);
            this.Name = "GameControl";
            this.Size = new System.Drawing.Size(847, 486);
            this.tabControl1.ResumeLayout(false);
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
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private ShotCounterControl shotCounterControl1;
    }
}
