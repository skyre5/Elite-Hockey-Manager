namespace Elite_Hockey_Manager.Classes.LeagueComponents.LeagueControls.SimLeagueControls
{
    partial class SimLeagueOffseasonControl
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
            this.stageLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // simSecondButton
            // 
            this.simSecondButton.Location = new System.Drawing.Point(117, 29);
            this.simSecondButton.Size = new System.Drawing.Size(123, 23);
            this.simSecondButton.Text = "Advance Current State";
            // 
            // simThirdButton
            // 
            this.simThirdButton.Location = new System.Drawing.Point(246, 28);
            this.simThirdButton.Size = new System.Drawing.Size(111, 23);
            this.simThirdButton.Text = "Finish Offseason";
            // 
            // simFourthButton
            // 
            this.simFourthButton.Location = new System.Drawing.Point(3, 57);
            this.simFourthButton.Size = new System.Drawing.Size(170, 23);
            this.simFourthButton.Text = "Sim 1 Day";
            this.simFourthButton.Visible = false;
            // 
            // simFifthButton
            // 
            this.simFifthButton.Location = new System.Drawing.Point(187, 57);
            this.simFifthButton.Size = new System.Drawing.Size(170, 23);
            this.simFifthButton.Text = "Sim 3 Days";
            this.simFifthButton.Visible = false;
            // 
            // simDisplayLabel
            // 
            this.simDisplayLabel.Size = new System.Drawing.Size(78, 13);
            this.simDisplayLabel.Text = "Sim Offseason:";
            // 
            // simFirstButton
            // 
            this.simFirstButton.Size = new System.Drawing.Size(107, 23);
            this.simFirstButton.Text = "Enter Current State";
            // 
            // stageLabel
            // 
            this.stageLabel.AutoSize = true;
            this.stageLabel.Location = new System.Drawing.Point(88, 4);
            this.stageLabel.Name = "stageLabel";
            this.stageLabel.Size = new System.Drawing.Size(38, 13);
            this.stageLabel.TabIndex = 7;
            this.stageLabel.Text = "Stage:";
            // 
            // SimLeagueOffseasonControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.stageLabel);
            this.Name = "SimLeagueOffseasonControl";
            this.Size = new System.Drawing.Size(360, 83);
            this.Controls.SetChildIndex(this.simDisplayLabel, 0);
            this.Controls.SetChildIndex(this.simFirstButton, 0);
            this.Controls.SetChildIndex(this.simSecondButton, 0);
            this.Controls.SetChildIndex(this.simThirdButton, 0);
            this.Controls.SetChildIndex(this.simFourthButton, 0);
            this.Controls.SetChildIndex(this.simFifthButton, 0);
            this.Controls.SetChildIndex(this.advanceStateButton, 0);
            this.Controls.SetChildIndex(this.stageLabel, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        protected override void SetControlsText()
        {
            throw new System.NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.Label stageLabel;
    }
}
