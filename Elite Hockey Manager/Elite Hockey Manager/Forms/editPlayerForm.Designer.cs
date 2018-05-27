namespace Elite_Hockey_Manager.Forms
{
    partial class EditPlayerForm
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
            this.generalGroup = new System.Windows.Forms.GroupBox();
            this.idLabel = new System.Windows.Forms.Label();
            this.ageLabel = new System.Windows.Forms.Label();
            this.lastLabel = new System.Windows.Forms.Label();
            this.firstLabel = new System.Windows.Forms.Label();
            this.firstText = new System.Windows.Forms.TextBox();
            this.lastText = new System.Windows.Forms.TextBox();
            this.ageText = new System.Windows.Forms.TextBox();
            this.idText = new System.Windows.Forms.TextBox();
            this.statsGroup = new System.Windows.Forms.GroupBox();
            this.generalGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // generalGroup
            // 
            this.generalGroup.Controls.Add(this.idText);
            this.generalGroup.Controls.Add(this.ageText);
            this.generalGroup.Controls.Add(this.lastText);
            this.generalGroup.Controls.Add(this.firstText);
            this.generalGroup.Controls.Add(this.idLabel);
            this.generalGroup.Controls.Add(this.ageLabel);
            this.generalGroup.Controls.Add(this.lastLabel);
            this.generalGroup.Controls.Add(this.firstLabel);
            this.generalGroup.Location = new System.Drawing.Point(13, 13);
            this.generalGroup.Name = "generalGroup";
            this.generalGroup.Size = new System.Drawing.Size(301, 127);
            this.generalGroup.TabIndex = 0;
            this.generalGroup.TabStop = false;
            this.generalGroup.Text = "General Information";
            // 
            // idLabel
            // 
            this.idLabel.AutoSize = true;
            this.idLabel.Location = new System.Drawing.Point(7, 101);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(53, 13);
            this.idLabel.TabIndex = 3;
            this.idLabel.Text = "Player ID:";
            // 
            // ageLabel
            // 
            this.ageLabel.AutoSize = true;
            this.ageLabel.Location = new System.Drawing.Point(6, 74);
            this.ageLabel.Name = "ageLabel";
            this.ageLabel.Size = new System.Drawing.Size(29, 13);
            this.ageLabel.TabIndex = 2;
            this.ageLabel.Text = "Age:";
            // 
            // lastLabel
            // 
            this.lastLabel.AutoSize = true;
            this.lastLabel.Location = new System.Drawing.Point(7, 47);
            this.lastLabel.Name = "lastLabel";
            this.lastLabel.Size = new System.Drawing.Size(61, 13);
            this.lastLabel.TabIndex = 1;
            this.lastLabel.Text = "Last Name:";
            // 
            // firstLabel
            // 
            this.firstLabel.AutoSize = true;
            this.firstLabel.Location = new System.Drawing.Point(7, 20);
            this.firstLabel.Name = "firstLabel";
            this.firstLabel.Size = new System.Drawing.Size(60, 13);
            this.firstLabel.TabIndex = 0;
            this.firstLabel.Text = "First Name:";
            // 
            // firstText
            // 
            this.firstText.Location = new System.Drawing.Point(174, 20);
            this.firstText.Name = "firstText";
            this.firstText.Size = new System.Drawing.Size(100, 20);
            this.firstText.TabIndex = 4;
            // 
            // lastText
            // 
            this.lastText.Location = new System.Drawing.Point(174, 47);
            this.lastText.Name = "lastText";
            this.lastText.Size = new System.Drawing.Size(100, 20);
            this.lastText.TabIndex = 5;
            // 
            // ageText
            // 
            this.ageText.Location = new System.Drawing.Point(174, 74);
            this.ageText.Name = "ageText";
            this.ageText.Size = new System.Drawing.Size(100, 20);
            this.ageText.TabIndex = 6;
            // 
            // idText
            // 
            this.idText.Location = new System.Drawing.Point(174, 101);
            this.idText.Name = "idText";
            this.idText.ReadOnly = true;
            this.idText.Size = new System.Drawing.Size(100, 20);
            this.idText.TabIndex = 7;
            // 
            // statsGroup
            // 
            this.statsGroup.Location = new System.Drawing.Point(13, 147);
            this.statsGroup.Name = "statsGroup";
            this.statsGroup.Size = new System.Drawing.Size(301, 280);
            this.statsGroup.TabIndex = 1;
            this.statsGroup.TabStop = false;
            this.statsGroup.Text = "Stats:";
            // 
            // EditPlayerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 461);
            this.Controls.Add(this.statsGroup);
            this.Controls.Add(this.generalGroup);
            this.Name = "EditPlayerForm";
            this.Text = "editPlayerForm";
            this.Load += new System.EventHandler(this.EditPlayerForm_Load);
            this.generalGroup.ResumeLayout(false);
            this.generalGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox generalGroup;
        private System.Windows.Forms.Label idLabel;
        private System.Windows.Forms.Label ageLabel;
        private System.Windows.Forms.Label lastLabel;
        private System.Windows.Forms.Label firstLabel;
        private System.Windows.Forms.TextBox idText;
        private System.Windows.Forms.TextBox ageText;
        private System.Windows.Forms.TextBox lastText;
        private System.Windows.Forms.TextBox firstText;
        private System.Windows.Forms.GroupBox statsGroup;
    }
}