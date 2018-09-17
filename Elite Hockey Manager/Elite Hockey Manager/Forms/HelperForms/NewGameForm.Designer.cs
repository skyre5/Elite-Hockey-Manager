namespace Elite_Hockey_Manager.Forms.HelperForms
{
    partial class NewGameForm
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
            this.newLeagueButton = new System.Windows.Forms.Button();
            this.leaguesLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // newLeagueButton
            // 
            this.newLeagueButton.Location = new System.Drawing.Point(13, 13);
            this.newLeagueButton.Name = "newLeagueButton";
            this.newLeagueButton.Size = new System.Drawing.Size(180, 63);
            this.newLeagueButton.TabIndex = 0;
            this.newLeagueButton.Text = "Create New League";
            this.newLeagueButton.UseVisualStyleBackColor = true;
            this.newLeagueButton.Click += new System.EventHandler(this.newLeagueButton_Click);
            // 
            // leaguesLayoutPanel
            // 
            this.leaguesLayoutPanel.AutoScroll = true;
            this.leaguesLayoutPanel.Location = new System.Drawing.Point(13, 119);
            this.leaguesLayoutPanel.Name = "leaguesLayoutPanel";
            this.leaguesLayoutPanel.Size = new System.Drawing.Size(553, 220);
            this.leaguesLayoutPanel.TabIndex = 2;
            // 
            // NewGameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 351);
            this.Controls.Add(this.leaguesLayoutPanel);
            this.Controls.Add(this.newLeagueButton);
            this.Name = "NewGameForm";
            this.Text = "Create New Game";
            this.Load += new System.EventHandler(this.NewGameForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button newLeagueButton;
        private System.Windows.Forms.FlowLayoutPanel leaguesLayoutPanel;
    }
}