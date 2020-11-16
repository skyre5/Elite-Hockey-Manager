namespace Elite_Hockey_Manager.Forms.GameForms.OffseasonForms
{
    partial class ResignForm
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
            this.totalSpentLabel = new System.Windows.Forms.Label();
            this.playersLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.resignedPlayersLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // totalSpentLabel
            // 
            this.totalSpentLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.totalSpentLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalSpentLabel.Location = new System.Drawing.Point(340, 9);
            this.totalSpentLabel.Name = "totalSpentLabel";
            this.totalSpentLabel.Size = new System.Drawing.Size(278, 37);
            this.totalSpentLabel.TabIndex = 0;
            this.totalSpentLabel.Text = "Cash Spent $";
            this.totalSpentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // playersLayoutPanel
            // 
            this.playersLayoutPanel.AutoScroll = true;
            this.playersLayoutPanel.AutoSize = true;
            this.playersLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.playersLayoutPanel.Location = new System.Drawing.Point(12, 32);
            this.playersLayoutPanel.Name = "playersLayoutPanel";
            this.playersLayoutPanel.Size = new System.Drawing.Size(322, 400);
            this.playersLayoutPanel.TabIndex = 1;
            // 
            // resignedPlayersLabel
            // 
            this.resignedPlayersLabel.AutoSize = true;
            this.resignedPlayersLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resignedPlayersLabel.Location = new System.Drawing.Point(12, 9);
            this.resignedPlayersLabel.Name = "resignedPlayersLabel";
            this.resignedPlayersLabel.Size = new System.Drawing.Size(150, 20);
            this.resignedPlayersLabel.TabIndex = 2;
            this.resignedPlayersLabel.Text = "Resigned Contracts";
            // 
            // ResignForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 462);
            this.Controls.Add(this.resignedPlayersLabel);
            this.Controls.Add(this.playersLayoutPanel);
            this.Controls.Add(this.totalSpentLabel);
            this.Name = "ResignForm";
            this.Text = "Team Resigns";
            this.Load += new System.EventHandler(this.ResignForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label totalSpentLabel;
        private System.Windows.Forms.FlowLayoutPanel playersLayoutPanel;
        private System.Windows.Forms.Label resignedPlayersLabel;
    }
}