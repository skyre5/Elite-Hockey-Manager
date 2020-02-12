namespace Elite_Hockey_Manager.Classes.LeagueComponents
{
    partial class TeamLogoStandingViewControl
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
            this.logoPictureBox = new System.Windows.Forms.PictureBox();
            this.teamLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // logoPictureBox
            // 
            this.logoPictureBox.Location = new System.Drawing.Point(4, 5);
            this.logoPictureBox.Name = "logoPictureBox";
            this.logoPictureBox.Size = new System.Drawing.Size(20, 20);
            this.logoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.logoPictureBox.TabIndex = 0;
            this.logoPictureBox.TabStop = false;
            this.logoPictureBox.DoubleClick += new System.EventHandler(this.TeamLogoStandingViewControl_DoubleClick);
            // 
            // teamLabel
            // 
            this.teamLabel.AutoSize = true;
            this.teamLabel.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.teamLabel.Location = new System.Drawing.Point(30, 7);
            this.teamLabel.Name = "teamLabel";
            this.teamLabel.Size = new System.Drawing.Size(74, 15);
            this.teamLabel.TabIndex = 1;
            this.teamLabel.Text = "TeamStanding";
            this.teamLabel.DoubleClick += new System.EventHandler(this.TeamLogoStandingViewControl_DoubleClick);
            // 
            // TeamLogoStandingViewControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.teamLabel);
            this.Controls.Add(this.logoPictureBox);
            this.Name = "TeamLogoStandingViewControl";
            this.Size = new System.Drawing.Size(225, 29);
            this.Load += new System.EventHandler(this.TeamLogoStandingViewControl_Load);
            this.DoubleClick += new System.EventHandler(this.TeamLogoStandingViewControl_DoubleClick);
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox logoPictureBox;
        protected System.Windows.Forms.Label teamLabel;
    }
}
