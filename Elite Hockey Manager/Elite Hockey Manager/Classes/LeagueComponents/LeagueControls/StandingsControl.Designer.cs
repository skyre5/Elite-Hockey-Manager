namespace Elite_Hockey_Manager.Classes.LeagueComponents
{
    partial class StandingsControl
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
            this.firstConferenceLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.secondConferenceLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.firstConfereneLabel = new System.Windows.Forms.Label();
            this.secondConferenceLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // firstConferenceLayout
            // 
            this.firstConferenceLayout.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.firstConferenceLayout.Location = new System.Drawing.Point(3, 28);
            this.firstConferenceLayout.Name = "firstConferenceLayout";
            this.firstConferenceLayout.Size = new System.Drawing.Size(225, 307);
            this.firstConferenceLayout.TabIndex = 0;
            // 
            // secondConferenceLayout
            // 
            this.secondConferenceLayout.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.secondConferenceLayout.Location = new System.Drawing.Point(230, 28);
            this.secondConferenceLayout.Name = "secondConferenceLayout";
            this.secondConferenceLayout.Size = new System.Drawing.Size(225, 307);
            this.secondConferenceLayout.TabIndex = 1;
            // 
            // firstConfereneLabel
            // 
            this.firstConfereneLabel.AutoSize = true;
            this.firstConfereneLabel.Location = new System.Drawing.Point(4, 9);
            this.firstConfereneLabel.Name = "firstConfereneLabel";
            this.firstConfereneLabel.Size = new System.Drawing.Size(84, 13);
            this.firstConfereneLabel.TabIndex = 2;
            this.firstConfereneLabel.Text = "First Conference";
            // 
            // secondConferenceLabel
            // 
            this.secondConferenceLabel.AutoSize = true;
            this.secondConferenceLabel.Location = new System.Drawing.Point(230, 9);
            this.secondConferenceLabel.Name = "secondConferenceLabel";
            this.secondConferenceLabel.Size = new System.Drawing.Size(102, 13);
            this.secondConferenceLabel.TabIndex = 3;
            this.secondConferenceLabel.Text = "Second Conference";
            // 
            // StandingsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.secondConferenceLabel);
            this.Controls.Add(this.firstConfereneLabel);
            this.Controls.Add(this.secondConferenceLayout);
            this.Controls.Add(this.firstConferenceLayout);
            this.Name = "StandingsControl";
            this.Size = new System.Drawing.Size(456, 339);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel firstConferenceLayout;
        private System.Windows.Forms.FlowLayoutPanel secondConferenceLayout;
        private System.Windows.Forms.Label firstConfereneLabel;
        private System.Windows.Forms.Label secondConferenceLabel;
    }
}
