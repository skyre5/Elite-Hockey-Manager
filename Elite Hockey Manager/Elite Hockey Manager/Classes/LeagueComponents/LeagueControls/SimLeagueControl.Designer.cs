namespace Elite_Hockey_Manager.Classes.LeagueComponents.LeagueControls
{
    partial class SimLeagueControl
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
            this.simDisplayLabel = new System.Windows.Forms.Label();
            this.simOneButton = new System.Windows.Forms.Button();
            this.simThreeButton = new System.Windows.Forms.Button();
            this.simWeekButton = new System.Windows.Forms.Button();
            this.simMonthButton = new System.Windows.Forms.Button();
            this.simSeasonButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // simDisplayLabel
            // 
            this.simDisplayLabel.AutoSize = true;
            this.simDisplayLabel.Location = new System.Drawing.Point(4, 4);
            this.simDisplayLabel.Name = "simDisplayLabel";
            this.simDisplayLabel.Size = new System.Drawing.Size(66, 13);
            this.simDisplayLabel.TabIndex = 0;
            this.simDisplayLabel.Text = "Sim League:";
            // 
            // simOneButton
            // 
            this.simOneButton.Location = new System.Drawing.Point(4, 21);
            this.simOneButton.Name = "simOneButton";
            this.simOneButton.Size = new System.Drawing.Size(66, 23);
            this.simOneButton.TabIndex = 1;
            this.simOneButton.Text = "1 Day";
            this.simOneButton.UseVisualStyleBackColor = true;
            this.simOneButton.Click += new System.EventHandler(this.simOneButton_Click);
            // 
            // simThreeButton
            // 
            this.simThreeButton.Location = new System.Drawing.Point(76, 21);
            this.simThreeButton.Name = "simThreeButton";
            this.simThreeButton.Size = new System.Drawing.Size(66, 23);
            this.simThreeButton.TabIndex = 2;
            this.simThreeButton.Text = "3 Day";
            this.simThreeButton.UseVisualStyleBackColor = true;
            this.simThreeButton.Click += new System.EventHandler(this.simThreeButton_Click);
            // 
            // simWeekButton
            // 
            this.simWeekButton.Location = new System.Drawing.Point(148, 21);
            this.simWeekButton.Name = "simWeekButton";
            this.simWeekButton.Size = new System.Drawing.Size(66, 23);
            this.simWeekButton.TabIndex = 3;
            this.simWeekButton.Text = "1 Week";
            this.simWeekButton.UseVisualStyleBackColor = true;
            this.simWeekButton.Click += new System.EventHandler(this.simWeekButton_Click);
            // 
            // simMonthButton
            // 
            this.simMonthButton.Location = new System.Drawing.Point(220, 21);
            this.simMonthButton.Name = "simMonthButton";
            this.simMonthButton.Size = new System.Drawing.Size(66, 23);
            this.simMonthButton.TabIndex = 4;
            this.simMonthButton.Text = "1 Month";
            this.simMonthButton.UseVisualStyleBackColor = true;
            this.simMonthButton.Click += new System.EventHandler(this.simMonthButton_Click);
            // 
            // simSeasonButton
            // 
            this.simSeasonButton.Location = new System.Drawing.Point(292, 21);
            this.simSeasonButton.Name = "simSeasonButton";
            this.simSeasonButton.Size = new System.Drawing.Size(66, 23);
            this.simSeasonButton.TabIndex = 5;
            this.simSeasonButton.Text = "Season";
            this.simSeasonButton.UseVisualStyleBackColor = true;
            this.simSeasonButton.Click += new System.EventHandler(this.simSeasonButton_Click);
            // 
            // SimLeagueControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.simSeasonButton);
            this.Controls.Add(this.simMonthButton);
            this.Controls.Add(this.simWeekButton);
            this.Controls.Add(this.simThreeButton);
            this.Controls.Add(this.simOneButton);
            this.Controls.Add(this.simDisplayLabel);
            this.Name = "SimLeagueControl";
            this.Size = new System.Drawing.Size(360, 50);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label simDisplayLabel;
        private System.Windows.Forms.Button simOneButton;
        private System.Windows.Forms.Button simThreeButton;
        private System.Windows.Forms.Button simWeekButton;
        private System.Windows.Forms.Button simMonthButton;
        private System.Windows.Forms.Button simSeasonButton;
    }
}
