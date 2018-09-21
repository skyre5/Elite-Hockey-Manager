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
            this.teamLinesControl = new Elite_Hockey_Manager.Classes.LeagueComponents.LeagueControls.TeamLinesControl();
            this.SuspendLayout();
            // 
            // teamLinesControl
            // 
            this.teamLinesControl.Location = new System.Drawing.Point(12, 12);
            this.teamLinesControl.Name = "teamLinesControl";
            this.teamLinesControl.Size = new System.Drawing.Size(677, 500);
            this.teamLinesControl.TabIndex = 0;
            // 
            // ViewTeamForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1059, 512);
            this.Controls.Add(this.teamLinesControl);
            this.Name = "ViewTeamForm";
            this.Text = "ViewTeamForm";
            this.Load += new System.EventHandler(this.ViewTeamForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Classes.LeagueComponents.LeagueControls.TeamLinesControl teamLinesControl;
    }
}