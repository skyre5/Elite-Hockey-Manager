namespace Elite_Hockey_Manager.Classes.LeagueComponents
{
    partial class LeagueControl
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
            this.lblName = new System.Windows.Forms.Label();
            this.btnFillTeams = new System.Windows.Forms.Button();
            this.picTeamsCheck = new System.Windows.Forms.PictureBox();
            this.lblTeamsCount = new System.Windows.Forms.Label();
            this.lblTeamHeader = new System.Windows.Forms.Label();
            this.btnFillPlayers = new System.Windows.Forms.Button();
            this.picPlayersCheck = new System.Windows.Forms.PictureBox();
            this.lblPlayersHeader = new System.Windows.Forms.Label();
            this.lblPlayersCheck = new System.Windows.Forms.Label();
            this.btnDisplayPlayersErrors = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picTeamsCheck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayersCheck)).BeginInit();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(3, 9);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(74, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "League Name";
            // 
            // btnFillTeams
            // 
            this.btnFillTeams.Location = new System.Drawing.Point(132, 60);
            this.btnFillTeams.Name = "btnFillTeams";
            this.btnFillTeams.Size = new System.Drawing.Size(126, 23);
            this.btnFillTeams.TabIndex = 1;
            this.btnFillTeams.Text = "Fill Remaining Teams";
            this.btnFillTeams.UseVisualStyleBackColor = true;
            // 
            // picTeamsCheck
            // 
            this.picTeamsCheck.Image = global::Elite_Hockey_Manager.Properties.Resources.xmark;
            this.picTeamsCheck.Location = new System.Drawing.Point(208, 3);
            this.picTeamsCheck.Name = "picTeamsCheck";
            this.picTeamsCheck.Size = new System.Drawing.Size(50, 50);
            this.picTeamsCheck.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picTeamsCheck.TabIndex = 2;
            this.picTeamsCheck.TabStop = false;
            // 
            // lblTeamsCount
            // 
            this.lblTeamsCount.AutoSize = true;
            this.lblTeamsCount.Location = new System.Drawing.Point(129, 44);
            this.lblTeamsCount.Name = "lblTeamsCount";
            this.lblTeamsCount.Size = new System.Drawing.Size(65, 13);
            this.lblTeamsCount.TabIndex = 3;
            this.lblTeamsCount.Text = "Team Count";
            // 
            // lblTeamHeader
            // 
            this.lblTeamHeader.AutoSize = true;
            this.lblTeamHeader.Location = new System.Drawing.Point(129, 28);
            this.lblTeamHeader.Name = "lblTeamHeader";
            this.lblTeamHeader.Size = new System.Drawing.Size(42, 13);
            this.lblTeamHeader.TabIndex = 4;
            this.lblTeamHeader.Text = "Teams:";
            // 
            // btnFillPlayers
            // 
            this.btnFillPlayers.Enabled = false;
            this.btnFillPlayers.Location = new System.Drawing.Point(345, 60);
            this.btnFillPlayers.Name = "btnFillPlayers";
            this.btnFillPlayers.Size = new System.Drawing.Size(236, 23);
            this.btnFillPlayers.TabIndex = 5;
            this.btnFillPlayers.Text = "Fill Remaining Players";
            this.btnFillPlayers.UseVisualStyleBackColor = true;
            // 
            // picPlayersCheck
            // 
            this.picPlayersCheck.Location = new System.Drawing.Point(531, 3);
            this.picPlayersCheck.Name = "picPlayersCheck";
            this.picPlayersCheck.Size = new System.Drawing.Size(50, 50);
            this.picPlayersCheck.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picPlayersCheck.TabIndex = 6;
            this.picPlayersCheck.TabStop = false;
            // 
            // lblPlayersHeader
            // 
            this.lblPlayersHeader.AutoSize = true;
            this.lblPlayersHeader.Location = new System.Drawing.Point(343, 28);
            this.lblPlayersHeader.Name = "lblPlayersHeader";
            this.lblPlayersHeader.Size = new System.Drawing.Size(44, 13);
            this.lblPlayersHeader.TabIndex = 7;
            this.lblPlayersHeader.Text = "Players:";
            // 
            // lblPlayersCheck
            // 
            this.lblPlayersCheck.AutoSize = true;
            this.lblPlayersCheck.Location = new System.Drawing.Point(342, 44);
            this.lblPlayersCheck.Name = "lblPlayersCheck";
            this.lblPlayersCheck.Size = new System.Drawing.Size(131, 13);
            this.lblPlayersCheck.TabIndex = 8;
            this.lblPlayersCheck.Tag = "";
            this.lblPlayersCheck.Text = "Teams with invalid rosters:";
            // 
            // btnDisplayPlayersErrors
            // 
            this.btnDisplayPlayersErrors.Enabled = false;
            this.btnDisplayPlayersErrors.Location = new System.Drawing.Point(497, 37);
            this.btnDisplayPlayersErrors.Name = "btnDisplayPlayersErrors";
            this.btnDisplayPlayersErrors.Size = new System.Drawing.Size(28, 23);
            this.btnDisplayPlayersErrors.TabIndex = 9;
            this.btnDisplayPlayersErrors.Text = "v";
            this.btnDisplayPlayersErrors.UseVisualStyleBackColor = true;
            // 
            // LeagueControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnDisplayPlayersErrors);
            this.Controls.Add(this.lblPlayersCheck);
            this.Controls.Add(this.lblPlayersHeader);
            this.Controls.Add(this.picPlayersCheck);
            this.Controls.Add(this.btnFillPlayers);
            this.Controls.Add(this.lblTeamHeader);
            this.Controls.Add(this.lblTeamsCount);
            this.Controls.Add(this.picTeamsCheck);
            this.Controls.Add(this.btnFillTeams);
            this.Controls.Add(this.lblName);
            this.Name = "LeagueControl";
            this.Size = new System.Drawing.Size(596, 86);
            ((System.ComponentModel.ISupportInitialize)(this.picTeamsCheck)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayersCheck)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Button btnFillTeams;
        private System.Windows.Forms.PictureBox picTeamsCheck;
        private System.Windows.Forms.Label lblTeamsCount;
        private System.Windows.Forms.Label lblTeamHeader;
        private System.Windows.Forms.Button btnFillPlayers;
        private System.Windows.Forms.PictureBox picPlayersCheck;
        private System.Windows.Forms.Label lblPlayersHeader;
        private System.Windows.Forms.Label lblPlayersCheck;
        private System.Windows.Forms.Button btnDisplayPlayersErrors;
    }
}
