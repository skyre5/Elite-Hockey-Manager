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
            this.button1 = new System.Windows.Forms.Button();
            this.statsControl1 = new Elite_Hockey_Manager.Classes.LeagueComponents.LeagueControls.PlayerStuff.StatsControls.StatsControl();
            this.teamCapControl = new Elite_Hockey_Manager.Classes.LeagueComponents.LeagueControls.LineupControls.TeamCapControl();
            this.teamLinesControl = new Elite_Hockey_Manager.Classes.LeagueComponents.LeagueControls.TeamLinesControl();
            this.SuspendLayout();
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
            // statsControl1
            // 
            this.statsControl1.DisplayType = Elite_Hockey_Manager.Classes.LeagueComponents.LeagueControls.StatsDisplayType.Skater;
            this.statsControl1.Location = new System.Drawing.Point(470, 337);
            this.statsControl1.Name = "statsControl1";
            this.statsControl1.Size = new System.Drawing.Size(749, 280);
            this.statsControl1.TabIndex = 4;
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
            // ViewTeamForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1231, 643);
            this.Controls.Add(this.statsControl1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.teamCapControl);
            this.Controls.Add(this.teamLinesControl);
            this.Name = "ViewTeamForm";
            this.Text = "ViewTeamForm";
            this.Load += new System.EventHandler(this.ViewTeamForm_Load);
            this.ResumeLayout(false);

        }

        #endregion


        private Classes.LeagueComponents.LeagueControls.TeamLinesControl teamLinesControl;
        private Classes.LeagueComponents.LeagueControls.LineupControls.TeamCapControl teamCapControl;
        private System.Windows.Forms.Button button1;
        private Classes.LeagueComponents.LeagueControls.PlayerStuff.StatsControls.StatsControl statsControl1;
    }
}