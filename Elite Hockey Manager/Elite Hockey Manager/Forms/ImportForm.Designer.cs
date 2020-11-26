namespace Elite_Hockey_Manager.Forms
{
    partial class ImportForm
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
            this.firstConferenceLabel = new System.Windows.Forms.Label();
            this.secondConferenceLabel = new System.Windows.Forms.Label();
            this.statusLabel = new System.Windows.Forms.Label();
            this.startGameButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // firstConferenceLabel
            // 
            this.firstConferenceLabel.Location = new System.Drawing.Point(185, 9);
            this.firstConferenceLabel.Name = "firstConferenceLabel";
            this.firstConferenceLabel.Size = new System.Drawing.Size(162, 302);
            this.firstConferenceLabel.TabIndex = 0;
            this.firstConferenceLabel.Text = "label1";
            // 
            // secondConferenceLabel
            // 
            this.secondConferenceLabel.Location = new System.Drawing.Point(354, 9);
            this.secondConferenceLabel.Name = "secondConferenceLabel";
            this.secondConferenceLabel.Size = new System.Drawing.Size(131, 302);
            this.secondConferenceLabel.TabIndex = 1;
            this.secondConferenceLabel.Text = "label1";
            // 
            // statusLabel
            // 
            this.statusLabel.Location = new System.Drawing.Point(12, 9);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(137, 38);
            this.statusLabel.TabIndex = 2;
            this.statusLabel.Text = "Import Status:";
            // 
            // startGameButton
            // 
            this.startGameButton.Location = new System.Drawing.Point(163, 403);
            this.startGameButton.Name = "startGameButton";
            this.startGameButton.Size = new System.Drawing.Size(134, 23);
            this.startGameButton.TabIndex = 3;
            this.startGameButton.Text = "Create League";
            this.startGameButton.UseVisualStyleBackColor = true;
            this.startGameButton.Click += new System.EventHandler(this.StartGameButton_Click);
            // 
            // ImportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 450);
            this.Controls.Add(this.startGameButton);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.secondConferenceLabel);
            this.Controls.Add(this.firstConferenceLabel);
            this.Name = "ImportForm";
            this.Text = "ImportForm";
            this.Load += new System.EventHandler(this.ImportForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label firstConferenceLabel;
        private System.Windows.Forms.Label secondConferenceLabel;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Button startGameButton;
    }
}