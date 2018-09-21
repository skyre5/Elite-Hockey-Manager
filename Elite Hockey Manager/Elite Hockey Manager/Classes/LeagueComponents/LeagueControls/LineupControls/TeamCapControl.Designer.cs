namespace Elite_Hockey_Manager.Classes.LeagueComponents.LeagueControls.LineupControls
{
    partial class TeamCapControl
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
            this.salaryCapPlaceholderLabel = new System.Windows.Forms.Label();
            this.capProgressBar = new System.Windows.Forms.ProgressBar();
            this.salaryCapDisplayLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // salaryCapPlaceholderLabel
            // 
            this.salaryCapPlaceholderLabel.AutoSize = true;
            this.salaryCapPlaceholderLabel.Location = new System.Drawing.Point(4, 4);
            this.salaryCapPlaceholderLabel.Name = "salaryCapPlaceholderLabel";
            this.salaryCapPlaceholderLabel.Size = new System.Drawing.Size(61, 13);
            this.salaryCapPlaceholderLabel.TabIndex = 0;
            this.salaryCapPlaceholderLabel.Text = "Salary Cap:";
            // 
            // capProgressBar
            // 
            this.capProgressBar.Location = new System.Drawing.Point(7, 41);
            this.capProgressBar.Name = "capProgressBar";
            this.capProgressBar.Size = new System.Drawing.Size(156, 23);
            this.capProgressBar.TabIndex = 1;
            // 
            // salaryCapDisplayLabel
            // 
            this.salaryCapDisplayLabel.AutoSize = true;
            this.salaryCapDisplayLabel.Location = new System.Drawing.Point(4, 25);
            this.salaryCapDisplayLabel.Name = "salaryCapDisplayLabel";
            this.salaryCapDisplayLabel.Size = new System.Drawing.Size(115, 13);
            this.salaryCapDisplayLabel.TabIndex = 2;
            this.salaryCapDisplayLabel.Text = "salarySpent/SalaryCap";
            // 
            // TeamCapControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.salaryCapDisplayLabel);
            this.Controls.Add(this.capProgressBar);
            this.Controls.Add(this.salaryCapPlaceholderLabel);
            this.Name = "TeamCapControl";
            this.Size = new System.Drawing.Size(184, 82);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label salaryCapPlaceholderLabel;
        private System.Windows.Forms.ProgressBar capProgressBar;
        private System.Windows.Forms.Label salaryCapDisplayLabel;
    }
}
