namespace Elite_Hockey_Manager.Forms.GameForms.OffseasonForms
{
    partial class DraftForm
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
            this.draftDisplayLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.pickLabel = new System.Windows.Forms.Label();
            this.roundLabel = new System.Windows.Forms.Label();
            this.upcomingTeamLabel = new System.Windows.Forms.Label();
            this.simPickButton = new System.Windows.Forms.Button();
            this.simRoundButton = new System.Windows.Forms.Button();
            this.simDraftButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // draftDisplayLayoutPanel
            // 
            this.draftDisplayLayoutPanel.AutoScroll = true;
            this.draftDisplayLayoutPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.draftDisplayLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.draftDisplayLayoutPanel.Location = new System.Drawing.Point(12, 12);
            this.draftDisplayLayoutPanel.Name = "draftDisplayLayoutPanel";
            this.draftDisplayLayoutPanel.Size = new System.Drawing.Size(434, 349);
            this.draftDisplayLayoutPanel.TabIndex = 0;
            this.draftDisplayLayoutPanel.WrapContents = false;
            // 
            // pickLabel
            // 
            this.pickLabel.AutoSize = true;
            this.pickLabel.Location = new System.Drawing.Point(144, 364);
            this.pickLabel.Name = "pickLabel";
            this.pickLabel.Size = new System.Drawing.Size(34, 13);
            this.pickLabel.TabIndex = 1;
            this.pickLabel.Text = "Pick: ";
            // 
            // roundLabel
            // 
            this.roundLabel.AutoSize = true;
            this.roundLabel.Location = new System.Drawing.Point(12, 364);
            this.roundLabel.Name = "roundLabel";
            this.roundLabel.Size = new System.Drawing.Size(42, 13);
            this.roundLabel.TabIndex = 2;
            this.roundLabel.Text = "Round:";
            // 
            // upcomingTeamLabel
            // 
            this.upcomingTeamLabel.AutoSize = true;
            this.upcomingTeamLabel.Location = new System.Drawing.Point(174, 393);
            this.upcomingTeamLabel.Name = "upcomingTeamLabel";
            this.upcomingTeamLabel.Size = new System.Drawing.Size(84, 13);
            this.upcomingTeamLabel.TabIndex = 3;
            this.upcomingTeamLabel.Text = "Selecting Team:";
            this.upcomingTeamLabel.DoubleClick += new System.EventHandler(this.upcomingTeamLabel_DoubleClick);
            // 
            // simPickButton
            // 
            this.simPickButton.Location = new System.Drawing.Point(15, 420);
            this.simPickButton.Name = "simPickButton";
            this.simPickButton.Size = new System.Drawing.Size(75, 23);
            this.simPickButton.TabIndex = 4;
            this.simPickButton.Text = "Sim Pick";
            this.simPickButton.UseVisualStyleBackColor = true;
            this.simPickButton.Click += new System.EventHandler(this.simPickButton_Click);
            // 
            // simRoundButton
            // 
            this.simRoundButton.Location = new System.Drawing.Point(15, 449);
            this.simRoundButton.Name = "simRoundButton";
            this.simRoundButton.Size = new System.Drawing.Size(75, 23);
            this.simRoundButton.TabIndex = 5;
            this.simRoundButton.Text = "Sim Round";
            this.simRoundButton.UseVisualStyleBackColor = true;
            this.simRoundButton.Click += new System.EventHandler(this.simRoundButton_Click);
            // 
            // simDraftButton
            // 
            this.simDraftButton.Location = new System.Drawing.Point(15, 479);
            this.simDraftButton.Name = "simDraftButton";
            this.simDraftButton.Size = new System.Drawing.Size(75, 23);
            this.simDraftButton.TabIndex = 6;
            this.simDraftButton.Text = "Sim Draft";
            this.simDraftButton.UseVisualStyleBackColor = true;
            this.simDraftButton.Click += new System.EventHandler(this.simDraftButton_Click);
            // 
            // DraftForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 527);
            this.Controls.Add(this.simDraftButton);
            this.Controls.Add(this.simRoundButton);
            this.Controls.Add(this.simPickButton);
            this.Controls.Add(this.upcomingTeamLabel);
            this.Controls.Add(this.roundLabel);
            this.Controls.Add(this.pickLabel);
            this.Controls.Add(this.draftDisplayLayoutPanel);
            this.Name = "DraftForm";
            this.Text = "DraftForm";
            this.Load += new System.EventHandler(this.DraftForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel draftDisplayLayoutPanel;
        private System.Windows.Forms.Label pickLabel;
        private System.Windows.Forms.Label roundLabel;
        private System.Windows.Forms.Label upcomingTeamLabel;
        private System.Windows.Forms.Button simPickButton;
        private System.Windows.Forms.Button simRoundButton;
        private System.Windows.Forms.Button simDraftButton;
    }
}