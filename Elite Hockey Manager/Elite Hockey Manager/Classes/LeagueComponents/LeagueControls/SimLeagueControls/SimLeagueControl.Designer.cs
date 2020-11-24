namespace Elite_Hockey_Manager.Classes.LeagueComponents.LeagueControls.SimLeagueControls
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
            this.simFirstButton = new System.Windows.Forms.Button();
            this.simSecondButton = new System.Windows.Forms.Button();
            this.simThirdButton = new System.Windows.Forms.Button();
            this.simFourthButton = new System.Windows.Forms.Button();
            this.simFifthButton = new System.Windows.Forms.Button();
            this.advanceStateButton = new System.Windows.Forms.Button();
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
            // simFirstButton
            // 
            this.simFirstButton.Location = new System.Drawing.Point(4, 29);
            this.simFirstButton.Name = "simFirstButton";
            this.simFirstButton.Size = new System.Drawing.Size(66, 23);
            this.simFirstButton.TabIndex = 1;
            this.simFirstButton.Text = "1";
            this.simFirstButton.UseVisualStyleBackColor = true;
            this.simFirstButton.Click += new System.EventHandler(this.Sim1Button_Click);
            // 
            // simSecondButton
            // 
            this.simSecondButton.Location = new System.Drawing.Point(76, 29);
            this.simSecondButton.Name = "simSecondButton";
            this.simSecondButton.Size = new System.Drawing.Size(66, 23);
            this.simSecondButton.TabIndex = 2;
            this.simSecondButton.Text = "2";
            this.simSecondButton.UseVisualStyleBackColor = true;
            this.simSecondButton.Click += new System.EventHandler(this.Sim2Button_Click);
            // 
            // simThirdButton
            // 
            this.simThirdButton.Location = new System.Drawing.Point(148, 29);
            this.simThirdButton.Name = "simThirdButton";
            this.simThirdButton.Size = new System.Drawing.Size(66, 23);
            this.simThirdButton.TabIndex = 3;
            this.simThirdButton.Text = "3";
            this.simThirdButton.UseVisualStyleBackColor = true;
            this.simThirdButton.Click += new System.EventHandler(this.Sim3Button_Click);
            // 
            // simFourthButton
            // 
            this.simFourthButton.Location = new System.Drawing.Point(220, 29);
            this.simFourthButton.Name = "simFourthButton";
            this.simFourthButton.Size = new System.Drawing.Size(66, 23);
            this.simFourthButton.TabIndex = 4;
            this.simFourthButton.Text = "4";
            this.simFourthButton.UseVisualStyleBackColor = true;
            this.simFourthButton.Click += new System.EventHandler(this.Sim4Button_Click);
            // 
            // simFifthButton
            // 
            this.simFifthButton.Location = new System.Drawing.Point(291, 29);
            this.simFifthButton.Name = "simFifthButton";
            this.simFifthButton.Size = new System.Drawing.Size(66, 23);
            this.simFifthButton.TabIndex = 5;
            this.simFifthButton.Text = "5";
            this.simFifthButton.UseVisualStyleBackColor = true;
            this.simFifthButton.Click += new System.EventHandler(this.Sim5Button_Click);
            // 
            // advanceStateButton
            // 
            this.advanceStateButton.Enabled = false;
            this.advanceStateButton.Location = new System.Drawing.Point(220, 0);
            this.advanceStateButton.Name = "advanceStateButton";
            this.advanceStateButton.Size = new System.Drawing.Size(137, 23);
            this.advanceStateButton.TabIndex = 6;
            this.advanceStateButton.Text = "Advance State";
            this.advanceStateButton.UseVisualStyleBackColor = true;
            this.advanceStateButton.Visible = false;
            this.advanceStateButton.Click += new System.EventHandler(this.AdvanceStateButton_Click);
            // 
            // SimLeagueControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.advanceStateButton);
            this.Controls.Add(this.simFifthButton);
            this.Controls.Add(this.simFourthButton);
            this.Controls.Add(this.simThirdButton);
            this.Controls.Add(this.simSecondButton);
            this.Controls.Add(this.simFirstButton);
            this.Controls.Add(this.simDisplayLabel);
            this.Name = "SimLeagueControl";
            this.Size = new System.Drawing.Size(360, 58);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        protected System.Windows.Forms.Button simSecondButton;
        protected System.Windows.Forms.Button simThirdButton;
        protected System.Windows.Forms.Button simFourthButton;
        protected System.Windows.Forms.Button simFifthButton;
        protected System.Windows.Forms.Label simDisplayLabel;
        protected System.Windows.Forms.Button simFirstButton;
        protected System.Windows.Forms.Button advanceStateButton;
    }
}
