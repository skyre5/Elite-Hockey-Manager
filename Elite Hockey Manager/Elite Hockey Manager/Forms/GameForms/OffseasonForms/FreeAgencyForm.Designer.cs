namespace Elite_Hockey_Manager.Forms.GameForms.OffseasonForms
{
    partial class FreeAgencyForm
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
            this.playersLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.freeAgencyPlayersLabel = new System.Windows.Forms.Label();
            this.totalSpentLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // playersLayoutPanel
            // 
            this.playersLayoutPanel.AutoScroll = true;
            this.playersLayoutPanel.AutoSize = true;
            this.playersLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.playersLayoutPanel.Location = new System.Drawing.Point(12, 56);
            this.playersLayoutPanel.Name = "playersLayoutPanel";
            this.playersLayoutPanel.Size = new System.Drawing.Size(322, 400);
            this.playersLayoutPanel.TabIndex = 2;
            // 
            // freeAgencyPlayersLabel
            // 
            this.freeAgencyPlayersLabel.AutoSize = true;
            this.freeAgencyPlayersLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.freeAgencyPlayersLabel.Location = new System.Drawing.Point(12, 33);
            this.freeAgencyPlayersLabel.Name = "freeAgencyPlayersLabel";
            this.freeAgencyPlayersLabel.Size = new System.Drawing.Size(164, 20);
            this.freeAgencyPlayersLabel.TabIndex = 3;
            this.freeAgencyPlayersLabel.Text = "Free Agency Signings";
            // 
            // totalSpentLabel
            // 
            this.totalSpentLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.totalSpentLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalSpentLabel.Location = new System.Drawing.Point(379, 16);
            this.totalSpentLabel.Name = "totalSpentLabel";
            this.totalSpentLabel.Size = new System.Drawing.Size(278, 37);
            this.totalSpentLabel.TabIndex = 4;
            this.totalSpentLabel.Text = "Cash Spent $";
            this.totalSpentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FreeAgencyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(689, 526);
            this.Controls.Add(this.totalSpentLabel);
            this.Controls.Add(this.freeAgencyPlayersLabel);
            this.Controls.Add(this.playersLayoutPanel);
            this.Name = "FreeAgencyForm";
            this.Text = "Free Agency Signings";
            this.Load += new System.EventHandler(this.FreeAgencyForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel playersLayoutPanel;
        private System.Windows.Forms.Label freeAgencyPlayersLabel;
        private System.Windows.Forms.Label totalSpentLabel;
    }
}