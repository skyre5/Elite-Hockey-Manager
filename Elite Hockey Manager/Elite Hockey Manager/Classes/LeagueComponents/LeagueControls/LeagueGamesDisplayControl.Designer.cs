namespace Elite_Hockey_Manager.Classes.LeagueComponents.LeagueControls
{
    partial class LeagueGamesDisplayControl
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
            this.gameLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.dayLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // gameLayoutPanel
            // 
            this.gameLayoutPanel.AutoScroll = true;
            this.gameLayoutPanel.Location = new System.Drawing.Point(3, 18);
            this.gameLayoutPanel.Name = "gameLayoutPanel";
            this.gameLayoutPanel.Size = new System.Drawing.Size(1073, 140);
            this.gameLayoutPanel.TabIndex = 0;
            this.gameLayoutPanel.WrapContents = false;
            // 
            // dayLabel
            // 
            this.dayLabel.AutoSize = true;
            this.dayLabel.Location = new System.Drawing.Point(4, 4);
            this.dayLabel.Name = "dayLabel";
            this.dayLabel.Size = new System.Drawing.Size(29, 13);
            this.dayLabel.TabIndex = 1;
            this.dayLabel.Text = "Day:";
            // 
            // LeagueGamesDisplayControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dayLabel);
            this.Controls.Add(this.gameLayoutPanel);
            this.Name = "LeagueGamesDisplayControl";
            this.Size = new System.Drawing.Size(1079, 161);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel gameLayoutPanel;
        private System.Windows.Forms.Label dayLabel;
    }
}
