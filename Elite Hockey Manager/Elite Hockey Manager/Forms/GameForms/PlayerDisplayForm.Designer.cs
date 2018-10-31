using System;

namespace Elite_Hockey_Manager.Forms.GameForms
{
    partial class PlayerDisplayForm
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
            this.playerAttributesPanel = new Elite_Hockey_Manager.Classes.LeagueComponents.LeagueControls.PlayerStuff.PlayerAttributesTableLayoutPanel();
            this.SuspendLayout();
            // 
            // playerAttributesPanel
            // 
            this.playerAttributesPanel.AutoSize = true;
            this.playerAttributesPanel.ColumnCount = 2;
            this.playerAttributesPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.playerAttributesPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.playerAttributesPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.playerAttributesPanel.Font = new System.Drawing.Font("Courier New", 7F);
            this.playerAttributesPanel.Location = new System.Drawing.Point(12, 12);
            this.playerAttributesPanel.Name = "playerAttributesPanel";
            this.playerAttributesPanel.Player = null;
            this.playerAttributesPanel.RowCount = 1;
            this.playerAttributesPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.playerAttributesPanel.Size = new System.Drawing.Size(369, 15);
            this.playerAttributesPanel.TabIndex = 0;
            // 
            // PlayerDisplayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 373);
            this.Controls.Add(this.playerAttributesPanel);
            this.Name = "PlayerDisplayForm";
            this.Text = "PlayerDisplayForm";
            this.Load += new System.EventHandler(this.PlayerDisplayForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Classes.LeagueComponents.LeagueControls.PlayerStuff.PlayerAttributesTableLayoutPanel playerAttributesPanel;
    }
}