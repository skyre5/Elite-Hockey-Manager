namespace Elite_Hockey_Manager.Classes.Game.GameControls
{
    partial class AwayLineControl
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
            this.linePanel = new System.Windows.Forms.TableLayoutPanel();
            this.GoaliesLabel = new System.Windows.Forms.Label();
            this.forwardsLabel = new System.Windows.Forms.Label();
            this.DefendersLabel = new System.Windows.Forms.Label();
            this.forwardDisplayLabel = new System.Windows.Forms.Label();
            this.defenderDisplayLabel = new System.Windows.Forms.Label();
            this.goalieDisplayLabel = new System.Windows.Forms.Label();
            this.linePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // linePanel
            // 
            this.linePanel.ColumnCount = 1;
            this.linePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.linePanel.Controls.Add(this.GoaliesLabel, 0, 0);
            this.linePanel.Controls.Add(this.DefendersLabel, 0, 1);
            this.linePanel.Controls.Add(this.forwardsLabel, 0, 2);
            this.linePanel.Location = new System.Drawing.Point(40, 3);
            this.linePanel.Name = "linePanel";
            this.linePanel.RowCount = 3;
            this.linePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33533F));
            this.linePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33233F));
            this.linePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33233F));
            this.linePanel.Size = new System.Drawing.Size(200, 134);
            this.linePanel.TabIndex = 0;
            // 
            // GoaliesLabel
            // 
            this.GoaliesLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.GoaliesLabel.AutoSize = true;
            this.GoaliesLabel.Location = new System.Drawing.Point(92, 15);
            this.GoaliesLabel.Name = "GoaliesLabel";
            this.GoaliesLabel.Size = new System.Drawing.Size(15, 13);
            this.GoaliesLabel.TabIndex = 3;
            this.GoaliesLabel.Text = "G";
            this.GoaliesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // forwardsLabel
            // 
            this.forwardsLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.forwardsLabel.AutoSize = true;
            this.forwardsLabel.Location = new System.Drawing.Point(84, 104);
            this.forwardsLabel.Name = "forwardsLabel";
            this.forwardsLabel.Size = new System.Drawing.Size(32, 13);
            this.forwardsLabel.TabIndex = 1;
            this.forwardsLabel.Text = "FWD";
            this.forwardsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DefendersLabel
            // 
            this.DefendersLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DefendersLabel.AutoSize = true;
            this.DefendersLabel.Location = new System.Drawing.Point(86, 59);
            this.DefendersLabel.Name = "DefendersLabel";
            this.DefendersLabel.Size = new System.Drawing.Size(28, 13);
            this.DefendersLabel.TabIndex = 2;
            this.DefendersLabel.Text = "DEF";
            this.DefendersLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // forwardDisplayLabel
            // 
            this.forwardDisplayLabel.AutoSize = true;
            this.forwardDisplayLabel.Location = new System.Drawing.Point(4, 107);
            this.forwardDisplayLabel.Name = "forwardDisplayLabel";
            this.forwardDisplayLabel.Size = new System.Drawing.Size(35, 13);
            this.forwardDisplayLabel.TabIndex = 1;
            this.forwardDisplayLabel.Text = "FWD:";
            // 
            // defenderDisplayLabel
            // 
            this.defenderDisplayLabel.AutoSize = true;
            this.defenderDisplayLabel.Location = new System.Drawing.Point(3, 62);
            this.defenderDisplayLabel.Name = "defenderDisplayLabel";
            this.defenderDisplayLabel.Size = new System.Drawing.Size(31, 13);
            this.defenderDisplayLabel.TabIndex = 2;
            this.defenderDisplayLabel.Text = "DEF:";
            // 
            // goalieDisplayLabel
            // 
            this.goalieDisplayLabel.AutoSize = true;
            this.goalieDisplayLabel.Location = new System.Drawing.Point(4, 18);
            this.goalieDisplayLabel.Name = "goalieDisplayLabel";
            this.goalieDisplayLabel.Size = new System.Drawing.Size(18, 13);
            this.goalieDisplayLabel.TabIndex = 3;
            this.goalieDisplayLabel.Text = "G:";
            // 
            // AwayLineControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.goalieDisplayLabel);
            this.Controls.Add(this.defenderDisplayLabel);
            this.Controls.Add(this.forwardDisplayLabel);
            this.Controls.Add(this.linePanel);
            this.Name = "AwayLineControl";
            this.Size = new System.Drawing.Size(242, 139);
            this.linePanel.ResumeLayout(false);
            this.linePanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel linePanel;
        private System.Windows.Forms.Label forwardsLabel;
        private System.Windows.Forms.Label DefendersLabel;
        private System.Windows.Forms.Label GoaliesLabel;
        private System.Windows.Forms.Label forwardDisplayLabel;
        private System.Windows.Forms.Label defenderDisplayLabel;
        private System.Windows.Forms.Label goalieDisplayLabel;
    }
}
