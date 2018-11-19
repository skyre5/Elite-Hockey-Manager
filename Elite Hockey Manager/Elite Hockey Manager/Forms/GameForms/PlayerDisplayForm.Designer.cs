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
            this.nameLabel = new System.Windows.Forms.Label();
            this.ageLabel = new System.Windows.Forms.Label();
            this.statusLabel = new System.Windows.Forms.Label();
            this.playerAttributesPanel = new Elite_Hockey_Manager.Classes.LeagueComponents.LeagueControls.PlayerStuff.PlayerAttributesTableLayoutPanel();
            this.contractLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(23, 13);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(38, 13);
            this.nameLabel.TabIndex = 1;
            this.nameLabel.Text = "Name:";
            // 
            // ageLabel
            // 
            this.ageLabel.AutoSize = true;
            this.ageLabel.Location = new System.Drawing.Point(23, 31);
            this.ageLabel.Name = "ageLabel";
            this.ageLabel.Size = new System.Drawing.Size(29, 13);
            this.ageLabel.TabIndex = 2;
            this.ageLabel.Text = "Age:";
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(23, 49);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(40, 13);
            this.statusLabel.TabIndex = 3;
            this.statusLabel.Text = "Status:";
            // 
            // playerAttributesPanel
            // 
            this.playerAttributesPanel.AutoSize = true;
            this.playerAttributesPanel.ColumnCount = 2;
            this.playerAttributesPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.playerAttributesPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.playerAttributesPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.playerAttributesPanel.Font = new System.Drawing.Font("Courier New", 7F);
            this.playerAttributesPanel.Location = new System.Drawing.Point(23, 104);
            this.playerAttributesPanel.Name = "playerAttributesPanel";
            this.playerAttributesPanel.Player = null;
            this.playerAttributesPanel.RowCount = 1;
            this.playerAttributesPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.playerAttributesPanel.Size = new System.Drawing.Size(369, 15);
            this.playerAttributesPanel.TabIndex = 0;
            // 
            // contractLabel
            // 
            this.contractLabel.AutoSize = true;
            this.contractLabel.Location = new System.Drawing.Point(23, 67);
            this.contractLabel.Name = "contractLabel";
            this.contractLabel.Size = new System.Drawing.Size(50, 13);
            this.contractLabel.TabIndex = 4;
            this.contractLabel.Text = "Contract:";
            // 
            // PlayerDisplayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 373);
            this.Controls.Add(this.contractLabel);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.ageLabel);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.playerAttributesPanel);
            this.Name = "PlayerDisplayForm";
            this.Text = "PlayerDisplayForm";
            this.Load += new System.EventHandler(this.PlayerDisplayForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Classes.LeagueComponents.LeagueControls.PlayerStuff.PlayerAttributesTableLayoutPanel playerAttributesPanel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label ageLabel;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Label contractLabel;
    }
}